using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.BLL.CustomExceptions
{
    public class AlreadySingingException : Exception
    {
        public AlreadySingingException(string? Message) : base(Message)
        {
            
        }
    }
}
