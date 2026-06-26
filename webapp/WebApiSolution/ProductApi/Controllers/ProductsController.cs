using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    // API 컨트롤러로 지정하며, 기본 경로는 /api/products 로 매핑됩니다.
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly string connString;

        public ProductsController(IConfiguration configuration)
        {
            connString = configuration.GetConnectionString("TestDbConnection");
        }

        // 1. 전체 상품 목록 조회: GET /api/products
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            List<Product> products = new();

            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();
            string query = "SELECT product_id, product_name, category, price, stock, created_at FROM testdb.products ORDER BY product_id DESC;";

            using var cmd = new MySqlCommand(query, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    ProductId = reader.GetInt32("product_id"),
                    ProductName = reader.GetString("product_name"),
                    Category = reader.IsDBNull(reader.GetOrdinal("category")) ? null : reader.GetString("category"),
                    Price = reader.GetDecimal("price"),
                    Stock = reader.GetInt32("stock"),
                    CreateAt = reader.GetDateTime("created_at")
                });
            }
            return Ok(products); 
        }

        // 2. 단일 상품 상세 조회: GET /api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();

            string query = "SELECT product_id, product_name, category, price, stock, created_at FROM testdb.products WHERE product_id = @ProductId;";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync()) 
            {
                Product product = new Product
                {
                    ProductId = reader.GetInt32("product_id"),
                    ProductName = reader.GetString("product_name"),
                    Category = reader.IsDBNull(reader.GetOrdinal("category")) ? null : reader.GetString("category"),
                    Price = reader.GetDecimal("price"),
                    Stock = reader.GetInt32("stock"),
                    CreateAt = reader.GetDateTime("created_at")
                };
                return Ok(product);
            }
            return NotFound($"상품번호 {id}를 찾을 수 없습니다.");
        }

        // 3. 상품 신규 등록: POST /api/products/create
        // 라우팅 충돌 방지를 위해 하위 경로를 명시적으로 지정
        [HttpPost("create")] 
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();

            string query = @"INSERT INTO testdb.products (product_name, category, price, stock, created_at)
                             VALUES (@ProductName, @Category, @Price, @Stock, @CreatedAt);
                             SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);
            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            var newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            product.ProductId = newId;
            product.CreateAt = DateTime.Now;

            return Ok(product);
        }

        // 4. 상품 전체 정보 수정: PUT /api/products/{id}
        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();

            string query = @"UPDATE testdb.products SET product_name = @ProductName, category = @Category, 
                             price = @Price, stock = @Stock WHERE product_id = @ProductId;";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);
            cmd.Parameters.AddWithValue("@ProductId", id);

            int result = await cmd.ExecuteNonQueryAsync();
            return result == 0 ? NotFound($"상품번호 {id}를 찾을 수 없습니다.") : Ok("상품이 수정되었습니다.");
        }

        // 5. 상품 재고만 부분 수정: PATCH /api/products/stock/{id}
        // 전체 업데이트가 아닌 특정 필드만 수정하므로 PATCH 권장
        [HttpPatch("stock/{id}")] 
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] ProductStock stockUpdate)
        {
            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();

            string query = @"UPDATE testdb.products SET stock = @Stock WHERE product_id = @ProductId;";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Stock", stockUpdate.Stock);
            cmd.Parameters.AddWithValue("@ProductId", id);

            int result = await cmd.ExecuteNonQueryAsync();
            return result == 0 ? NotFound($"상품번호 {id}를 찾을 수 없습니다.") : Ok("재고가 수정되었습니다.");
        }

        // 6. 상품 삭제: DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            using var conn = new MySqlConnection(connString);
            await conn.OpenAsync();

            string query = @"DELETE FROM testdb.products WHERE product_id = @ProductId";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductId", id);

            int result = await cmd.ExecuteNonQueryAsync();
            return result == 0 ? NotFound($"상품번호 {id}를 찾을 수 없습니다.") : Ok("상품이 삭제되었습니다.");
        }

        // 7. 메타데이터 조회: HEAD /api/products/{id}
        // 응답 본문 없이 상태 코드만 확인하여 리소스 존재 여부를 체크할 때 사용
        [HttpHead("{id}")]
        public IActionResult Head(int id) => Ok();

        // 8. 허용 메서드 정보 제공: OPTIONS /api/products
        // 클라이언트에게 지원되는 HTTP 메서드 목록을 응답 헤더로 전달
        [HttpOptions]
        public IActionResult Option()
        {
            Response.Headers.Append("Allow", "GET,POST,PUT,PATCH,DELETE");
            return Ok();
        }
    }
}