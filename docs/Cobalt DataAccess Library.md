# Cobalt DataAccess Library

The Cobalt data access library contatins repositoires and POCO objcets for talking with the database. 
Cobalt uses Entity Framework 6 with a code first approach. Logic should **not** be contained within the repositories or POCO objects.

Each POCO object contains DataAnnotation attributes.

```csharp
public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(125)]
        public string FirstName { get; set; }

        [MaxLength(125)]
        public string LastName { get; set; }

        [MaxLength(125)]
        public string Street { get; set; }

        [MaxLength(125)]
        public string Number { get; set; }

        [MaxLength(125)]
        public string Email { get; set; }

        [MaxLength(125)]
        public string Phone { get; set; }

        [EnumDataType(typeof(ContactTypes))]
        public ContactTypes ContactType { get; set; } = 0;

        [NotMapped]
        public string Address => Street + " " + Number;
    }

    public enum ContactTypes
    {
        NoType = 0,
        Client = 1,
        Occupant = 2,
        SubContractor = 3,
        Architect = 4,
        ProjectManager = 5
    }
```
