using MaterialSkin.Controls;
using System.Data;

namespace DotNet06DbBooksApp
{
    public partial class FrmBook : MaterialForm
    {
        DatabaseHelper dbHelper;
        public FrmBook()
        {
            InitializeComponent();
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
            dbHelper = new DatabaseHelper(); // 객체생성

            // 자동으로 컬럼생성하면 개발자 의도대로 컬럼을 변경할 수 없음
            DgvBooks.AutoGenerateColumns = false;

            InitGrid(); // 데이터그리드뷰 컬럼 초기설정
            InitData();

            LoadData();
        }

        private void InitData()
        {
            // 책장르 데이터 조회
            string divSql = "SELECT div_code, div_name\r\nFROM bookrentalshop.division";
            DataTable divTable = dbHelper.Select(divSql);

            // 기존 div_code 컬럼위치 인덱스
            var colIndex = DgvBooks.Columns["div_code"].Index; // 아마 2

            // 기존 DataGridViewTextBoxColum으로 생성된 컬럼 제거
            DgvBooks.Columns.RemoveAt(colIndex);

            // 콤보박스컬럼 새로 생성
            DataGridViewComboBoxColumn colCboDivCode = new DataGridViewComboBoxColumn
            {
                Name = "div_code",
                HeaderText = "책장르",
                DataPropertyName = "div_code",
                // 연동되는 데이터 설정
                DataSource = divTable,
                ValueMember = "div_code",
                DisplayMember = "div_name",
            };

            // 기존 div_code 컬럼 위치에 추가
            DgvBooks.Columns.Insert(colIndex, colCboDivCode);
            DgvBooks.Columns["div_code"].ReadOnly = false;
        }

