using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kucoin.Net.Clients;

namespace CryptoExchangeRateProvider
{
    public class KucoinRateProvider : ICryptoExchangeRateProvider
    {
        private readonly KucoinSocketClient _client;

        public KucoinRateProvider()
        {
            _client = new KucoinSocketClient();
        }

        public async Task SubscribeToRateUpdatesAsync(string pair, Action<decimal> onRateUpdate, CancellationToken cancellationToken)
        {
            await _client.SpotApi.SubscribeToTickerUpdatesAsync(pair, data =>
            {
                var price = data.Data.LastPrice;
                onRateUpdate((decimal)price);
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
