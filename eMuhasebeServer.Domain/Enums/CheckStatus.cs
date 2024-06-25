<<<<<<< HEAD
﻿namespace eMuhasebeServer.Domain.Enums;
=======
﻿using Ardalis.SmartEnum;
using Microsoft.EntityFrameworkCore;

namespace eMuhasebeServer.Domain.Enums;
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3


public enum CheckStatus
{
    Paid = 1,
    Unpaid = 2,
    Endorsed = 3,
    Returned = 4,
    Banked = 5,
    SendToBankForCollateral = 6,
    InPortfolio = 7
}
