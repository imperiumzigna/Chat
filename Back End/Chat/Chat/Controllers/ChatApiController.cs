using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using Chat.Models;

namespace Chat.Controllers
{
    [Authorize]
    public class ChatApiController : Controller
    {
        UsersContext db = new UsersContext();

        //Envia uma mensagem para um usuário
        [HttpPost]
        public ActionResult Send(string username, string mensagem)
        {
            if (username == null || mensagem == null)
            {
                return HttpNotFound();
            }

            // Insere usuário na base
            UserProfile user = db.UserProfiles.FirstOrDefault(x => x.UserName == username);
            UserProfile i = db.UserProfiles.FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (user != null)
            {
                Conversa minhaconversa = i.Conversas.FirstOrDefault(x => x.Usuario == username);
                Conversa userconversa = user.Conversas.FirstOrDefault(x => x.Usuario == i.UserName);

                if (minhaconversa == null)
                {
                    minhaconversa = new Conversa(username);
                    i.Conversas.Add(minhaconversa);
                }

                if (userconversa == null)
                {
                    userconversa = new Conversa(i.UserName);
                    user.Conversas.Add(userconversa);
                }

                //Mensagem msg = new Mensagem(i.UserName, mensagem, DateTime.Now);
                minhaconversa.Mensagens.Add(new Mensagem(i.UserName, mensagem, DateTime.Now));
                userconversa.Mensagens.Add(new Mensagem(i.UserName, mensagem, DateTime.Now));
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }

            return HttpNotFound();
        }

        //Recebe todas as mensagens do usuário logado (em formato JSON)
        [HttpGet]
        public ActionResult ReceiveAll()
        {
            UserProfile user = db.UserProfiles.FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (user != null)
            {
                object jsonlist = user.Conversas.Select(x=>new ConversaJson(x.Usuario, x.Mensagens.Select(y => new MensagemJson(y.Usuario,y.Conteudo, y.Hora))));
                return Json(jsonlist, JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();
        }
    }
}
