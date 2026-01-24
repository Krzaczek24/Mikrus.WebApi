namespace Krzaq.Mikrus.WebApi.Core.Authorization
{
    public class UserDto
    {
        public required DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string DisplayName { get; set; }
        //public UserRole Role { get; set; }
        //public string[] Permissions { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string FirstAndLastName => $"{FirstName} {LastName}".Trim();
    }
}
