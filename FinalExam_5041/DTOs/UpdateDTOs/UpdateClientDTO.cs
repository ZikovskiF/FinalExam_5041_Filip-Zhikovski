namespace FinalExam_5041.DTOs.UpdateDTOs
{
    public class UpdateClientDTO
    {
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
