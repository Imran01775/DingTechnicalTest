using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Reflection;
using System.Net;

namespace Ding.Domain
{
    public static class ConvertObjectModel
    {
        public static string ConvertModelToXml(this RequestToXmlModel requestXmlModel)
        {
            //foreach (PropertyInfo property in requestModel.GetType().GetProperties())
            //{
            //    object value1 = property.GetValue(requestModel, null);

            //}
            if (requestXmlModel == null)
            {
                return string.Empty;
            }
            try
            {
                XElement xmlFormatData = new XElement("RequestModelRoot",

                                    new XElement("Header", new XElement("Identifier", requestXmlModel.Header.Identifier),
                                                    new XElement("MessageDate", requestXmlModel.Header.MessageDate),
                                                    new XElement("MessageTime", requestXmlModel.Header.MessageTime)),
                                    new XElement("Body", new XElement("MessageID", requestXmlModel.Body.MessageID),
                                                    new XElement("PhoneNumber", requestXmlModel.Body.PhoneNumber),
                                                    new XElement("Amount", requestXmlModel.Body.Amount))


   );
                return xmlFormatData.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        public static TModel ConvertXmlToModel<TModel>(this XElement xml)
        {

            var serializer = new XmlSerializer(typeof(TModel));
            var innerHtmlValue = XElement.Parse(xml.ToString()).Value;
            using (TextReader reader = new StringReader(innerHtmlValue))
            {
                return (TModel)serializer.Deserialize(reader);
            }

        }

        public static byte[] ObjectToByteArray<TModel>(this TModel model)
        {
            if (model == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, model);
                return ms.ToArray();
            }
        }

        public static TModel ByteArrayToOject<TModel>(this byte[] byteArray)
        {
            if (byteArray == null)
                return default(TModel);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                object convertObject = bf.Deserialize(ms);
                return (TModel)convertObject;
            }
        }
        public static RequestToXmlModel ConvertRequestToXmlModel(this RequestModel requestModel)
        {
            var xmlModel = new RequestToXmlModel
            {
                Header = new Header
                {
                    Identifier = requestModel.Identifier
                },
                Body = new Body
                {
                    Amount = requestModel.Amount,
                    MessageID = requestModel.MessageID,
                    PhoneNumber = requestModel.PhoneNumber,
                }
            };
            return xmlModel;
        }
        public static RequestModel ConvertXmlToRequestModel(this RequestToXmlModel xmlModel)
        {
            var requestModel = new RequestModel();
            requestModel.Amount = xmlModel.Body.Amount;
            requestModel.MessageID = xmlModel.Body.MessageID;
            requestModel.PhoneNumber = xmlModel.Body.PhoneNumber;
            return requestModel;
        }
        public static string ResponseStatus(this object code)
        {
            if ((int)code == (int)HttpStatusCode.OK)
                return "01";
            if ((int)code == (int)HttpStatusCode.InternalServerError)
                return "99";
            else
                return "999";
        }
    }
}
