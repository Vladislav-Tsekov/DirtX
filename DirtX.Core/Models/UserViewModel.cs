namespace DirtX.Core.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsReseller { get; set; }
    }
}

