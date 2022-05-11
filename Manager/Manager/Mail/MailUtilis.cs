using System.Net;
using System.Net.Mail;

namespace Manager.Mail
{
    public class MailUtilis
    {
        public static async Task SendMail(string _from, string _to, string _subject, string _body)
        {
            MailMessage message = new MailMessage(_from,_to,_subject,_body);// khởi tạo đối tượng
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;//cho phép body dùng html css

            message.ReplyToList.Add(new MailAddress(_from));// khi phản hồi gửi về email nào
            message.Sender = new MailAddress(_from);// thiết lập thông tin người gửi
            
            using var smtlCline = new SmtpClient("localhost");//khởi tạo gửi đi
            try
            {
               await smtlCline.SendMailAsync(message);
                Console.WriteLine("Success");
            }
            catch (Exception)
            {
                Console.WriteLine("Messsage");
                throw;
            }

        }
        public static async Task SendGmail(string _from, string _to, string _subject, string _body, string _gmail, string _password)
        {
            MailMessage message = new MailMessage(_from,_to,_subject,_body);// khởi tạo đối tượng
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;//cho phép body dùng html css

            message.ReplyToList.Add(new MailAddress(_from));// khi phản hồi gửi về email nào
            message.Sender = new MailAddress(_from);// thiết lập thông tin người gửi
            
            using var smtlCline = new SmtpClient("smtp.gmail.com");//khởi tạo gửi đi
            smtlCline.Port = 587;
            smtlCline.EnableSsl = true;
            smtlCline.Credentials = new NetworkCredential(_gmail, _password);
            try
            {
               await smtlCline.SendMailAsync(message);
                Console.WriteLine("Success");
            }
            catch (Exception)
            {
                Console.WriteLine("Messsage");
                throw;
            }

        }

    }
}
