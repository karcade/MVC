namespace WebApp.Model.DatabaseModels
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = null;
        public byte[] PasswordSalt { get; set; } = null;

    }
}
