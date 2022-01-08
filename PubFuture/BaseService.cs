using PubFuture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubFuture
{
    public class BaseService
    {
        private readonly WebContext WebContext;

        public BaseService(WebContext webContext)
        {
            WebContext = webContext;
        }
    }
}
