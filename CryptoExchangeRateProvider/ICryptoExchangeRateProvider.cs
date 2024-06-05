using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchangeRateProvider
{
    public interface ICryptoExchangeRateProvider
    {
        Task SubscribeToRateUpdatesAsync(string pair, Action<decimal> onRateUpdate, CancellationToken cancellationToken);
        Task UnsubscribeFromRateUpdatesAsync();
        void Dispose();

    }
}
