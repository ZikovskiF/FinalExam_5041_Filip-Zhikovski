namespace FinalExam_5041.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public int CarId { get; set; }
    }
}
