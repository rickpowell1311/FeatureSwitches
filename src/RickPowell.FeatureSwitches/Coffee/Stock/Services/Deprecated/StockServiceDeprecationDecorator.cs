using RickPowell.FeatureSwitches.Coffee.Stock.Domain;
using RickPowell.FeatureSwitches.FeatureSwitches.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickPowell.FeatureSwitches.Coffee.Stock.Services.Deprecated
{
    public class StockServiceDeprecationDecorator : IStockService
    {
        private readonly ISettingsService _settingsService;
        private readonly Services.StockService _candidate;
        private readonly StockService _deprecated;

        public StockServiceDeprecationDecorator(
            Services.StockService candidate, 
            Deprecated.StockService deprecated, 
            ISettingsService settingsService)
        {
            _candidate = candidate;
            _deprecated = deprecated;
            _settingsService = settingsService;
        }

        public async Task<Quantity> GetQuantity(Blend blend)
        {
            var settings = await _settingsService.GetSettings();

            if (!settings.UseImprovedStockService)
            {
                return await _deprecated.GetQuantity(blend);
            }

            return await _candidate.GetQuantity(blend);
        }
    }
}
