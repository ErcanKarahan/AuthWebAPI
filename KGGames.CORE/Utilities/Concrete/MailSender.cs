using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KGGames.CORE.Utilities.Concrete
{
    public static class MailSender
    {
        public static void Send(string? receiver, string? password = "1453.melek", string? body = "Üyelik Aktivasyonu", string? subject = "Hesap Aktivasyon", string? sender = "emregoren98@yandex.com")
        {

            MailAddress senderEmail = new MailAddress(sender);

            MailAddress receiverEmail = new MailAddress(receiver);


            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };




            using (var mesaj = new MailMessage(senderEmail, receiverEmail)
            {
                //Object initializer
                Subject = subject,
                Body = body
            })
            {
                //using scope'u
                smtp.Send(mesaj);
            }




        }
    }
}
