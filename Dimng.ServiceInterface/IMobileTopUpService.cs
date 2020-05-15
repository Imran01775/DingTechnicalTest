
using System.Xml.Linq;

namespace Dimng.ServiceInterface
{
    public interface IMobileTopUpService
    {
        byte[] MobileTopUp(XElement xml);
    }
}