        private void InitGrid()
        {
            // 7개 컬럼을 설정
            // book_idx
            DataGridViewTextBoxColumn colBookIdx = new DataGridViewTextBoxColumn
            {
                Name = "book_idx",
                HeaderText = "순번", // 화면표시 컬럼명
                DataPropertyName = "book_idx",
                Width = 68,
                ReadOnly = true  // PK는 수정하면 안됨!!
            };
            DgvBooks.Columns.Add(colBookIdx);

            // Author
            DataGridViewTextBoxColumn colAuthor = new DataGridViewTextBoxColumn
            {
                Name = "author",
                HeaderText = "저자", // 화면표시 컬럼명
                DataPropertyName = "author",
                Width = 130,
            };
            DgvBooks.Columns.Add(colAuthor);

            // DivCode
            DataGridViewTextBoxColumn colDivCode = new DataGridViewTextBoxColumn
            {
                Name = "div_code",
                HeaderText = "책장르", // 화면표시 컬럼명
                DataPropertyName = "div_code",
                Width = 100,
            };
            DgvBooks.Columns.Add(colDivCode);

            // book_name
            DataGridViewTextBoxColumn colBookName = new DataGridViewTextBoxColumn
            {
                Name = "book_name",
                HeaderText = "책이름", // 화면표시 컬럼명
                DataPropertyName = "book_name",
                Width = 250,
            };
            DgvBooks.Columns.Add(colBookName);

            // book_name
            DataGridViewTextBoxColumn colReleaseDt = new DataGridViewTextBoxColumn
            {
                Name = "release_dt",
                HeaderText = "출판일", // 화면표시 컬럼명
                DataPropertyName = "release_dt",
                Width = 120,
                DefaultCellStyle =
          {
              Alignment = DataGridViewContentAlignment.MiddleCenter,
              Format = "yyy-MM-dd"
          }
            };
            DgvBooks.Columns.Add(colReleaseDt);

            // book_name
            DataGridViewTextBoxColumn colIsbn = new DataGridViewTextBoxColumn
            {
                Name = "isbn",
                HeaderText = "Isbn", // 화면표시 컬럼명
                DataPropertyName = "isbn",
                Width = 140,
                DefaultCellStyle =
          {
              Alignment = DataGridViewContentAlignment.MiddleCenter,
          }
            };
            DgvBooks.Columns.Add(colIsbn);

            // book_name
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn
            {
                Name = "price",
                HeaderText = "가격", // 화면표시 컬럼명
                DataPropertyName = "price",
                Width = 100,
                DefaultCellStyle =
          {
              Alignment = DataGridViewContentAlignment.MiddleRight,
              Format = "#,##0"
          }
            };
            DgvBooks.Columns.Add(colPrice);

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            // SQL 쿼리문 작성
            string query = "SELECT book_idx, author, div_code, book_name, release_dt, isbn, price" +
                           "  FROM books";

            // DataGridView 컨트롤내 DataSource
            DgvBooks.DataSource = dbHelper.Select(query);

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var insRes = 0;
                foreach (DataGridViewRow row in DgvBooks.Rows)
                {
                    if (row.IsNewRow) continue;

                    string bookIdx = row.Cells["book_idx"].Value?.ToString();
                    //Debug.WriteLine(bookIdx);

                    // book_idx가 비어있으면 새로운 레코드추가
                    if (string.IsNullOrWhiteSpace(bookIdx))
                    {
                        string author = row.Cells["author"].Value?.ToString();
                        string divCode = row.Cells["div_code"].Value?.ToString();
                        string bookName = row.Cells["book_name"].Value?.ToString();
                        string releseDt = row.Cells["release_dt"].Value?.ToString().Substring(0, 10);
                        string isbn = row.Cells["isbn"].Value?.ToString();
                        string price = row.Cells["price"].Value?.ToString();

                        string insSql = "INSERT INTO bookrentalshop.books " +
                                        " (author, div_code, book_name, release_dt, isbn, price)" +
                                        $" VALUES('{author}', '{divCode}', '{bookName}', '{releseDt}', '{isbn}', {price});";

                        insRes += dbHelper.Execute(insSql);
                    }

                }
                if (insRes > 0)
                {
                    MessageBox.Show("데이터 추가 완료!");
                }
                else
                {
                    MessageBox.Show("데이터 추가 실패!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"INSERT 오류 : {ex.Message}");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var updRes = 0;

                foreach (DataGridViewRow row in DgvBooks.SelectedRows)
                {
                    string bookIdx = row.Cells["book_idx"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(bookIdx))
                    {
                        string author = row.Cells["author"].Value?.ToString();
                        string divCode = row.Cells["div_code"].Value?.ToString();
                        string bookName = row.Cells["book_name"].Value?.ToString();
                        string releseDt = row.Cells["release_dt"].Value?.ToString().Substring(0, 10);
                        string isbn = row.Cells["isbn"].Value?.ToString();
                        string price = row.Cells["price"].Value?.ToString();

                        string upSql = "UPDATE books " +
                                        $"SET author='{author}', " +
                                        $"div_code='{divCode}', " +
                                        $"book_name='{bookName}', " +
                                        $"release_dt='{releseDt}', " +
                                        $"isbn='{isbn}', " +
                                        $"price={price} " +
                                        $" WHERE book_idx={bookIdx}";

                        updRes += dbHelper.Execute(upSql);
                    }
                }
                MessageBox.Show($"디버깅 - 반복문 실행 횟수: {DgvBooks.SelectedRows.Count}건");

                if (updRes > 0)
                {
                    MessageBox.Show($"{updRes}건의 데이터가 수정되었습니다.");
                }
                else
                {
                    MessageBox.Show($"수정 실패!");

                }
                LoadData(); // 데이터 변경 로드
            }
            catch (Exception ex)
            {
                MessageBox.Show($"UPDATE 오류: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("삭제할 행을 선택하세요.");
                    return;
                }

                DialogResult result = MessageBox.Show($"{DgvBooks.SelectedRows.Count}건 삭제하겠습니까?",
                                                       "삭제 확인",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                var delRes = 0;

                if (result == DialogResult.Yes)
                {
                    // 삭제 진행
                    foreach (DataGridViewRow row in DgvBooks.SelectedRows)
                    {
                        string bookIdx = row.Cells["book_idx"].Value?.ToString();

                        if (string.IsNullOrWhiteSpace(bookIdx))
                        {
                            continue;
                        }

                        string delSql = $"DELETE FROM books WHERE book_idx = {bookIdx}";

                        delRes += dbHelper.Execute(delSql);
                    }

                    MessageBox.Show($"{delRes}건 삭제 완료");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DELETE 오류: {ex.Message}");
            }
        }
    }
}