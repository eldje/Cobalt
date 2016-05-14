using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cobalt.Infrastructure.Converters;
using Prism.Mvvm;

namespace Cobalt.DataAccess.Models
{
    public class Complaint : BindableBase
    {
        private ActionByNotEcType _actionByNotEc = 0;
        private string _actionByNotEcComment;
        private DateTime? _actionDate;
        private string _affirmationInhabitant;
        private int _complaintId;
        private string _complaintName;
        private ComplaintStatusType _complaintStatus = 0;
        private DateTime? _dateCreated = DateTime.Now;
        private DateTime? _dueDate;
        private EmailStatusType _emailStatus = 0;
        private string _internalRemarkEc;
        private DateTime? _lastUpdated;
        private Contact _occupantContact;
        private int? _occupantContactId;
        private decimal _price;
        private Project _project;
        private int _projectId;
        private string _remarkArchitect;
        private string _remarkClient;
        private string _remarkEc;
        private string _remarkEngineer;
        private string _remarkExpert;
        private bool _solvedAll;
        private bool _solvedPm;
        private bool _solvedSub;
        private string _storageDirectory;
        private Contact _subContractorContact;
        private int? _subContractorContactId;
        private bool _vo;

        [Key]
        public int ComplaintId
        {
            get { return _complaintId; }
            set
            {
                _complaintId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("Project")]
        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                _projectId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("OccupantContact")]
        public int? OccupantContactId
        {
            get { return _occupantContactId; }
            set
            {
                _occupantContactId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("SubContractorContact")]
        public int? SubContractorContactId
        {
            get { return _subContractorContactId; }
            set
            {
                _subContractorContactId = value;
                OnPropertyChanged();
            }
        }

        [EnumDataType(typeof(ComplaintStatusType))]
        public ComplaintStatusType ComplaintStatus
        {
            get { return _complaintStatus; }
            set
            {
                _complaintStatus = value;
                OnPropertyChanged();
            }
        }

        [EnumDataType(typeof(EmailStatusType))]
        public EmailStatusType EmailStatus
        {
            get { return _emailStatus; }
            set
            {
                _emailStatus = value;
                OnPropertyChanged();
            }
        }

        [EnumDataType(typeof(ActionByNotEcType))]
        public ActionByNotEcType ActionByNotEc
        {
            get { return _actionByNotEc; }
            set
            {
                _actionByNotEc = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string ActionByNotEcComment
        {
            get { return _actionByNotEcComment; }
            set
            {
                _actionByNotEcComment = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string ComplaintName
        {
            get { return _complaintName; }
            set
            {
                _complaintName = value;
                OnPropertyChanged();
            }
        }

        public bool Vo
        {
            get { return _vo; }
            set
            {
                _vo = value;
                OnPropertyChanged();
            }
        }

        public bool SolvedSub
        {
            get { return _solvedSub; }
            set
            {
                _solvedSub = value;
                OnPropertyChanged();
            }
        }

        public bool SolvedPm
        {
            get { return _solvedPm; }
            set
            {
                _solvedPm = value;
                OnPropertyChanged();
            }
        }

        public bool SolvedAll
        {
            get { return _solvedAll; }
            set
            {
                _solvedAll = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string AffirmationInhabitant
        {
            get { return _affirmationInhabitant; }
            set
            {
                _affirmationInhabitant = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string RemarkArchitect
        {
            get { return _remarkArchitect; }
            set
            {
                _remarkArchitect = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string RemarkClient
        {
            get { return _remarkClient; }
            set
            {
                _remarkClient = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string RemarkEc
        {
            get { return _remarkEc; }
            set
            {
                _remarkEc = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string RemarkEngineer
        {
            get { return _remarkEngineer; }
            set
            {
                _remarkEngineer = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string RemarkExpert
        {
            get { return _remarkExpert; }
            set
            {
                _remarkExpert = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string InternalRemarkEc
        {
            get { return _internalRemarkEc; }
            set
            {
                _internalRemarkEc = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(255)]
        public string StorageDirectory
        {
            get { return _storageDirectory; }
            set
            {
                _storageDirectory = value;
                OnPropertyChanged();
            }
        }

        public DateTime? ActionDate
        {
            get { return _actionDate; }
            set
            {
                _actionDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                _lastUpdated = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DateCreated
        {
            get { return _dateCreated; }
            set
            {
                _dateCreated = value;
                OnPropertyChanged();
            }
        }

        public Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public Contact OccupantContact
        {
            get { return _occupantContact; }
            set
            {
                _occupantContact = value;
                OnPropertyChanged();
            }
        }

        public Contact SubContractorContact
        {
            get { return _subContractorContact; }
            set
            {
                _subContractorContact = value;
                OnPropertyChanged();
            }
        }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ComplaintStatusType
    {
        [Description("No Status")] NoStatus = 0,
        [Description("Needs Technical Council")] NeedTechnicalCouncil = 1,
        [Description("Less Value")] LessValue = 2,
        [Description("Action Needed")] ActionNeeded = 3,
        [Description("Ungrounded")] Ungrounded = 4,
        [Description("Resolved")] Resolved = 5,
        [Description("On Hold")] OnHold = 6
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum EmailStatusType
    {
        [Description("No Status")] NoStatus = 0,
        [Description("Email to SubContractor")] EmailToSubContractor = 1,
        [Description("Propose Date to Occupant")] ProposeDateToOccupant = 2,
        [Description("Confrim Date to SubContractor")] ConfrimDateToSub = 3,
        [Description("Inform of Action Date")] InformOfActionDate = 4,
        [Description("Follow Up")] FollowUp = 5,
        [Description("SubContractor not Responding")] SubNotResponding = 6,
        [Description("Occupant not Responding")] OccupantNotResponding = 7,
        [Description("On Hold")] OnHold = 8
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ActionByNotEcType
    {
        [Description("No Type")] NoType = 0,
        [Description("Architect")] Architect = 1,
        [Description("Engineer Stab")] EngineerStab = 2,
        [Description("Engineer Tech")] EngineerTech = 3,
        [Description("Client")] Client = 4
    }
}