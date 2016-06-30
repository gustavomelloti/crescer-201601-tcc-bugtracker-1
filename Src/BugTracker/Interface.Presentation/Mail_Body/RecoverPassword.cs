﻿using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Mail_Body
{
    public static class RecoverPassword
    {
        private static IMailService mail = MailServiceInjection.Create();

        private static IUserRecoveryService userRecoveryService = UserRecoveryServiceInjection.Create();

        public static void SendTo(User user)
        {
            userRecoveryService.Add(new UserRecovery(user, DateTime.Now, RecoverPassword.SendTo(user.Email)));
        }

        private static string SendTo(string mailTo)
        {
            string code = Guid.NewGuid().ToString() + new Random().Next(1000).ToString();

            string body =
                "<div>" +
                    "<div style=\"width: 85%;text-align: center;margin: 0 auto;background-color: #d4d8b4;\">" +
                        "<div>" +
                            "<div style=\"background-image:url('http://ap.imagensbrasil.org/images/logo-m.png');width: 170px;height: 231px;background-position: center;background-repeat: no-repeat;display:inline-block;margin-bottom:50px;\"></div>" +
                        "</div>" +
                        "<div>" +
                            "<div style=\"background-image:url('http://ap.imagensbrasil.org/images/bannera6c48.png');height: 230px;width: 850px;background-position: center;background-repeat: no-repeat;display:inline-block;margin-bottom:50px;\"></div>" +
                        "</div>" +
                        "<div>" +
                            "<h1 style=\"color: #005f2b;\">SET A NEW BUGTRACKER ACCOUNT PASSWORD</h1>" +
                        "</div>" +
                        "<div>" +
                            "<p><a href=\"http://localhost:58173/userrecovery/code?code=" + code + " \">Click here</a> to change it</p>" +
                        "</div>" +
                        "<div>" +
                            "<footer style=\"background-color: #200303;width: 100%;margin-top: 20px;padding: 15px 0;\">" +
                                "<p style=\"color: #d4d8b4;\">BugTracker LTDA.   21554 N. Northsight Blvd.  Suite 205  Scottsdale,  AZ   85260   Brazil</p>" +
                            "</footer>" +
                        "</div>" +
                    "</div>" +
                "</div>";

            mail.Send(mailTo, "Activation of BugTracker account", body, true);

            return code;
        }
    }
}