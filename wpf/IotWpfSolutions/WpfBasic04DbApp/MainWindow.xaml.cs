using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MySqlConnector;
using System.Data;
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
using WpfBasic04DbApp;

namespace WpfBasic04DbApp // 👈 💡 기존 WpfBasic03UiApp에서 04DbApp으로 변경!
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DatabaseHelper databaseHelper;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            databaseHelper = new DatabaseHelper();

            LoadComboBoxData();

            LoadData();
        }

        private void LoadComboBoxData()
        {
            string query = "SELECT div_code, div_name FROM division";

            DataTable dt = databaseHelper.Select(query);
            CboDivCode.ItemsSource = dt.DefaultView;
        }

        private void LoadData()
        {
            string query = "SELECT b.book_idx, b.author, b.div_code, d.div_name, b.book_name, b.release_dt, b.isbn, b.price " +
                            " FROM books AS b JOIN division AS d " +
                            "   ON b.div_code = d.div_code ORDER BY b.book_idx ";

            DataTable dt = databaseHelper.Select(query);
            GrdBooks.ItemsSource = dt.DefaultView;
        }


        // 기존에 메서드 위쪽에 잘못 들어가 있던 } 이나 글자들은 완전히 지워주세요.

        /// <summary>
        /// 윈폼 형태 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GrdBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // SelectedItems에 선택된 항목이 있는지 검사
                if (GrdBooks.SelectedItems.Count == 1)
                {
                    // [수정] 0번째 인덱스의 개별 요소를 DataRowView로 정확히 캐스팅합니다.
                    var item = GrdBooks.SelectedItems[0] as DataRowView;

                    if (item != null)
                    {
                        NudBookIdx.Value = Convert.ToInt32(item.Row["book_idx"]);
                        TxtAuthor.Text = item.Row["author"].ToString();
                        TxtBookName.Text = Convert.ToString(item.Row["book_name"]);
                        DtpReleaseDt.Text = Convert.ToString(item.Row["release_dt"]);
                        TxtIsbn.Text = Convert.ToString(item.Row["isbn"]);
                        TxtPrice.Text = Convert.ToString(item.Row["price"]);

                        // 데이터 타입에 따라 ToString() 또는 ToInt32()를 선택하세요.
                        CboDivCode.SelectedValue = Convert.ToString(item.Row["div_code"]);

                        SbiResMsg.Text = $"{Convert.ToInt32(item.Row["book_idx"])}번 데이터로드 완료";
                    }
                    else
                    {
                        SbiResMsg.Text = "선택된 데이터 형식이 DataRowView가 아닙니다.";
                    }
                }
            }
            catch (Exception ex)
            {
                SbiResMsg.Text = $"데이터로드 오류 : {ex.Message}";
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string author = TxtAuthor.Text.Trim();
                string bookname = TxtBookName.Text.Trim();
                string isbn = TxtIsbn.Text.Trim();
                string divCode = Convert.ToString(CboDivCode.SelectedValue);

                // 필수 입력값 체크
                if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(bookname) || string.IsNullOrEmpty(divCode))
                {
                    await this.ShowMessageAsync("입력오류", "필수값을 입력하세요");
                    return;
                }

                // 출판일 유효성 체크
                DateTime releaseDt;
                if (!DateTime.TryParse(DtpReleaseDt.Text, out releaseDt))
                {
                    await this.ShowMessageAsync("입력오류", "올바른 출판일을 선택하거나 입력하세요.");
                    return;
                }

                // 가격 유효성 체크
                if (!int.TryParse(TxtPrice.Text, out int price))
                {
                    await this.ShowMessageAsync("입력오류", "가격은 숫자로 입력하세요");
                    return;
                }

                int bookIdx = Convert.ToInt32(NudBookIdx.Value);
                string query = string.Empty;

                if (bookIdx == 0) // INSERT
                {
                    // [수정] 쿼리 속 @ 이름들을 아래 MySqlParameter의 첫 번째 글자와 완벽히 일치시킵니다.
                    query = "INSERT INTO books " +
                            " (author, div_code, book_name, release_dt, isbn, price) " +
                            " VALUES " +
                            " (@author, @div_code, @book_name, @release_dt, @isbn, @price) ";

                    // [오타 수정] 쿼리에 적은 이름(@author 등)과 파라미터 이름이 완벽히 똑같아야 합니다.
                    databaseHelper.Execute(query,
                            new MySqlParameter("@author", author),
                            new MySqlParameter("@div_code", divCode),   // @divCode -> @div_code 수정
                            new MySqlParameter("@book_name", bookname), // @bookname -> @book_name 수정
                            new MySqlParameter("@release_dt", releaseDt.ToString("yyyy-MM-dd")), // 날짜 스트링 변환 안전화
                            new MySqlParameter("@isbn", isbn),
                            new MySqlParameter("@price", price)
                         );

                    SbiResMsg.Text = "새로운 도서정보가 등록되었습니다.";
                }
                else // UPDATE
                {
                    // [중요 수정] SQL 문법 오류 해결: 각 컬럼 사이에 콤보(,)를 추가하고 날짜는 yyyy-MM-dd 포맷으로 지정
                    query = "UPDATE books " +
                            $"SET author = '{author}', " +
                            $"    div_code = '{divCode}', " +
                            $"    book_name = '{bookname}', " +
                            $"    release_dt = '{releaseDt.ToString("yyyy-MM-dd")}', " +
                            $"    isbn = '{isbn}', " +
                            $"    price = {price} " +
                            $"WHERE book_idx = {bookIdx}";

                    databaseHelper.Execute(query);

                    // [수정] Content를 Text 속성으로 교체하여 에러 해결
                    SbiResMsg.Text = $"{bookIdx}번 도서정보가 수정되었습니다.";
                }

                ClearInputs(); // 책상세 입력컨트롤에 들어가는 데이터를 전부 삭제(초기화)
                LoadData(); // 데이터 재조회

                // [권장 추가] 저장 후 데이터그리드를 다시 조회하는 메서드를 호출하세요 (메서드명이 다르면 수정 필요)
                // LoadGridData(); 
            }
            catch (Exception ex)
            {
                SbiResMsg.Text = $"데이터저장 오류: {ex.Message}";
            }
        }

        private void ClearInputs()
        {
            NudBookIdx.Value = 0;
            TxtAuthor.Text = string.Empty;
            TxtBookName.Text = string.Empty;
            DtpReleaseDt.Text = string.Empty;
            TxtIsbn.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            TxtPrice.Text = ""; // ==
            CboDivCode.SelectedIndex = -1; // 콤보박스 선택값 없애기
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            // 1. 모든 입력 텍스트 박스 초기화 (작성해 두신 메서드)
            ClearInputs();

            // [필수 추가] 2. 숨겨진 인덱스 번호를 0으로 초기화
            // 이전 단계에서 작성한 Save 로직의 "if (bookIdx == 0) // INSERT" 조건과 연동됩니다.
            NudBookIdx.Value = 0;

            // [권장 추가] 3. 신규 입력 시 사용자가 편하도록 첫 번째 입력 칸으로 포커스 이동
            TxtAuthor.Focus();

            // 4. 상태바 메시지 출력 (ContentEnd 대신 Text 속성 사용)
            SbiResMsg.Text = "신규 도서 입력을 시작합니다.";
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int bookIdx = Convert.ToInt32(NudBookIdx.Value);

                if (bookIdx <= 0)
                {
                    // [수정] Content를 Text 속성으로 변경
                    SbiResMsg.Text = "먼저 삭제할 도서를 선택하세요";
                    return;
                }

                // 다이얼 로그로 삭제여부를 확인
                MessageDialogResult res = await this.ShowMessageAsync("삭제 확인", $"{bookIdx}번 도서를 삭제하시겠습니까?",
                                                                        MessageDialogStyle.AffirmativeAndNegative);
                if (res != MessageDialogResult.Affirmative)
                {
                    return; // 확인이 아니면 진행 종료
                }

                // 파라미터화된 쿼리를 사용하여 안전하게 삭제 진행
                string query = "DELETE FROM books WHERE book_idx = @book_idx";

                int resultRow = databaseHelper.Execute(query,
                                    new MySqlParameter("@book_idx", bookIdx)
                                );

                if (resultRow > 0)
                {
                    // [수정] ContentEnd를 Text 속성으로 변경
                    SbiResMsg.Text = $"{bookIdx}번 도서가 삭제되었습니다.";

                    // [추가] 삭제되었으므로 현재 입력창에 남아있는 인덱스 정보도 0으로 초기화합니다.
                    NudBookIdx.Value = 0;

                    ClearInputs();
                    LoadData(); // 데이터조회 (목록 새로고침)
                }
            }
            catch (Exception ex)
            {
                // [수정] Content를 Text 속성으로 변경
                SbiResMsg.Text = $"데이터삭제 오류 : {ex.Message}";
            }
        }
    } // 2. 클래스(MainWindow) 닫기
} // 3. 네임스페이스(Namespace) 닫기
