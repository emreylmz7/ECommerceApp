namespace OllieShop.IdentityServer.Dtos
{
    public class ChangePasswordDto
    {
        public string UserId { get; set; }           // Kullanıcının ID'si
        public string CurrentPassword { get; set; }  // Mevcut parola
        public string NewPassword { get; set; }      // Yeni parola
    }
}
