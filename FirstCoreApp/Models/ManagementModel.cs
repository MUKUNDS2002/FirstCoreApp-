using FirstCoreApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCoreApp.Models
{
    public class ManagementModel
    {
        [Required(ErrorMessage = "Name Not Found")]
        
        public string FirstName { get; set; }
      
        [Required(ErrorMessage = "Id Not Found")]
        public int ID { get; set; }

        [Required(ErrorMessage = "ManagementNo Not Found")]
        public int ManagementNo { get; set; }


        [NotMapped]
        public int Age { get => CommonLogic.CalculateAge(DOB); set => Age = CommonLogic.CalculateAge(DOB); }

        //[Required(ErrorMessage = "Position Not Found")]
        //public string Position { get; set; }

        [Required(ErrorMessage = "Office Not Found")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Salary Not Found")]

        public int Salary { get; set; }

        [Required(ErrorMessage = "Email ID Not Found")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Position Not Found")]
        public string Position { get; set; }

        [Required(ErrorMessage ="DOB Not Found")]
        public DateOnly DOB { get; set; }

    }
}
