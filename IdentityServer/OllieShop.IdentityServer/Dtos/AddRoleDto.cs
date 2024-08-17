namespace OllieShop.IdentityServer.Dtos
{
    public class AddRoleDto
    {
        public string UserId { get; set; }  // Kullanıcının ID'si
        public string Role { get; set; }    // Eklemek istediğiniz rol adı
    }
}
