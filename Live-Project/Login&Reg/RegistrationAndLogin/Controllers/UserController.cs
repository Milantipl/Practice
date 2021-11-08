using System;
using System.Net;
using System.Web;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using RegistrationAndLogin.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RegistrationAndLogin.Controllers
{
    public class UserController : Controller
    {

        /* 
         @ Function Registration
         @ Author : Milan Naliyapara
         @ Date : 04-11-2021
         @ Description : User Register with email id
         @ AdditionalCheck : Null
         @ Return : Login page after register
         */
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        /* 
         @ Function Registration
         @ Author : Milan Naliyapara
         @ Date : 04-11-2021
         @ Description : In the background process generate otp , checking mail exist , activetion code generate , password encripted and send mail to verify otp
         @ AdditionalCheck : Null
         @ Return : Send Mail To User For OTP
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "EmailVerification, ActivetionCode, otp")] UserM user)
        {
            Random rdm = new Random();
            int otp = Convert.ToInt32(rdm.Next(100000, 999900).ToString());
            bool Status = false;
            string message = "";
         
            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already Exist");
                    return View(user);
                }

                user.ActivetionCode = Guid.NewGuid();
                user.VeryOtp = otp;
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                user.EmailVerification = false;

                using ( MyModel dc = new MyModel())
                {
                    dc.UserMs.Add(user);
                    dc.SaveChanges();
                    SendVerificationLinkOtp(user.Email, otp);
                    message = "Registration Successfully Done. Account activation link " + " has been sent to your email address: " + user.Email;   
                    Status = true;
                    Session["Email"] = user.Email;
                }
                return RedirectToAction("VerifyOtp");
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        /* 
         @ Function VerifyAccount
         @ Author : Milan Naliyapara
         @ Date : 04-11-2021
         @ Description : Matching activetion code with mail id and change status true active account after verify
         @ AdditionalCheck : Null
         @ Return : Activate
         */
        [HttpGet]
        public ActionResult VerifyAccount(string  id)
        {
            bool Status = false;
            using (MyModel dc = new MyModel())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var v = dc.UserMs.Where(a => a.ActivetionCode == new Guid(id)).FirstOrDefault();
                if(v.Email.Length>0)
                {
                    v.EmailVerification = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
                return View();
        }

        /* 
        @ Function GenerateOTP
        @ Author : Milan Naliyapara
        @ Date : 04-11-2021
        @ Description : Generate random number between 100000 to 999900
        @ AdditionalCheck : Null
        @ Return : 6 digit random number
        */
        public int GenerateOTP()
        {
            Random rdm = new Random();
            string otp = rdm.Next(100000, 999900).ToString();
            return Convert.ToInt32(otp);
        }

        /* 
        @ Function VerifyOtp
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description : Verify otp when user enter and if user did't get otp to send resend otp
        @ AdditionalCheck : Null
        @ Return : otp verify and resend
        */
        [HttpGet]
        public ActionResult VerifyOtp(string text)
        {
            if (text == "process")
            {
                resendOtp();
                return View();
            }
           
            return View();
        }

        /* 
        @ Function VerifyOtp
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description : check user is valid or not if user is valid directly go to welcome page 
        @ AdditionalCheck : Null
        @ Return : redirect to welcome page
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerifyOtp(UserM login, string text)
        {
            String message = "";
            int userenterotp = Convert.ToInt32(login.VeryOtp);
            if (userenterotp == 0)
            {
                resendOtp();
                return View();
            }

            if (IsValidUser(userenterotp))
            {
                
                return RedirectToAction("welcomre");
            }
            

            return View();
        }

        /* 
        @ Function resendOtp
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description :  check the mail id in the store session and match with database then send otp again on mail
        @ AdditionalCheck : Null
        @ Return : send otp again on same mail id
        */
        public void resendOtp()
        {
            string _Email = Session["Email"].ToString();
            int _Otp = GenerateOTP();
          
            using (MyModel dc = new MyModel())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var v = dc.UserMs.Where(a=> a.Email == _Email).FirstOrDefault();
                v.VeryOtp = _Otp;
                dc.SaveChanges();
                SendVerificationLinkOtp(_Email, _Otp);
            }
        }

        /* 
        @ Function IsValidUser
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : change email verification status after user enter otp is right
        @ AdditionalCheck : Null
        @ Return : is valid or not
        */
        private bool IsValidUser(int otp)
        {
            String message = "";
            string mail = Session["Email"].ToString();
            bool IsValid = false;
            using (MyModel dc = new MyModel())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var v = dc.UserMs.Where(a => a.Email == mail).FirstOrDefault();
                if(v.VeryOtp==otp)
                {
                    v.EmailVerification = true;
                    dc.SaveChanges();
                    IsValid = true;   
                }
                else
                {
                    ViewBag.Message = "Please Enter The Right OTP";
                }
            }

            return IsValid;
        }

        /* 
        @ Function welcomre
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : This is welcome page to show your registration is Successful
        @ AdditionalCheck : Null
        @ Return : Successful Or Not
        */
        [HttpGet]
        public ActionResult welcomre()
        {
            return View();
        }

        /* 
        @ Function Login
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : Login with registerd mail id and password
        @ AdditionalCheck : Null
        @ Return : Index Page in Home Controller
        */
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /* 
        @ Function Login
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : checking user enter mail id exist and it's verified or not then checked password
        @ AdditionalCheck : Null
        @ Return : index page
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            String message = "";
           
            using ( MyModel dc = new MyModel())
            {
                var v = dc.UserMs.Where(a => a.Email == login.EmailID && a.EmailVerification == true).FirstOrDefault();
                if(v != null)
                {
                  
                    if (String.Compare(Crypto.Hash(login.Password), v.Password ) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //if remember me then it should be stored for 1 yr ie 525600 min, else save for 20min
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true; //if doesn't want toacess it from JS.
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {

                            return Redirect(ReturnUrl);

                        }
                        else
                        {
                            Session["Email"] = login.EmailID;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid Password";
                    }
                }
                else
                {
                    message = "Invalid or Not Varified Email";
                }
              
            }
                ViewBag.Message = message;
            return View();
        }


        /* 
        @ Function Logout
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description : Remove session and logout the current page
        @ AdditionalCheck : Null
        @ Return : login page
        */
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        /* 
        @ Function IsEmailExist
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description : check the mail id is already register or not
        @ AdditionalCheck : Null
        @ Return : Mail Exist or not
        */
        [NonAction]
        public bool IsEmailExist(string emailID)
            {
                using (MyModel dc = new MyModel())
                {
                    var v = dc.UserMs.Where(a => a.Email == emailID).FirstOrDefault();
                    return v != null;
                }
            }


        /* 
        @ Function SendVerificationLinkOtp
        @ Author : Milan Naliyapara
        @ Date : 05-11-2021
        @ Description : Send otp to user mail id 
        @ AdditionalCheck : Null
        @ Return : Otp
        */
        [NonAction]
        public void SendVerificationLinkOtp(String email, object otp,  string emailFor = "VerifyAccount")
        {
            
            var verifyUrl = " / User / " + emailFor + " / ";
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var formEmail = new MailAddress("tathyainfotechtest@gmail.com", "Tathya Infotech");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "Tipl@12345!";

            string subject = " ";
            string body = " ";
            if (emailFor == "VerifyAccount")
            {
                subject = "Verify OTP";
                body = "<br/><br/>Your One Time Password Is - " + "<a href='" + otp + "'>" + otp + "</a>";
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(formEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(formEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);

        }

        /* 
        @ Function SendVerificationLinkEmail
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : Send link to on registerd mail for reset password 
        @ AdditionalCheck : Null
        @ Return : Link
        */
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string ActivetionCode, string emailFor = "VerifyAccount")
        {

            var verifyUrl = "/User/"+emailFor+"/" + ActivetionCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("tathyainfotechtest@gmail.com", "Tathya Infotech");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "Tipl@12345!";
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";

                body = "<br><br>Your account is" + " Successfully created. Please click on the below link to verify your account " + "<br><br><a href='" + link + "'>" + link + "</a>";
            }
            else if(emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi! <br> <br>We got request for reset your account password. Please click on the link below to reset your password"+"<br><br><a href="+link+">Reset Password Link</a>";
            }
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod= SmtpDeliveryMethod.Network,
                UseDefaultCredentials =  false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,

            })
                smtp.Send(message);
        }

        /* 
        @ Function ForgotPassword
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : find the mail id where registerd mail and reset code generate and then change the password 
        @ AdditionalCheck : Null
        @ Return : Forgot password link
        */
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {
            string message = "";
            bool status = false;

            using (MyModel dc = new MyModel())
            {
                var account = dc.UserMs.Where(a => a.Email == Email).FirstOrDefault();
                if(account != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                    account.OTP = resetCode;
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Reset Password Link has been sent to your email address.";
                }
                else
                {
                    message = "Account Not Found.";
                }
            }

            ViewBag.Message = message; 
            return View();
        }

        /* 
        @ Function ResetPassword
        @ Author : Milan Naliyapara
        @ Date : 06-11-2021
        @ Description : chenge password with activation code match after link generate and match the activation code
        @ AdditionalCheck : Null
        @ Return : Link with activation code
        */
        public ActionResult ResetPassword(string id)
        {
            using (MyModel dc = new MyModel())
            {
                var user = dc.UserMs.Where(a => a.OTP == id).FirstOrDefault();
                if( user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (MyModel dc = new MyModel())
                {
                    var user = dc.UserMs.Where(a => a.OTP == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.OTP = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something Invalid.";
            }

            ViewBag.Message = message;
            return View(model);
        }
    }
}