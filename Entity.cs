using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;


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

    public class SodaRepository
    {
        private SodaContext db;
        public SodaRepository()
        {
            db = new SodaContext();
            db.Sodas.Load();
            db.Companies.Load();
        }

        public BindingList<Soda> GetAll()
        {
            return db.Sodas.Local.ToBindingList();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
    public class CompanyRepository
    {
        private SodaContext db;
        public CompanyRepository()
        {
            db = new SodaContext();
            db.Sodas.Load();
            db.Companies.Load();
        }

        public BindingList<Company> GetAll()
        {
            return db.Companies.Local.ToBindingList();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }

    public class UnitOfWork
    {
        CompanyRepository cr = new CompanyRepository();
        SodaRepository sr = new SodaRepository();

        public BindingList<Company> GetCompanies()
        {
            return cr.GetAll();
        }
        public BindingList<Soda> GetSodas()
        {
            return sr.GetAll();
        }
        public void SaveChanges()
        {
            cr.SaveChanges();
            sr.SaveChanges();
        }
    }
}
