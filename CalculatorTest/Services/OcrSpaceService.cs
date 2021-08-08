using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorTest.Services
{
    class OcrSpaceService
    {
        public IRestResponse ReadImageService(string filePath)
        {
            var client = new RestClient("https://api.ocr.space/parse/image");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("apikey", "3a73435db888957");
            request.AddParameter("language", "eng");
            request.AddParameter("isOverlayRequired", "true");
            request.AddParameter("iscreatesearchablepdf", "false");
            request.AddParameter("issearchablepdfhidetextlayer", "false");
            request.AddFile("file", filePath);
            request.AddParameter("OCREngine", "2");
            return client.Execute(request);
        }
    }
}
