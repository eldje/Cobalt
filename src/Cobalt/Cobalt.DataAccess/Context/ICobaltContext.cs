using System.Data.Entity;
using Cobalt.DataAccess.Models;

namespace Cobalt.DataAccess.Context
{
    public interface ICobaltContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Complaint> Complaints { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Address> Addresses { get; set; }

        void Save();
        void SaveAsync();
        bool DoesDatabaseExist();
    }
}