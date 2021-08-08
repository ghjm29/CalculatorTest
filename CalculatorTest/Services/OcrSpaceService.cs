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
            request.AddParameter("issearchablepdfhidetextlayer", "true");
            request.AddParameter("filetype", ".Auto");
            request.AddFile("file", filePath);
            request.AddParameter("OCREngine", "2");
            request.AddParameter("detectOrientation", "false");
            request.AddParameter("isTable", "false");
            request.AddParameter("scale", "true");
            request.AddParameter("detectCheckbox", "false");
            request.AddParameter("checkboxTemplate", "0");
            return client.Execute(request);
        }
    }
}
