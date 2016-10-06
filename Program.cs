/*

This is a Mono.Net C# Compatible file. It runs on a Linux server and checks and sends a file when a new D-Star User signs up on W8HHF

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDStarUsersCheckAndSendEmail
{
    class Program
    { 
        static void Main(string[] args)
        {
            if (System.IO.File.Exists(new System.Configuration.AppSettingsReader().GetValue("NewUserDStarFileToCheck", System.Type.GetType("System.String")).ToString()))
            {
                string tmp = System.IO.File.ReadAllText(new System.Configuration.AppSettingsReader().GetValue("NewUserDStarFileToCheck", System.Type.GetType("System.String")).ToString());
                if (tmp.Contains("(0 rows)"))
                {
                    //do nothing - no new people
                }
                else
                {
                    SendEmail(new System.Configuration.AppSettingsReader().GetValue("PeopleToEmail", System.Type.GetType("System.String")).ToString());
                    if (Convert.ToBoolean(new System.Configuration.AppSettingsReader().GetValue("DeleteFileAfterEmailSent", System.Type.GetType("System.Boolean"))))
                    {
                        try
                        {
                            System.IO.File.Delete(new System.Configuration.AppSettingsReader().GetValue("NewUserDStarFileToCheck", System.Type.GetType("System.String")).ToString());
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        static private void SendEmail(string List)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("website@zackburns.com", List, "New W8HHF D-Star User Registration", "Attached is a list of new user registrations.  Please login to the W8HHF D-Star Gateway and register them and send the welcome email.");
            message.Attachments.Add(new System.Net.Mail.Attachment(new System.Configuration.AppSettingsReader().GetValue("NewUserDStarFileToCheck", System.Type.GetType("System.String")).ToString()));
            System.Net.Mail.SmtpClient cli = new System.Net.Mail.SmtpClient("localhost", 25);
            cli.Send(message);
        }
    }
}
