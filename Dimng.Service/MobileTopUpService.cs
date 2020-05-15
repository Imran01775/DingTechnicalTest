using Dimng.Service.Helpers;
using Dimng.ServiceInterface;
using Ding.Domain;
using System;
using System.Net;
using System.Xml.Linq;

namespace Dimng.Service
{
    public class MobileTopUpService : IMobileTopUpService
    {
        public static int TransactionID = 1025;
        public static int TransactionNumber = 1030;
        public byte[] MobileTopUp(XElement xml)
        {
            try
            {
                if (xml == null)
                    throw new CustomHttpException(400, "Bad Request");
                var requestXmlModelData = xml.ConvertXmlToModel<RequestToXmlModel>();
                var requestModelData = requestXmlModelData.ConvertXmlToRequestModel();
                var responseModel = new ResponseModel
                {

                    Amount = requestModelData.Amount,
                    PhoneNumber = requestModelData.PhoneNumber,
                    TransactionID = TransactionID++,
                    TransactionNumber = TransactionNumber++,
                    Result = HttpStatusCode.OK.ResponseStatus()   //manage it mannual
                };
                var responseByte = responseModel.ObjectToByteArray<ResponseModel>();
                return responseByte;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
