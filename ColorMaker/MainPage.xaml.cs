
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string? hexValue;
        string? hexValuetwo;
        public MainPage() => InitializeComponent();

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            lblTitle.BackgroundColor = color.GetComplementary();
            lblTitle.TextColor = color;
            btnRandom.BackgroundColor = color.GetComplementary();
            btnRandom.TextColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
            hexValuetwo = color.GetComplementary().ToHex();
            lblHex2.Text = hexValuetwo;
            sldRed.ThumbColor = color;
            sldGreen.ThumbColor = color.GetComplementary();
            sldBlue.ThumbColor = color;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 255),
                random.Next(0, 255),
                random.Next(0, 255)
                );

            SetColor(color);

            sldBlue.Value = color.Blue;
            sldGreen.Value = color.Green;
            sldRed.Value = color.Red;
            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color copiado", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValuetwo);
            var toast = Toast.Make("Color copiado", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
    }

}
