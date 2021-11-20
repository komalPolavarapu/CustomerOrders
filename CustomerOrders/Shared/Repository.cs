using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public enum OrderType
    {
        Repair, 
        Hire
    }

    public enum  OrderStatus
    {
        Confirmed,
        Closed,
        AuthorisationRequired
    }
}
