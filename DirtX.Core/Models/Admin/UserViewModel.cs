namespace DirtX.Core.Models.Admin
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsReseller { get; set; }
    }
}

