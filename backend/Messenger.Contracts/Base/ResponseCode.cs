using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Contracts.Base
{
    public enum ResponseCode : byte
    {
        OK,
        NotFound,
        Error
    }
}
