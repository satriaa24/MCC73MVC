using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_m_department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        //relasi
        [JsonIgnore]
        [ForeignKey("DivisionId")]
        public Division? Division { get; set; }

        public ICollection<Employee> employees { get; set; }
    }

    
}
