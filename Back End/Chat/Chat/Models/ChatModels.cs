using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Runtime.Serialization;

namespace Chat.Models
{
    [Table("Mensagem")]
    public class Mensagem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MensagemId { get; set; }
        public string Usuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime? Hora { get; set; }
        public virtual Conversa Conversa { get; set; }
        
        public Mensagem()
        {
        }

        public Mensagem(string u, string c, DateTime? h)
        {
            Usuario = u;
            Conteudo = c;
            Hora = h;
             
        }
    }

    [Table("Conversa")]
    public class Conversa
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ConversaId { get; set; }
        public string Usuario { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public Conversa()
        {
            Mensagens = new List<Mensagem>();
        }

        public Conversa(string u)
        {
            Mensagens = new List<Mensagem>();
            Usuario = u;
        }
    }

    [DataContract]
    public class MensagemJson
    {
        [DataMember]
        public int MensagemId { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Conteudo { get; set; }
        [DataMember]
        public DateTime? Hora { get; set; }

        public MensagemJson()
        {
        }

        public MensagemJson(string u, string c, DateTime? h)
        {
            Usuario = u;
            Conteudo = c;
            Hora = h;
        }
    }

    [DataContract]
    public class ConversaJson
    {
        [DataMember]
        public int ConversaId { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public IEnumerable<MensagemJson> Mensagens { get; set; }

        public ConversaJson()
        {
            Mensagens = new List<MensagemJson>();
        }

        public ConversaJson(string u, IEnumerable<MensagemJson> m)
        {
            Mensagens = m;
            Usuario = u;
        }
    }
}
