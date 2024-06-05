using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitget.Net.Clients;

namespace CryptoExchangeRateProvider
{
    public class BitgetRateProvider : ICryptoExchangeRateProvider
    {
        private readonly BitgetSocketClient _client;

        public BitgetRateProvider()
        {
            _client = new BitgetSocketClient();
        }

        public async Task SubscribeToRateUpdatesAsync(string pair, Action<decimal> onRateUpdate, CancellationToken cancellationToken)
        {
            await _client.SpotApi.SubscribeToTickerUpdatesAsync(pair, data =>
            {
                var price = data.Data.LastPrice;
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
