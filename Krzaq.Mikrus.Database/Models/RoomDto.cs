namespace Krzaq.Mikrus.Database.Models
{
    public record class RoomDto
    {
        public int Id { get; init; }
        public UserDto Owner { get; init; }
        public int Capacity { get; init; }
        public string Name { get; init; }
        public bool Password { get; init; }
    }
}
