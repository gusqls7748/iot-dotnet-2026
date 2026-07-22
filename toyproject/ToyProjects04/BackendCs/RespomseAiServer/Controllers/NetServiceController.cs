using Microsoft.AspNetCore.Mvc;

namespace RespomseAiServer.Controllers {

    [ApiController]
    [Route("[controller]")]
    // 1. ControllerBase 상속 추가
    public class NetServiceController : ControllerBase {

        private readonly IHttpClientFactory httpClientFactory;

        public NetServiceController(IHttpClientFactory httpClientFactory) {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("/net_service")]
        public async Task<IActionResult> ProxyRequest([FromForm] string message, [FromForm] IFormFile file) {
            // 1. 파일선택 안했으면
            if (file == null || file.Length == 0) {
                return BadRequest(new { message = "파일을 선택하세요." });
            }

            // 2. Program.cs에 등록한 PythonAI 서버 이름으로 클라이언트 생성
            var client = httpClientFactory.CreateClient("PythonAiService");

            // 3. Python RestAPI로 전달할 데이터 할당
            using var content = new MultipartFormDataContent();

            // 3.1 Request Body 중 message 키할당 (null 방지 처리 추가)
            content.Add(new StringContent(message ?? string.Empty), "message");

            // 3.2 Request Body 중 File 키할당
            using var stream = file.OpenReadStream();
            var fileContent = new StreamContent(stream);

            // 2. ConentType 오타 수정 -> ContentType
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            content.Add(fileContent, "file", file.FileName);

            // 4. python API로 POST 요청
            var response = await client.PostAsync("/detect", content);
            if (!response.IsSuccessStatusCode) {
                return StatusCode((int)response.StatusCode, "파이썬 AI 서비스 호출 실패!");
            }

            // 5. 돌아온 결과를 읽어서 json으로 출력
            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }
    }
}