using MahApps.Metro.Controls;
using NLog;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfBusanInfoApp.Helpers;
using WpfBusanInfoApp.Models;
using WpfBusanInfoApp.Services;

namespace WpfBusanInfoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // NLog 기본 객체 생성방법
        //private readonly Logger logger = LogManager.GetCurrentClassLogger();

        // 1. 서비스 타입을 FoodApiService로 변경하세요
        private readonly FoodApiService service;

        // 객체 생성은 클래스 생성자에서 일반적으로 구현
        public MainWindow()
        {
            InitializeComponent();

            // 2. 서비스 객체 초기화
            service = new FoodApiService();
            // logger 에서 쓸 수 있는 메서드 Info(), Trace(), Debug(), Warn(), Error()
            Common.logger.Info("부산 맛집정보앱 시작.");
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Common.logger.Info("부산 페스티벌정보앱 로드 시작");
            //string? key = Environment.GetEnvironmentVariable("BUSAN_FESTIVAL_API_KEY");
            //Console.WriteLine(key);

            // Api서비스 생성
            //FestivalApiService service = new FestivalApiService();            
            //var festivals = await service.GetFestivalsAsync();
            //DgrFestival.ItemsSource = festivals;
            await SearchFoodAsync();

            Common.logger.Info("공공데이터 API 데이터 로드 완료");
        }

        // 검색
        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //WebTestWindow win = new WebTestWindow();
            //win.Owner = this;
            //win.ShowDialog();

            await SearchFoodAsync();
        }

        // 검색기능 처리
        private async Task SearchFoodAsync()
        {
            try
            {
                BtnSearch.IsEnabled = false;

                int pageNo = Convert.ToInt32(NumPageNo.Value ?? 1);
                int numOfRows = Convert.ToInt32(NumOfRows.Value ?? 10);

                // 3. 서비스 클래스에 맛집 데이터를 가져오는 메서드(GetFoodsAsync 등) 호출
                var foods = await service.GetFoodsAsync(pageNo, numOfRows);

                // 4. 컨트롤 이름을 DgrFood로 변경
                DgrFood.ItemsSource = foods;

                Common.logger.Info($"Page : {pageNo}, Records : {foods.Count} 로드 완료!");
                SbiStatus.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {pageNo} 페이지 {foods.Count} 건 로드 완료";
            }
            catch (Exception ex)
            {
                Common.logger.Error($"데이터 로드 실패 SearchFoodAsync() : {ex.Message}");
                SbiStatus.Text = $"로드 실패!!";
            }
            finally
            {
                BtnSearch.IsEnabled = true;
            }
        }

        private void DgrFood_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgrFood.SelectedItem is FoodItem detailItem) // 명시적 형변환
            {
                FoodDetailWindow win = new FoodDetailWindow(detailItem);
                win.Owner = this;
                win.ShowDialog();
            }
        }
    }
}