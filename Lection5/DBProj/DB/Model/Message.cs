using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProj.DB.Model
{
    [Table("messages")]
    public partial class Message
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("message")]
        public string MessageContent { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
