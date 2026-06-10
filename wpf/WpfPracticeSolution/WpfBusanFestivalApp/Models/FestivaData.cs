using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WpfBusanFestivalApp.Models
{
    internal class FestivaData
    {
        [JsonProperty("item")]
        public ObservableCollection<FestivalItem> Items { get; set; }
    }
}