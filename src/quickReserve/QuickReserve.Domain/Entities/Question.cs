using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }  // Sorunun metni
        public string QuestionType { get; set; } //input , radio , checkbox , text area
        public int JobAdFormId { get; set; }
        public virtual JobAdForm JobAdForm { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
