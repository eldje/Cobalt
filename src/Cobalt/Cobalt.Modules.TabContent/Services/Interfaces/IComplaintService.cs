using System;
using System.Collections.Generic;
using Cobalt.DataAccess.Models;

namespace Cobalt.Modules.TabContent.Services.Interfaces
{
    public interface IComplaintService
    {
        List<Complaint> GetComplaintsWhere(Func<Complaint, bool> predicate);
        List<Complaint> GetComplaintsWhere(string predicate);
        bool Remove(Complaint complaint);
        bool Save();
        void DoesDatabaseExist();
    }
}
