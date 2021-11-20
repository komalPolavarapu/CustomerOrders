
namespace CustomerOrders
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(Request request);
    }
}
