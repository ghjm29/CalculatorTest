using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CalculatorTest.Services
{
    public partial class OcrResponse
        {
        [JsonProperty("ParsedResults")]
        public List<ParsedResult> ParsedResults { get; set; }

        [JsonProperty("OCRExitCode")]
        public long OcrExitCode { get; set; }

        [JsonProperty("IsErroredOnProcessing")]
        public bool IsErroredOnProcessing { get; set; }

        [JsonProperty("ProcessingTimeInMilliseconds")]
        public double ProcessingTimeInMilliseconds { get; set; }
    }

    public partial class ParsedResult
    {
        [JsonProperty("TextOverlay")]
        public TextOverlay TextOverlay { get; set; }

        [JsonProperty("TextOrientation")]
        public string TextOrientation { get; set; }

        [JsonProperty("FileParseExitCode")]
        public long FileParseExitCode { get; set; }

        [JsonProperty("ParsedText")]
        public string ParsedText { get; set; }

        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("ErrorDetails")]
        public string ErrorDetails { get; set; }
    }

    public partial class TextOverlay
    {
        [JsonProperty("Lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("HasOverlay")]
        public bool HasOverlay { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }

    public partial class Line
    {
        [JsonProperty("LineText")]
        public string LineText { get; set; }

        [JsonProperty("Words")]
        public List<Word> Words { get; set; }

        [JsonProperty("MaxHeight")]
        public long MaxHeight { get; set; }

        [JsonProperty("MinTop")]
        public long MinTop { get; set; }
    }

    public partial class Word
    {
        [JsonProperty("WordText")]
        public string WordText { get; set; }

        [JsonProperty("Left")]
        public long Left { get; set; }

        [JsonProperty("Top")]
        public long Top { get; set; }

        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }
    }
}

