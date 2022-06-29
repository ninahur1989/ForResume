using System;
using Modul_3_2_HW.Helpers;
using Modul_3_2_HW.Helpers.GropedList;
using Modul_3_2_HW.Models;
using Modul_3_2_HW.Services.Abstractions;

namespace Modul_3_2_HW.Controllers
{
    public class ActionController
    {
        private readonly ILocalizationService _localizationService;

        public ActionController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public void Action()
        {
            var alphabet = _localizationService.GetAlphabetForCurrentCulture();

            var willBeRemove1 = new Contact() { FirstName = "Dfg" };
            var willBeRemove2 = new Contact() { FirstName = "46fg" };

            var groupedList = new GroupedList<Contact>(alphabet)
            {
                new Contact() { FirstName = "acg" },
                new Contact() { FirstName = "36fg" },
                willBeRemove1,
                willBeRemove2,
                new Contact() { FirstName = "afg" },
                new Contact() { FirstName = "гоу" },
                new Contact() { FirstName = "авгоу" },
                new Contact() { FirstName = "tfy" },
                new Contact() { FirstName = "_tfy" },
                new Contact() { FirstName = "_afy" },
                new Contact() { FirstName = "abg" },
            };

            Console.WriteLine("--------------En----------------");

            foreach (var items in groupedList)
            {
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"Key = {items.Key} Value = {item.FullName}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------RU----------------");

            var lang = _localizationService.GetAlhpabetByCulture("ru_RU");
            groupedList.ChangeAlhabet(lang);

            foreach (var items in groupedList)
            {
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"Key = {items.Key} Value = {item.FullName}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------After remove----------------");

            groupedList.Remove(willBeRemove1);
            groupedList.Remove(willBeRemove2);

            foreach (var items in groupedList)
            {
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"Key = {items.Key} Value = {item.FullName}");
                }
                Console.WriteLine();
            }
        }
    }
}
