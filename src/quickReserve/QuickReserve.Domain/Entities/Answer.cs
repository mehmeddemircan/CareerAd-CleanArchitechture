using QuickReserve.Domain.Common;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class Answer : BaseEntity
    {
    
        public string Response { get; set; }  // Cevap metni

        public int QuestionId { get; set; } // cevap verilen soru 
        public virtual Question Question { get; set; }

        public int UserId { get; set; }  // Cevabı veren kullanıcı
        public virtual User User { get; set; }
    }
}
