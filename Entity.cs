using System.Data.Entity;
using System.Collections.Generic;


namespace s4_oop_l11
{
    public class Soda
    {
        public int SodaId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }


        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    } 

    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public ICollection<Soda> Sodas { get; set; }
        public Company()
        {
            Sodas = new List<Soda>();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class SodaContext : DbContext
    {
        public SodaContext() : base("DefaultConnection")
        {

        }

        public DbSet<Soda> Sodas { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
