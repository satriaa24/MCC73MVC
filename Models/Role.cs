using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_m_role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }

        //relasi
        [JsonIgnore]
        public ICollection<AccountRole>? accountRoles { get; set; }
    }
}