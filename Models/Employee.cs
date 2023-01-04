using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_m_employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        //relasi
        [JsonIgnore]
        [ForeignKey("DepartmentId")]
        public Department? departments { get; set; }

        [JsonIgnore] 
        public Account? Account { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
