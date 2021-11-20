
namespace CustomerOrders
{
    public class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual object Handle(Request request)
        {
            if(this._nextHandler!=null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;

            return handler;
        }
    }
}
