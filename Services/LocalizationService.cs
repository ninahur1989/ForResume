using Modul_3_2_HW.Services.Abstractions;
using System.Globalization;

namespace Modul_3_2_HW.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IConfigService _configService;

        public LocalizationService(IConfigService configService)
        {
            _configService = configService;
        }

        public string GetAlphabetForCurrentCulture()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            return GetAlhpabetByCulture(culture);
        }

        public string GetAlhpabetByCulture(string cultureName)
        {
            var lang = _configService.LangConfig;
            return lang.Alphabets.ContainsKey(cultureName) ? lang.Alphabets[cultureName] : lang.Alphabets[lang.DefaultCulture];
        }
    }
}
