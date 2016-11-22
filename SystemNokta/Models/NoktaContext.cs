namespace SystemNokta.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NoktaContext : DbContext
    {
        
        public NoktaContext()
            : base("name=NoktaContext")
        {
        }

        public virtual DbSet<UserAccount> Users { get; set; }
        public virtual DbSet<Nokta> Nokat { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}