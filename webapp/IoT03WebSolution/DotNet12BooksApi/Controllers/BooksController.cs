using Microsoft.AspNetCore.Mvc;

namespace DotNet12BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        // 임시 메모리 데이터
        private static List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "C# 프로그래밍", Author = "홍길동", Price = 30000 },
            new Book { Id = 2, Title = "ASP.NET Core", Author = "김철수", Price = 35000 }
        };

        // 전체 조회
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(books);
        }

        // 단건 조회
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // 등록
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Id = books.Max(x => x.Id) + 1;

            books.Add(book);

            return Ok(book);
        }

        // 수정
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updateBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Price = updateBook.Price;

            return Ok(book);
        }

        // 삭제
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            books.Remove(book);

            return NoContent();
        }
    }
}
