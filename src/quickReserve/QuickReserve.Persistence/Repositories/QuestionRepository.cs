using Core.Persistence.Repositories;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.Repositories
{
    public class QuestionRepository : EfBaseRepository<Question, BaseDbContext>, IQuestionRepository
    {
        public QuestionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
