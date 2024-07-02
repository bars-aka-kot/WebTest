using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProj.DB.Model
{
    [Table("users")]
    public partial class User
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}