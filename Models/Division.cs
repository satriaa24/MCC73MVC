using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_m_division")]
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public string Name { get; set; }

        //relasi
        [JsonIgnore]
        public ICollection<Department>? departments { get; set; }
    }
}
