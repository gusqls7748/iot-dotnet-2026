using Newtonsoft.Json;
using System; // Environment 사용을 위해 필요
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks; // Task 사용을 위해 필요
using WpfBusanInfoApp.Helpers;
using WpfBusanInfoApp.Models;

namespace WpfBusanInfoApp.Services
{
    public class FoodApiService
    {
        private string? ServiceKey { get; set; }

        public FoodApiService()
        {
            ServiceKey = Environment.GetEnvironmentVariable("BUSAN_FOOD_API_KEY");
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodsAsync(int pageNo = 1, int numOfRows = 10)
        {
            if (string.IsNullOrEmpty(ServiceKey)) // 키 존재 여부 확인
            {
                Common.logger.Warn("공공데이터 포털 API 키가 없습니다.");
                return new ObservableCollection<FoodItem>();
            }

            string serviceUrl = $"https://apis.data.go.kr/6260000/FoodService/getFoodKr" +
                                $"?serviceKey={ServiceKey}" +
                                $"&pageNo={pageNo}" +
                                $"&numOfRows={numOfRows}" +
                                $"&resultType=json";

            try
            {
                using HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(serviceUrl);

                var response = JsonConvert.DeserializeObject<FoodApiResponse>(json);

                // response.GetFoodKr.item으로 접근하는지 확인 (모델 클래스 정의와 일치해야 함)
                return response?.GetFoodKr?.item ?? new ObservableCollection<FoodItem>();
            }
            catch (Exception ex)
            {
                Common.logger.Error($"예외발생 GetFoodsAsync() : {ex.Message}");
                return new ObservableCollection<FoodItem>();
            }
        }
    }
}