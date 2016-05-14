using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cobalt.Infrastructure.Converters;
using Prism.Mvvm;

namespace Cobalt.DataAccess.Models
{
    public class Contact : BindableBase
    {
        private Address _address;
        private int _addressId;
        private int _contactId;
        private ContactTypes _contactType = 0;
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _phone;

        [Key]
        public int ContactId
        {
            get { return _contactId; }
            set
            {
                _contactId = value;
                OnPropertyChanged();
            }
        }

        [ForeignKey("Address")]
        public int AddressId
        {
            get { return _addressId; }
            set
            {
                _addressId = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        [EnumDataType(typeof(ContactTypes))]
        public ContactTypes ContactType
        {
            get { return _contactType; }
            set
            {
                _contactType = value;
                OnPropertyChanged();
            }
        }

        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (LastName != null)
                {
                    return LastName + ", " + FirstName;
                }
                return FirstName;
            }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ContactTypes
    {
        [Description("No Type")] NoType = 0,
        [Description("Client")] Client = 1,
        [Description("Occupant")] Occupant = 2,
        [Description("SubContractor")] SubContractor = 3,
        [Description("Architect")] Architect = 4,
        [Description("Project Manager")] ProjectManager = 5
    }
}