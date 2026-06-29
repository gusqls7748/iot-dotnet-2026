using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using WpfProductAdmin.Models;
using WpfProductAdmin.Services;

namespace WpfProductAdmin
{
    /// <summary>
    /// ProductCreateWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductCreateWindow : MetroWindow
    {
        ApiService service;

        public ProductCreateWindow()
        {
            InitializeComponent();

            service = new ApiService();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            // Validation Check
            if (string.IsNullOrEmpty(TxtProductName.Text.Trim()))
            {
                await this.ShowMessageAsync("입력오류", "상품명을 입력하세요.");
                // TxtProductName.Focus(); // 상품명 입력창에 포커스
                return;
            }

            if (string.IsNullOrEmpty(TxtCategory.Text.Trim()))
            {
                await this.ShowMessageAsync("입력오류", "카테고리를 입력하세요.");
                return;
            }

            if (!Decimal.TryParse(NudPrice.Value.ToString(), out decimal price))
            {
                await this.ShowMessageAsync("입력오류", "가격은 숫자로 입력하세요.");
                return;
            }

            if (Convert.ToDecimal(NudPrice.Value) <= 0)
            {
                await this.ShowMessageAsync("입력오류", "가격은 1000원 이상 입력하세요.");
                return;
            }

            if (!int.TryParse(NudStock.Value.ToString(), out int stock))
            {
                await this.ShowMessageAsync("입력오류", "재고는 숫자로 입력하세요.");
                return;
            }

            // 모델 생성
            Product product = new Product
            {
                ProductName = TxtProductName.Text.Trim(),
                Category = TxtCategory.Text.Trim(),
                Price = price,
                Stock = stock
            };

            // 서비스 호출 (오류 확인을 위해 디버깅 코드 추가)
            bool result = await service.PostProductAsync(product);

            if (result)
            {
                await this.ShowMessageAsync("성공", "상품이 등록되었습니다.");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                // 메시지만 띄우지 말고 상세 에러를 확인해야 합니다.
                await this.ShowMessageAsync("등록실패", "서버가 요청을 거부했습니다. API 설정을 확인하세요.");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
