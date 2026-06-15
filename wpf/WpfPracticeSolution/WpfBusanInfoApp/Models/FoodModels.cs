using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WpfBusanInfoApp.Models
{
    // API 응답 구조
    public class FoodApiResponse
    {
        [JsonProperty("getFoodKr")]
        public GetFoodKr GetFoodKr { get; set; }
    }

    public class GetFoodKr
    {
        [JsonProperty("item")]
        public ObservableCollection<FoodItem> item { get; set; }
    }

    // 맛집 정보 모델
    public class FoodItem
    {
        [JsonProperty("UC_SEQ")] public int UcSeq { get; set; }
        [JsonProperty("MAIN_TITLE")] public string Title { get; set; }
        [JsonProperty("GUGUN_NM")] public string GugunNm { get; set; }
        [JsonProperty("ADDR1")] public string Addr1 { get; set; }
        [JsonProperty("MAIN_IMG_THUMB")] public string MainImgThumb { get; set; }
        [JsonProperty("USAGE_DAY_WEEK_AND_TIME")] public string OpTime { get; set; }
        [JsonProperty("LAT")] public double Lat { get; set; }
        [JsonProperty("LNG")] public double Lng { get; set; }
        [JsonProperty("ITEMCNTNTS")] public string ItemCntnts { get; set; }
        [JsonProperty("HOMEPAGE_URL")] public string HomepageUrl { get; set; }

        [JsonProperty("MAIN_IMG_NORMAL")]
        public string MainImgNormal { get; set; } // 이 속성이 있는지 확인!
    }
}