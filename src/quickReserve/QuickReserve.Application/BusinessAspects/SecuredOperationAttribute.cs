using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessAspects
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class SecuredOperationAttribute : TypeFilterAttribute
    {
        public SecuredOperationAttribute(string roles) : base(typeof(SecuredOperationFilter))
        {
            Arguments = new object[] { roles };
        }
    }
}
