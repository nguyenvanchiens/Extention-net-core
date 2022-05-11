using Manager.Mail;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    public class DemoSendMailController : Controller
    {
        public async Task<IActionResult> Index()
        {
            MailContent mailContent = new MailContent();
            mailContent.To = "indothang@gmail.com";
            mailContent.Subject = "Mời phỏng vấn";
            mailContent.Body = "<h1>hello</h1>";
            

            await MailUtilis.SendGmail("indothang@gmail.com", "nguyenvanvinhhy2k@gmail.com", "Thư mời phỏng vấn", "<h1>hello bạn</h1>", "indothang@gmail.com", "Chien12a5");
            return Ok();
        }
    }
}
