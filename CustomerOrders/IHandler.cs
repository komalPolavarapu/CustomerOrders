using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrders
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(Request request);
    }
}
