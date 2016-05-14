using System.Data.Entity;
using Cobalt.DataAccess.Models;

namespace Cobalt.DataAccess.Context
{
    public class CobaltContext : DbContext, ICobaltContext
    {
        public CobaltContext() : base("Name=CobaltContext")
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        public void SaveAsync()
        {
            SaveChangesAsync();
        }

        public bool DoesDatabaseExist()
        {
            return Database.Exists();
        }
    }
}