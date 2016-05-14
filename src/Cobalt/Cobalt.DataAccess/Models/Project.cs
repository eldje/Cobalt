using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Prism.Mvvm;

namespace Cobalt.DataAccess.Models
{
    public class Project : BindableBase
    {
        private Contact _architectContact;
        private int _architectContactId;
        private Contact _clientContact;
        private int _clientContactId;
        private ICollection<Complaint> _complaints;
        private Address _projectAddress;
        private int _projectAddressId;
        private int _projectId;
        private Contact _projectManagerContact;
        private int _projectManagerId;
        private string _projectName;

        [Key]
        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                _projectId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("ClientContact")]
        public int ClientContactId
        {
            get { return _clientContactId; }
            set
            {
                _clientContactId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("ArchitectContact")]
        public int ArchitectContactId
        {
            get { return _architectContactId; }
            set
            {
                _architectContactId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("ProjectManagerContact")]
        public int ProjectManagerId
        {
            get { return _projectManagerId; }
            set
            {
                _projectManagerId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("ProjectAddress")]
        public int ProjectAddressId
        {
            get { return _projectAddressId; }
            set
            {
                _projectAddressId = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value;
                OnPropertyChanged();
            }
        }

        public ICollection<Complaint> Complaints
        {
            get { return _complaints; }
            set
            {
                _complaints = value;
                OnPropertyChanged();
            }
        }

        public Contact ClientContact
        {
            get { return _clientContact; }
            set
            {
                _clientContact = value;
                OnPropertyChanged();
            }
        }

        public Contact ArchitectContact
        {
            get { return _architectContact; }
            set
            {
                _architectContact = value;
                OnPropertyChanged();
            }
        }

        public Contact ProjectManagerContact
        {
            get { return _projectManagerContact; }
            set
            {
                _projectManagerContact = value;
                OnPropertyChanged();
            }
        }

        public Address ProjectAddress
        {
            get { return _projectAddress; }
            set
            {
                _projectAddress = value;
                OnPropertyChanged();
            }
        }
    }
}