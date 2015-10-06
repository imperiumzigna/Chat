using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Chat.Models;

namespace Chat
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // Para permitir que os usuários deste site façam logon em suas contas a partir de outros sites, como Microsoft, Facebook e Twitter,
            // é necessário atualizar este site. Para obter mais informações, acesse http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
               appId: "703609803072492",
               appSecret: "5160507643a9dee293b3ad24db1ac6ed");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
