

namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public bool IsAdmin { get; set; }
        public virtual Company Company { get; set; }
        public virtual UserInWarehouse UserInWarehouse { get; set; }
    }
}
