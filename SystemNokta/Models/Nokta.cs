using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemNokta.Models
{
    public class Nokta
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public String NoktaContent { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        [ForeignKey("UserAccount")]
        public virtual int UserId { get; set; }

        public UserAccount UserAccount { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}