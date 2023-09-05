namespace TypeLeague.Models.UserModels
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Points { get; set; }
    }
}
