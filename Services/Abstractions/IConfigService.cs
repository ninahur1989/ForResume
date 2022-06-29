using System;
using Modul_3_2_HW.Config;

namespace Modul_3_2_HW.Services.Abstractions
{
    public interface IConfigService
    {
        LangConfig LangConfig { get; }
    }
}
