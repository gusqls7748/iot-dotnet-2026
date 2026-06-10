using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfBusanFestivalApp.Models
{
    public class FestivalReponse
    {
        [JsonProperty("getFestivalKr")]
        public FestivalData? FestivalData { get; set; }
    }
}
