using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models
{
    [Table("tb_r_account_role")]
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string AccountNIK { get; set; }
        public int RoleId { get; set;}

        //Relasi
        [JsonIgnore]
        [ForeignKey("RoleId")]
        public Role? role {get; set; }

        public Account? Account { get; set; }

    }
}
