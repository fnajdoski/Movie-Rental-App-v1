namespace MovieRentalApp.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MembershipCardNumber { get; set; }
        public DateTime MembershipCardValidityDate { get; set; }
    }
}
