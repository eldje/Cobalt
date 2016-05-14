using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Cobalt.DataAccess.Context;
using Cobalt.DataAccess.Models;
using Cobalt.Infrastructure.Enums;
using Cobalt.Infrastructure.Events;
using Cobalt.Infrastructure.Models;
using Cobalt.Modules.TabContent.Services.Interfaces;
using Prism.Events;

namespace Cobalt.Modules.TabContent.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly ICobaltContext _context;
        private readonly IEventAggregator _eventAggregator;

        public ComplaintService(ICobaltContext context, IEventAggregator eventAggregator)
        {
            _context = context;
            _eventAggregator = eventAggregator;

            DoesDatabaseExist();
        }

        public List<Complaint> GetComplaintsWhere(Func<Complaint, bool> predicate)
        {
            return new List<Complaint>().Where(predicate).ToList();
        }

        public List<Complaint> GetComplaintsWhere(string predicate)
        {
            return new List<Complaint>
            {
                new Complaint
                {
                    ComplaintId = 1,
                    ComplaintName = "First Complaint",
                    Vo = true
                },
                new Complaint
                {
                    ComplaintId = 2,
                    ComplaintName = "Second Complaint"
                },
                new Complaint
                {
                    ComplaintId = 3,
                    ComplaintName = "Third Complaint",
                    Vo = true
                },
                new Complaint
                {
                    ComplaintId = 4,
                    ComplaintName = "Fourth Complaint",
                    Vo = true
                }
            }.Where(predicate).ToList();
            //return _context.Complaints.Include("").Where(predicate).ToList();
        }

        public bool Remove(Complaint complaint)
        {
            throw new NotImplementedException();
        }

        public void DoesDatabaseExist()
        {
            try
            {
                _context.DoesDatabaseExist();
                _eventAggregator.GetEvent<ApplicationStatusEvent>().Publish(new ApplicationStatusPayload
                {
                    Message = "Ready",
                    ApplicationStatusEnum = ApplicationStatusEnum.Ready
                });
            }
            catch (Exception ex)
            {
                _eventAggregator.GetEvent<ApplicationStatusEvent>().Publish(new ApplicationStatusPayload
                {
                    Message = ex.Message,
                    ApplicationStatusEnum = ApplicationStatusEnum.Error
                });
            }
        }

        public bool Save()
        {
            _context.Save();
            return true;
        }
    }
}