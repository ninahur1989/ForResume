using System;
using Modul_3_2_HW.Controllers;
using Modul_3_2_HW.Services.Abstractions;

namespace Modul_3_2_HW.Services
{
    public static class LocatorService
    {
        public static IConfigService ConfigService => new ConfigService(new FileService());
        public static ILocalizationService LocalizationService => new LocalizationService(ConfigService);


        public static ActionController ActionController => new ActionController(LocalizationService);
    }
}
