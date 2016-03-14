using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cobalt.DataAccess.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public MailAddress Email { get; set; }
    }
}
