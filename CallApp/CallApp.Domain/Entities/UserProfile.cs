namespace CallApp.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
