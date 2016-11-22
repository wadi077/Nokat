using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemNokta.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Comment")]
        public String CommentContent { get; set; }
        [ForeignKey("Nokat")]
        public virtual int NoktaId { get; set; }

        public Nokta Nokat { get; set; }
    }
}