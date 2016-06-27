﻿using Interface.Presentation.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Services
{
    public static class UserSessionService
    {
        private const string LOGGED_USER = "LOGGED_USER";
        private const string COOKIE = "COOKIE_AUTHENTICATION";

        private static Dictionary<string, string> loggedUsers = new Dictionary<string, string>();

        public static LoggedUserViewModel LoggedUser
        {
            get
            {
                return (LoggedUserViewModel) HttpContext.Current.Session[LOGGED_USER];
            }
        }

        public static bool IsLogged
        {
            get
            {
                if (LoggedUser != null)
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(COOKIE);

                    return cookie != null ? loggedUsers.Any(u => u.Key.Equals(cookie.Value) &&
                                           u.Value.Equals(LoggedUser.Email)) : false;
                }
                return false;
            }
        }

        public static void CreateSession(LoggedUserViewModel user)
        {
            string tokenNumber = Guid.NewGuid().ToString();
            loggedUsers.Add(tokenNumber, user.Email);

            HttpContext.Current.Session[LOGGED_USER] = user;
            var cookieAuth = new HttpCookie(COOKIE, tokenNumber);

            HttpContext.Current.Response.Cookies.Set(cookieAuth);

        }
    }
}