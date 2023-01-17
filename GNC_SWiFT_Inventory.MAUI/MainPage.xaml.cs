using ZXing.Net.Maui;

namespace GNC_SWiFT_Inventory.MAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
       
        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
        {
            Formats = BarcodeFormat.Code39
        };
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
         {
       barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
         });
    }

    private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });
    }
}

