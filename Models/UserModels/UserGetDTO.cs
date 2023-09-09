namespace TypeLeague.Models.UserModels
{
    public class UserGetDTO
    {
        public string Id { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? UserName { get; set; } = null!;
        public int Points { get; set; }
    }
}
