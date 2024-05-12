namespace AppLibrary.Models
{
    public class User
    {
        public int User_Id { get; set; }
        public required string User_Name { get; set; }
        public required string Password { get; set; }
        public string? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
    }
}
