using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WpfCafeKiosk.Common
{
    class DatabaseHelper
    {
        private string connStr = "Server=localhost;" +   // 운영아이피로 바꾸세요
                                 "Database=cafekiosk;" +   //운영포트로 변경할것
                                 "User ID=root;" +  // 운영DB 사용자로 변경
                                 "Password=my123456;" + // 패스워드 변경할 것
                                 "Charset=utf8mb4;";

        public DataTable Select(string sql)
        {
            // 1, DbConnection 객체 생성 : Db연결문자열 사용
            using MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();  // DB 오픈

            // 2, SqlCommand 객체 생성 : 쿼리를 실행할수 있는 준비
            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
    }
}
