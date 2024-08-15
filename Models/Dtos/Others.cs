

namespace Models.Dtos
{
    public class Others
    {
    }

    public class Token
    {
        public required string Access_Token { get; set; }
        public DateTime Expire_Token { get; set; }
        public required string Email { get; set; }
        public int UserId { get; set; }
    }
}
