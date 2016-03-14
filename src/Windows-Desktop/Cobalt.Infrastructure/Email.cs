using System;
using System.Collections.Generic;
using SendGrid;
using System.Net.Mail;

namespace Cobalt.Infrastructure
{
    public class Email
    {
        /// <summary>
        /// Send a new custom email.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        public void SendEmail(string from, IEnumerable<string> to, string subject, string text)
        {
            try
            {
                var newMessage = new SendGridMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Text = text
                };

                newMessage.AddTo(to);

                var transportWeb = new Web(Keys.SendGrid);
                transportWeb.DeliverAsync(newMessage).Wait();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
