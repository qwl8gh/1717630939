namespace CryptoExchangeRateProvider
{
    public partial class Form1 : Form
    {
        private readonly ICryptoExchangeRateProvider _binanceProvider;
        private readonly ICryptoExchangeRateProvider _bybitProvider;
        private readonly ICryptoExchangeRateProvider _kucoinProvider;
        private readonly ICryptoExchangeRateProvider _bitgetProvider;
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();

            _binanceProvider = new BinanceRateProvider();
            _bybitProvider = new BybitRateProvider();
            _kucoinProvider = new KucoinRateProvider();
            _bitgetProvider = new BitgetRateProvider();

            if (cmbPair.Items.Count > 0)
            {
                cmbPair.SelectedIndex = 0;
            }
        }

        private async void SubscribeToUpdates()
        {
            var pair = cmbPair.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(pair))
                return;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                SubscribeToExchange(_binanceProvider, lblBinance, pair, _cancellationTokenSource.Token);
                SubscribeToExchange(_bybitProvider, lblBybit, pair, _cancellationTokenSource.Token);
                SubscribeToExchange(_kucoinProvider, lblKucoin, pair.Replace("USDT", "-USDT"), _cancellationTokenSource.Token);
                SubscribeToExchange(_bitgetProvider, lblBitget, pair, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException e)
            {
                System.Console.WriteLine(e);
            }
        }

        private async Task SubscribeToExchange(ICryptoExchangeRateProvider provider, Label label, string pair, CancellationToken cancellationToken)
        {
            await provider.SubscribeToRateUpdatesAsync(pair, price =>
            {
                Invoke((MethodInvoker)(() => label.Text = $"{label.Name}: {price}"));
            }, cancellationToken);
        }

        private void cmbPair_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubscribeToUpdates();
        }

        protected override void Dispose(bool disposing)
        {
            _cancellationTokenSource?.Cancel();
            _binanceProvider.Dispose();
            _bybitProvider.Dispose();
            _kucoinProvider.Dispose();
            _bitgetProvider.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
