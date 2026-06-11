using Newtonsoft.Json;

namespace WpfBusanFestivalApp.Models
{
    public class FestivalItem 
    {
        /*
         * 
         * UC_SEQ: 71
            MAIN_TITLE: "부산바다축제(한,영, 중간,중번,일)"
            GUGUN_NM: "수영구"
            LAT: 35.151604
            LNG: 129.11713
            PLACE: "부산바다축제, 다대포"
            TITLE: "부산하면 여름, 여름하면 부산바다축제!"
            SUBTITLE: "축제의 바다 속으로"
            MAIN_PLACE: "다대포 해수욕장 일원"
            ADDR1: ""
            ADDR2: ""
            CNTCT_TEL: "051-713-5000"
            HOMEPAGE_URL: "http://www.bfo.or.kr/festival_sea/info/01.asp?MENUDIV=1"
            TRFC_INFO: "도시철도 1호선 다대포해수욕장역 2번 출구 도보 8분 버스 11, 2, 3, 338, 96, 96-1, 1000 "
            USAGE_DAY: ""
            USAGE_DAY_WEEK_AND_TIME: "2025. 8. 1. ~ 8. 3."
            USAGE_AMOUNT: ""
            MAIN_IMG_NORMAL: "https://www.visitbusan.net/uploadImgs/files/cntnts/20191213191711585_ttiel"
            MAIN_IMG_THUMB: "https://www.visitbusan.net/uploadImgs/files/cntnts/20191213191711585_thumbL"
            ITEMCNTNTS: " 타오르는 태양, 시원한 바다, 금빛 백사장, 화려한 네온사인, 신나는 음악! 이 모든 것을 한 번에 즐길 수 있는 부산의 대표 여름축제, 부산바다축제를 소개한다. 부산바다축제는 해마다 여름이 되면 부산 시내 해수욕장에서 열린다. 축제는 다양한 프로그램으로 사람들을 맞이하는데 그 중에서도 메인 행사는 첫날의 개막파티이다. 매해 새로운 모습을 추구하기에 지난 회차와는 또 다른 행사를 즐길 수 있다. 개막파티를 놓친 이들이라도 매일 새롭게 열리는 참여행사를 통해 축제를 즐길 수 있다. 부산바다축제는 음악, 춤, 먹거리 등 모든 것을 즐길 수 있다. 특히나 뜨거운 여름밤을 달구기에 춤만 한 것도 없다. 해변에서 펼쳐지는 댄스파티 현장은 보는 것만으로도 몸치에서 탈출할 수 있을 것만 같다. 국‧내외 댄스 동호인들의 열정적인 스윙, 살사, 줌바 댄스를 직접 따라하다 보면 몸이 저절로 박자를 즐기고 있다. 다양하고 신나는 공연은 계속 이어진다. 부산 바다의 조용한 정취를 좋아하는 이들에게는 열린바다 열린음악회를, 미래의 힙합 전사들에게는 줌바다와 해변살사댄스 페스티벌을, 다대포 낙조의 낭만을 경험하고자 한다면 다대포 포크樂 페스티벌을 추천한다. 최고의 뮤지션들이 밤바다를 배경으로 연주하는 음악과 그들의 노랫소리는 귀를 호강시켜주기에 충분하니 말이다. 더불어 건전한 장애인 놀이문화와 다양한 스포츠행사, 레크레이션이 진행되는 장애인 한바다축제, 부산 청소년 바다축제도 열려 남녀노소, 장애인‧비장애인 할 것 없이 누구나 즐길 수 있는 부산바다축제임을 보여준다. 부산의 바다가 간직한 매력은 어디까지일까. 밤의 풍경, 음악, 젊음, 열정. 부산의 여름을 생각했을 때 떠오르는 많은 말들이 있지만 부산바다축제야말로 그 모든 것을 다 담고 있는 종합선물세트라고 할 수 있을 것이다. 무엇을 생각하든 그 이상을 만날 수 있는 축제. 이 축제만으로 여름의 부산을 찾을 이유는 충분하지 않을까. "
            MIDDLE_SIZE_RM1: "장애인 한바다축제 수어통역 / (사)부산장애인총연합회 051-863-0650"
        */
        // JSON에 UC_SEQ 키값을 UcSeq로 변환해주는 작업
        // 메서드로 자동 변환
        [JsonProperty("UC_SEQ")]
        public int UcSeq { get; set; }

        [JsonProperty("MAIN_TITLE")]
        public string MainTitle { get; set; }

        [JsonProperty("GUGUN_NM")]
        public string GugunNm { get; set; }

        [JsonProperty("LAT")]
        public double Lat { get; set; }

        [JsonProperty("LNG")]
        public double Lng { get; set; }

        [JsonProperty("PLACE")]
        public string Place { get; set; }

        [JsonProperty("TITLE")]
        public string Title { get; set; }

        [JsonProperty("SUBTITLE")]
        public string SubTitle { get; set; }

        [JsonProperty("MAIN_PLACE")]
        public string MainPlace { get; set; }

        [JsonProperty("ADDR1")]
        public string Addr1 { get; set; }

        [JsonProperty("ADDR2")]
        public string Addr2 { get; set; }

        [JsonProperty("CNTCT_TEL")]
        public string CntctTel { get; set; }

        [JsonProperty("HOMEPAGE_URL")]
        public string HomepageUrl { get; set; }

        [JsonProperty("TRFC_INFO")]
        public string TrfcInfo { get; set; }

        [JsonProperty("USAGE_DAY")]
        public string UsageDay { get; set; }

        [JsonProperty("USAGE_DAY_WEEK_AND_TIME")]
        public string UsageDayWeekAndTime { get; set; }

        [JsonProperty("USAGE_AMOUNT")]
        public string UsageAmount { get; set; }

        [JsonProperty("MAIN_IMG_NORMAL")]
        public string MainImgNormal { get; set; }

        [JsonProperty("MAIN_IMG_THUMB")]
        public string MainImgThumb { get; set; }

        [JsonProperty("ITEMCNTNTS")]
        public string ItemCntnts { get; set; }

        [JsonProperty("MIDDLE_SIZE_RM1")]
        public string MiddleSizeRm1 { get; set; }
    }
}
