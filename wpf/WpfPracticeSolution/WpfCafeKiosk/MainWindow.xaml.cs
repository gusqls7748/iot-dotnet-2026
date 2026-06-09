using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using WpfCafeKiosk.Common;
using WpfCafeKiosk.Models;

namespace WpfCafeKiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 주문리스트 객체
        // WPF에서 작용하는 리스트. 값이 변동되면 바로적용
        private ObservableCollection<OrderItem> orders;

        // 남은시간 처리용 필드
        private int remainSeconds = 60;
        private DispatcherTimer timer;  // WPF는 타이머를 직접만들어써라!

        private DatabaseHelper db;

        public MainWindow()
        {
            InitializeComponent();
            db = new DatabaseHelper(); // 💡 여기서 반드시 초기화해주세요!
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMenus();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1), // 1초마낟 이벤트 발생
                IsEnabled = true
            };
            timer.Tick += Timer_Tick; // 이벤트 직접 생성
            timer.Start(); //타이머 동작 시작

            TxtRemainTime.Text = remainSeconds.ToString();

            orders = new ObservableCollection<OrderItem>();
            LstOrder.ItemsSource = orders;
        }

        private void LoadMenus()
        {
            try
            {
                MenuPanel.Children.Clear();

                string query = "SELECT menu_id, menu_name, price, image_path, category, is_sale " +
                               "FROM menu WHERE is_sale = 'Y' ORDER BY menu_id";

                DataTable dt = db.Select(query); // db.Select로 수정됨 (이전 코드에 dt.Select라고 오타가 있었음)

                foreach (DataRow row in dt.Rows)
                {
                    // 모델 클래스명 확인 (MenuItemModel 또는 MenuItem)
                    var menu = new MenuItemModel
                    {
                        MenuId = Convert.ToInt32(row["menu_id"]),
                        MenuName = row["menu_name"].ToString(),
                        Price = Convert.ToInt32(row["price"]),
                        ImagePath = row["image_path"].ToString(),
                        Category = row["category"].ToString()
                    };

                    Button btn = CreateMenuButton(menu);
                    MenuPanel.Children.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB 연결 실패! 원인: {ex.Message}");
            }
        }

        private Button CreateMenuButton(MenuItemModel menuItem)
        {
            Button btn = new Button
            {
                Margin = new Thickness(5),
                Padding = new Thickness(0),
                Height = 200,
                Background = Brushes.White,
                BorderThickness = new Thickness(0),
                Tag = $"{menuItem.MenuName}|{menuItem.Price}|{menuItem.ImagePath}|{menuItem.MenuId}"
            };

            // xml의 materialDesignLButtonAssist,CornerRadius="5" 속성을 코드에서 할당하는 방법
            ButtonAssist.SetCornerRadius(btn, new CornerRadius(10));

            btn.Click += Menu_Click;

            // 버튼 디자인 코딩 구현 시작
            Card card = new Card
            {
                UniformCornerRadius = 5,
                Padding = new Thickness(0)
            };

            Grid grid = new Grid();
            Image img = new Image { Stretch = Stretch.Fill };

            try
            {
                img.Source = new BitmapImage(new Uri(menuItem.ImagePath, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                img.Source = null;
            }
            // 버튼 디자인 코딩 구현 끝

            Border bottomBg = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(204, 255, 255, 255)),
                Height = 42,
                VerticalAlignment = VerticalAlignment.Bottom,
                CornerRadius = new CornerRadius(0, 0, 10, 10)
            };

            StackPanel pnlText = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 5)
            };

            TextBlock txtMenuName = new TextBlock
            {
                Text = menuItem.MenuName,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DimGray,
                TextAlignment = TextAlignment.Center
            };

            TextBlock txtPrice = new TextBlock
            {
                Text = $"{menuItem.Price:N0}원",
                FontSize = 12,
                FontWeight = FontWeights.Heavy,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 90, 69)),
                TextAlignment = TextAlignment.Center
            };

            pnlText.Children.Add(txtMenuName);
            pnlText.Children.Add(txtPrice);


            // 버튼 디자인 코딩 구현 끝

            grid.Children.Add(img);
            grid.Children.Add(bottomBg);
            grid.Children.Add(pnlText); // 그리드에 스택패널 할당

            card.Content = grid;
            btn.Content = card;

            return btn; // 💡 반드시 버튼을 반환해야 함!
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            remainSeconds--;

            TxtRemainTime.Text = remainSeconds.ToString();
        }

        // 무슨 메뉴를 클릭하든 전부 이이벤트 발생
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;  // 이벤트를 발생시킨 주체를 할당

            //string[] tag = btn.Tag.ToString().Split("|");

            //string menuName = tag[0];
            //int price = int.Parse(tag[1]);
            //string imagePath = tag[2];    // tag를 메인윈도우에서 잘라서 변수들을 파라미터로 보내면 변수개수에 따라서 생성자 변경필요
            string strTag = btn.Tag.ToString();

            // MessageBox.Show($"{price}", $"{name}");
            //MenuOptionWindow win = new MenuOptionWindow(menuName, price, imagePath);
            MenuOptionWindow win = new MenuOptionWindow(strTag);


            win.Owner = this;  // MainWindow가 MenuOptionWindow의 부모

            bool? result = win.ShowDialog(); // 옵션창에서 취소누르면 false, 주문담기누르면  true

            // TODO  : result가 true일때 주문담기 처리
            if (result == true)
            {
                //OrderItem item = win.selectedOrder;

                // 주문 리스트뷰에 추가
                //MessageBox.Show($"{item.MenuName} {item.Count}개 담기! {item.TotalPrice:N0}");
                orders.Add(win.selectedOrder);
                RefreshOrderSummary();
                remainSeconds = 60;
            }
        }

        private void BtnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;  // WPF, WinForms에서 중요한 개념, 이벤트를 발생시킨 주체

            OrderItem item = btn.Tag as OrderItem;

            if(item != null)
            {
                orders.Remove(item);
                RefreshOrderSummary();
            }
        }

        private void RefreshOrderSummary()
        {
            int count = orders.Sum(x => x.Count);   // Lambd함수
            int total = orders.Sum(x => x.TotalPrice);

            TxtOrderCount.Text = $"{count}잔";
            TxtTotalPrice.Text = $"{total:N0}원";
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            if (orders.Count == 0)
            {
                //MessageBox.Show("주문내역이 없습니다");
                RootDialog.IsOpen = true;
                return;
            }

            orders.Clear();
            RefreshOrderSummary();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            TabAll.Focus();

            RefreshOrderSummary();

        }

        // 결제버튼
        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            if (orders.Count == 0)
            {
                return;
            }

            remainSeconds = 60;
            TxtRemainTime.Text = remainSeconds.ToString();
            timer.Stop();
            OrderConfirmWindow win = new OrderConfirmWindow(orders);
            win.Owner = this;   // 결제창의 소유자(부모)는 MainWindow다.

            bool? result = win.ShowDialog();

            if (result == true)
            {
                // TOdo : DB저장
            }
            else
            {
                timer.Start();
            }
        }
    }
}