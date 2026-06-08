namespace WpfCafeKiosk.Models
{
    internal class OrderItem
    {
        // DB 컬럼명: menu_id, menu_name, price
        // 클래스 속성명: MenuId, MenuName, Price
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int Price { get; set; } // 단가 (기본 1개 가격)

        // [수정] 수량은 연산이 가능하도록 bool에서 int로 변경합니다.
        public int Count { get; set; }

        // 총합 금액 계산 속성
        public int TotalPrice
        {
            get
            {
                // 이제 int와 int의 곱셈이므로 에러가 나지 않습니다.
                return Price * Count;
            }
        }
    }
}