using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemNokta.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter User Name")]
        public String UserName { get; set; }

        [Required(ErrorMessage ="Please Enter Your Email")]
        public String Email { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public String ProfilePic { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public String ConfirmPassword { get; set; }

        public ICollection<Nokta> Nokat { get; set; }
    }
}