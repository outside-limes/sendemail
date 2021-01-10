using emailApi.emailLogic;
using emailApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace emailApi.Controllers
{
    public class emailcontroller : Controller
    {
        [HttpPost]
        public ActionResult<bool> Send([FromBody] jsonObject JsonObject)
        {
            sendemail send = new sendemail();

            send.SendMail(JsonObject.fromEmail, JsonObject.toAddress, JsonObject.subject, JsonObject.body);

            return true;
        }
    }
}
