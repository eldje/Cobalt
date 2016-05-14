using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Prism.Mvvm;

namespace Cobalt.DataAccess.Models
{
    public class Address : BindableBase
    {
        private int _addressId;
        private string _constructionAddress;
        private string _number;
        private string _street;

        [Key]
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
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        [MaxLength(125)]
        public string ConstructionAddress
        {
            get { return _constructionAddress; }
            set
            {
                _constructionAddress = value;
                OnPropertyChanged();
            }
        }

        [NotMapped]
        public string FullAddress => Street + " " + Number;
    }
}