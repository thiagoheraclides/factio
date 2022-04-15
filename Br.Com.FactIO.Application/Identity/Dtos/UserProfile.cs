namespace Br.Com.FactIO.Application.Identity.Dtos
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleId { get; set; }
        public string RoleDescription { get; set; }
        public string TypeId { get; set; }
        public string TypeDesccription { get; set; }
        public string Token { get; set; }
    }
}
