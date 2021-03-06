using System;
using System.Linq;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace mikoba.UI.Pages.Connections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrScanPage : ContentPage
    {
        public QrScanPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ScannerView.IsScanning = true;
            this.InitSkin();
        }

        private void InitSkin()
        {
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.SetValue(View.HorizontalOptionsProperty, LayoutOptions.FillAndExpand);
            canvasView.SetValue(View.VerticalOptionsProperty, LayoutOptions.FillAndExpand);
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Skin.Children.Add(canvasView);
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float size = 600;
            float posX = (info.Width - size) / 2;
            float posY = (info.Height - size) / 2;

            using (SKPath path = new SKPath())
            {
                var fillRect = SKRect.Create(info.Width, info.Height);
                var codeRect = SKRect.Create(posX, posY, size, size);
                var roundRect = new SKRoundRect(codeRect, 20);
                canvas.ClipRoundRect(roundRect, SKClipOperation.Difference, true);

                SKColor maskColor;
                SKColor.TryParse("003AB6", out maskColor);

                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = maskColor;
                    canvas.DrawRect(fillRect, paint);
                }
            }
        }

        protected override void OnDisappearing()
        {
            ScannerView.IsScanning = false;
            base.OnDisappearing();
        }

        private void ScannerView_OnScanResult(Result result)
        {
            //If not invoking on the UI thread the App crashes
            Device.BeginInvokeOnMainThread(async () => { await handleScanResults(); });
        }

        private async Task handleScanResults()
        {
            ScannerView.IsAnalyzing = false;
            Application.Current.Properties["WalletInitialized"] = true;
            await Application.Current.SavePropertiesAsync();
            var page = Navigation.NavigationStack.Last();
            await Navigation.PushAsync(new CredentialOfferReviewPage());
            Navigation.RemovePage(page);
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            //If not invoking on the UI thread the App crashes
            Device.BeginInvokeOnMainThread(async () => { await handleScanResults(); });
        }
    }
}
