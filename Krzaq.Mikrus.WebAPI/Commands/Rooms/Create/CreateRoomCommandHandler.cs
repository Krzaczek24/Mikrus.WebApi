using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.Database;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.Database.Models.Insert;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Create
{
    public class CreateRoomCommandHandler(
        IHttpContextAccessor httpAccessor,
        ITransactionManager txMgr,
        IDbGameAccess gameAccess,
        IDbRoomAccess roomAccess)
        : IRequestHandler<CreateRoomCommand, CreateRoomCommandResult>
    {
        public async ValueTask<CreateRoomCommandResult> Handle(CreateRoomCommand request)
        {
            //int? userId = httpAccessor.GetUser()?.GetID();
            //if (!userId.HasValue || !await userAccess.DoesUserExist(userId.Value))
            //    throw new UnauthorizedException(ErrorCode.Unauthorized);

            var errors = new List<ErrorModel>();
            errors.AddRange(await GetGameErrors(request));
            errors.AddRange(await GetRoomErrors(request));
            if (errors.Count > 0)
                throw new ConflictException(errors);

            int userId = httpAccessor.GetUser()!.GetId();

            using var tx = await txMgr.BeginTransaction();

            var roomParams = new InsertRoomDto
            {
                OwnerId = userId,
                GameId = request.GameId,
                Name = request.Name,
                MinPlayers = request.MinPlayers,
                MaxPlayers = request.MaxPlayers,
                ExpireDate = request.ExpireDate,
                Password = request.Password,
                Guid = request.Guid,
                PassFriends = request.PassFriends
            };

            int roomId = await roomAccess.CreateRoom(roomParams);
            var result = new CreateRoomCommandResult { RoomId = roomId };

            await roomAccess.JoinRoom(roomId, userId);
            await tx.CommitAsync();

            return result;
        }

        private async ValueTask<IReadOnlyCollection<ErrorModel>> GetGameErrors(CreateRoomCommand request)
        {
            var game = await gameAccess.GetGame(request.GameId);
            if (!game.HasValue)
                return [ErrorCode.NotFound.AsFieldError(nameof(request.GameId).ToCamelCase())];

            var errors = new List<ErrorModel>();

            if (request.MaxPlayers > game.Value.MaxPlayers)
                errors.Add(ErrorCode.GreaterThan.AsFieldError(nameof(request.MaxPlayers), game.Value.MaxPlayers));
            else if (request.MaxPlayers < game.Value.MinPlayers)
                errors.Add(ErrorCode.LesserThan.AsFieldError(nameof(request.MaxPlayers), game.Value.MinPlayers));

            if (request.MinPlayers < game.Value.MinPlayers)
                errors.Add(ErrorCode.LesserThan.AsFieldError(nameof(request.MinPlayers), game.Value.MinPlayers));
            else if (request.MinPlayers > game.Value.MaxPlayers)
                errors.Add(ErrorCode.GreaterThan.AsFieldError(nameof(request.MinPlayers), game.Value.MaxPlayers));

            return errors;
        }

        private async ValueTask<IReadOnlyCollection<ErrorModel>> GetRoomErrors(CreateRoomCommand request)
        {
            var errors = new List<ErrorModel>();

            if (await roomAccess.IsNameUsed(request.Name))
                errors.Add(ErrorCode.NonUnique.AsFieldError(nameof(request.Name)));

            if (request.Guid.HasValue && await roomAccess.IsGuidUsed(request.Guid.Value))
                errors.Add(ErrorCode.NonUnique.AsFieldError(nameof(request.Guid)));

            return errors;
        }
    }
}
