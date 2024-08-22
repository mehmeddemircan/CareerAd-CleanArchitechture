
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Users.Models
{
    public class UserListModel : BasePageableModel
    {
        public IList<UserListDto> Items { get; set; }
    }
}
