namespace Data.DTO
{
    public record UserDto
    {
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public UserDto(Guid userId, string name, string email)
        {
            UserId = userId;
            Name = name;
            Email = email;
        }
    }

    public record LoginModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
