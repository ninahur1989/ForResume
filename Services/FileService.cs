using System;
using System.IO;
using Modul_3_2_HW.Services.Abstractions;

namespace Modul_3_2_HW.Services
{
    public class FileService : IFileService
    {
        public string ReadAllText(string path) => File.ReadAllText(path);
    }
}
