namespace JwtAuthpractice.Models
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }
        public required String RefreshToken { get; set; }
    }
}
