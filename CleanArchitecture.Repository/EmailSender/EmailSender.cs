using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.InfraStructure.EmailSender
{
    internal class EmailSender
    {
       // public static async Task SendEmail(string ToEmail, string Content, string Subject)
       // {
       //     EmailConfiguration EmailConfiguration = new EmailConfiguration()
       //     {
       //         From = "refoo@outlook.com",
       //         SmtpServer = "smtp-mail.outlook.com",
       //         Port = 587,
       //         UserName = "refoo@outlook.com",
       //         Password = "@123Rafeek"
       //     };
       //     EmailSender EmailSender = new EmailSender(EmailConfiguration);
       //     var toList = new List<MailboxAddress>();
       //     toList.Add(new MailboxAddress("test", ToEmail));
       //     Message Message = new Message(toList, Subject, Content, null);
       //     await EmailSender.SendEmailAsync(Message);

       // }

       // public async static Task<bool> SendEmailAttachment(List<MailboxAddress> mailTo, MailboxAddress mailFrom, List<MailboxAddress> ccList, string subject, string message,
       //List<MailAttachment> attachments, string UserName, string Password, string host, int port, bool useOffice365)
       // {
       //     var emailMessage = new MimeMessage();

       //     if (ccList.Count() > 0)
       //     {
       //         foreach (var address in ccList)
       //         {
       //             emailMessage.Cc.Add(address);
       //         };
       //     }

       //     if (mailTo.Count() > 0)
       //     {
       //         foreach (var to in mailTo)
       //         {
       //             emailMessage.To.Add(to);
       //         }
       //     }

       //     //emailMessage.Sender = mailFrom;
       //     emailMessage.From.Add(mailFrom);

       //     emailMessage.Subject = subject;
       //     var builder = new BodyBuilder();
       //     builder.HtmlBody = message;

       //     //Fetch the attachments from db
       //     //considering one or more attachments
       //     if (attachments.Any())
       //     {
       //         foreach (var data in attachments)
       //         {
       //             Stream stream = new MemoryStream(data.File);
       //             builder.Attachments.Add(data.FileName, stream, MimeKit.ContentType.Parse(MediaTypeNames.Image.Jpeg));
       //         }
       //     }
       //     emailMessage.Body = builder.ToMessageBody();
       //     using (var client = new SmtpClient())
       //     {
       //         var credentials = new NetworkCredential
       //         {
       //             UserName = UserName,
       //             Password = Password
       //         };
       //         await client.ConnectAsync(host, port, false).ConfigureAwait(false);
       //         await client.AuthenticateAsync(credentials);
       //         await client.SendAsync(emailMessage).ConfigureAwait(false);
       //         await client.DisconnectAsync(true).ConfigureAwait(false);
       //     }
       //     return true;

       // }
       // public class MailAttachment
       // {
       //     public string FileName { get; set; }
       //     public byte[] File { get; set; }
       // }
    }
   

}
