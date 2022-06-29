using System;

namespace Modul_3_2_HW.Services.Abstractions
{
    public interface ILocalizationService
    {
        string GetAlphabetForCurrentCulture();
        string GetAlhpabetByCulture(string cultureDisplayName);
    }
}
