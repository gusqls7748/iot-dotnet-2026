using CefSharp;
using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using WpfBusanInfoApp.Helpers;
using WpfBusanInfoApp.Models; // FoodItem 사용을 위해 필수

namespace WpfBusanInfoApp
{
    public partial class FoodDetailWindow : MetroWindow
    {
        public FoodItem? DetailItem { get; }

        public FoodDetailWindow(FoodItem? detailItem)
        {
            InitializeComponent();
            DetailItem = detailItem;
            DataContext = DetailItem;

            if (detailItem != null)
            {
                // 1. 완전한 HTML 구조로 작성
                string html = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='utf-8' />
            <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css'/>
            <style>
                html, body, #map {{ margin: 0; width: 100%; height: 100%; }}
            </style>
        </head>
        <body>
            <div id='map'></div>
            <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
            <script>
                var map = L.map('map', {{ zoomControl: false }}).setView([{detailItem.Lat}, {detailItem.Lng}], 17);
                L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png').addTo(map);
                L.marker([{detailItem.Lat}, {detailItem.Lng}]).addTo(map);
            </script>
        </body>
        </html>";

                // 2. 브라우저에 HTML 로드
                MapBrowser.LoadHtml(html);

                // 3. 본문 내용 처리
                RtbItemContents.Document.Blocks.Clear();
                RtbItemContents.Document.Blocks.Add(
                    new Paragraph(new Run(Common.ConvertHtmlToText(detailItem.ItemCntnts)))
                );
            }
        }

        private void Homepage_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is FoodItem item && !string.IsNullOrWhiteSpace(item.HomepageUrl))
            {
                Process.Start(new ProcessStartInfo { FileName = item.HomepageUrl, UseShellExecute = true });
            }
        }
    }
}