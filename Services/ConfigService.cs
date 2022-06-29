using Modul_3_2_HW.Config;
using Modul_3_2_HW.Services.Abstractions;
using Newtonsoft.Json;

namespace Modul_3_2_HW.Services
{
    public class ConfigService : IConfigService
    {
        private readonly string _filePath = "config.json";
        private readonly IFileService _fileService;
        private readonly LangConfig _langConfig;

        public ConfigService(IFileService fileService)
        {
            _fileService = fileService;

            var config = GetConfig();
            _langConfig = config.Langs;
        }

        public LangConfig LangConfig => _langConfig;

        private Config.Config GetConfig()
        {
            var json = _fileService.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<Config.Config>(json);
        }
    }
}
