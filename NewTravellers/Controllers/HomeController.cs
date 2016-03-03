using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewTravellers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string fromDate, string room, string phone)
        {
            try
            {
                //MailMessage mailMessage = new MailMessage()
                //{

                //    Subject = "Booking Requested",
                //    Body =
                //        string.Format(
                //            "A user has requested booking from travellerslodge.com.ng\nThe details of the booking is as " +
                //            "given below:\nDesired Date: {0}\nRoom Type: {1}\nCustomer Contact: {2}",
                //            fromDate, room, phone),
                //    IsBodyHtml = false

                //};

                //mailMessage.To.Add(new MailAddress("bookings@travellerslodge.com.ng"));
                //SmtpClient smtpClient = new SmtpClient();
                //await smtpClient.SendMailAsync(mailMessage);
                string from = "info@travellerslodge.com.ng";
                using (var email = new MailMessage(from, "bookings@travellerslodge.com.ng"))
                {
                    email.Subject = "Booking Requested";
                    email.Body = string.Format(
                        "A user has requested booking from travellerslodge.com.ng\nThe details of the booking is as " +
                        "given below:\nDesired Date: {0}\nRoom Type: {1}\nCustomer Contact: {2}",
                        fromDate, room, phone);
                    email.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    await smtp.SendMailAsync(email);
                }
                ViewBag.Message = "Thanks for submitting a request. Booking submitted successfully";
                ViewBag.Status = "SUCCESS";
            }
            catch (Exception e)
            {
                ViewBag.Message = "An error occured: "+e.Message;
                ViewBag.Status = "ERROR";
                /**/
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Rooms()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(string name, string mail, string phone, string subject, string message)
        {
            try
            {
                string from = "info@travellerslodge.com.ng";
                using (var email = new MailMessage(from, "enquiry@travellerslodge.com.ng"))
                {
                    email.Subject = "Booking Requested";
                    email.Body = string.Format(
                        "A user has filled the contact us form on travellerslodge.com.ng\nThe details is as " +
                        "given below:\nFull Name: {0}\nE-Mail: {1}\nContact: {2}\nSubject: {3}\nMessage: {4}",
                        name, mail, phone, subject, message);
                    email.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    await smtp.SendMailAsync(email);
                }
                ViewBag.Message = "Thanks for sending us a message. Your message has been received and necessary actions would be taken. Our rep would contact you soon if need be.";
                ViewBag.Status = "SUCCESS";
            }
            catch (Exception e)
            {
                ViewBag.Message = "An error occured: " + e.Message;
                ViewBag.Status = "ERROR";
                /**/
            }
            return View();
        }
    }
}
