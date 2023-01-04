using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_m_account")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }

        //relasi
        [JsonIgnore]
        public ICollection<AccountRole>? accountRoles { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
