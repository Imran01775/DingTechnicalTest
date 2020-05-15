using Ding.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DingConsole
{
    public static class Communication
    {

        public static async Task<ResponseModel> ProcessTopup(RequestModel requestModel)
        {
            //ModelState Valid 
            var responseData = new ResponseModel();
            var requestXmlFormatModel = requestModel.ConvertRequestToXmlModel();
            var requestModelToXml = requestXmlFormatModel.ConvertModelToXml();
            var responseAPIData = await Send(requestModelToXml);
            var outputData = responseAPIData.ByteArrayToOject<ResponseModel>();
            return outputData;
        }
        public static async Task<byte[]> Send(string value)
        {
            try
            {
                byte[] responseData = null;
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(EnvironmentModel.URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsXmlAsync("api/MobileTopUp", value);
                    //response.EnsureSuccessStatusCode()
                    responseData = await response.Content.ReadAsAsync<byte[]>();
                }
                return responseData;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
