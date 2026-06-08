using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfCafeKiosk
{
    /// <summary>
    /// MenuOptionWindow.xaml에 선언된 버튼 이벤트들과 완벽하게 일치하는 비하인드 클래스입니다.
    /// </summary>
    public partial class MenuOptionWindow : Window
    {
        // 장바구니 모델(OrderItem)의 Count와 통일하여 수량 관리
        public int Count { get; private set; } = 1;

        private int unitPrice = 0;

        // 생성자: 부모 창(MainWindow)에서 받아온 데이터를 매핑합니다.
        public MenuOptionWindow(string menuName, int price, string imagePath)
        {
            InitializeComponent();

            unitPrice = price;
            TxtMenuName.Text = menuName;
            TxtPrice.Text = $"{price:N0}원";

            // 이미지 경로 처리 (예외 발생 시 튕김 방지)
            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    ImgMenu.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
            }
            catch
            {
                // 이미지 파일이 없거나 경로가 꼬여도 에러 없이 창이 켜지도록 유연하게 처리
            }
        }

        // XAML의 Click="BtnMinus_Click"과 완벽히 매핑되는 메서드
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Count > 1)
            {
                Count--;
                UpdateQuantityUi();
            }
        }

        // XAML의 Click="BtnPlus_Click"과 완벽히 매핑되는 메서드
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Count++;
            UpdateQuantityUi();
        }

        // 수량 텍스트와 변경된 실시간 합산 가격 반영 헬퍼 함수
        private void UpdateQuantityUi()
        {
            TxtQuantity.Text = Count.ToString();
            int totalOptionPrice = unitPrice * Count;
            TxtPrice.Text = $"{totalOptionPrice:N0}원";
        }

        // XAML의 Click="BtnCancel_Click"과 완벽히 매핑되는 메서드
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        // XAML의 Click="BtnConfirm_Click"과 완벽히 매핑되는 메서드
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}