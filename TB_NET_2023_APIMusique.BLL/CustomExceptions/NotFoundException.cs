using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.BLL.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? Message) : base(Message)
        {
            
        }
    }
}
