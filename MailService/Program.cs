using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("getdelays@gmail.com", "userfordelays");
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mm = new MailMessage("getdelays@gmail.com", "nathan.pire@hotmail.com", "Votre train De Charleroi Sud vers Fleurus a du retard", "Bonjour, votre train pour 10h De Charleroi-Sud vers Fleurus accumule déjà plus de 5 minutes de retard. vous pouvez vous rendre sur cette page pour voir en direct l'évolution des retards sur votre ligne.");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}
