using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.Entities.EntityEnums.UserStatus
{
    public enum UserStatusType:byte
    {
        passive=3,
        active=5,
        banned=7,
        restricted=9,
    }
}
