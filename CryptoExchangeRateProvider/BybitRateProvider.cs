using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bybit.Net.Clients;

namespace CryptoExchangeRateProvider
{
    public class BybitRateProvider : ICryptoExchangeRateProvider
    {
        private readonly BybitSocketClient _client;

        public BybitRateProvider()
        {
            _client = new BybitSocketClient();
        }

        public async Task SubscribeToRateUpdatesAsync(string pair, Action<decimal> onRateUpdate, CancellationToken cancellationToken)
        {
            await _client.V5SpotApi.SubscribeToTickerUpdatesAsync(pair, data =>
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
