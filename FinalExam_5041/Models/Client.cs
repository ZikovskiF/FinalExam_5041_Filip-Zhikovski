using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam_5041.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(400)]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public DateTime RentStart { get; set; }
        [Required]
        public DateTime RentEnd { get; set; }
        [ForeignKey ("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
