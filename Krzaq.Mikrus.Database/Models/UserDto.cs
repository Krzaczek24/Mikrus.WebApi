namespace Krzaq.Mikrus.Database.Models
{
    public record class UserDto
    {
        public int Id { get; init; }
        public string Login { get; init; }
        public string? DisplayName { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime? LastLogin { get; init; }
    }
}
