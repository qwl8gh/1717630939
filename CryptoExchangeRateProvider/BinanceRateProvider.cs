using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Clients;

namespace CryptoExchangeRateProvider
{
    public class BinanceRateProvider : ICryptoExchangeRateProvider
    {
        private readonly BinanceSocketClient _client;

        public BinanceRateProvider()
        {
            _client = new BinanceSocketClient();
        }

        public async Task SubscribeToRateUpdatesAsync(string pair, Action<decimal> onRateUpdate, CancellationToken cancellationToken)
        {
            await _client.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(pair, data =>
            {
                var price = System.Math.Round(data.Data.LastPrice, 2);
                onRateUpdate(price);
            }, cancellationToken);
        }

        public Task UnsubscribeFromRateUpdatesAsync()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
