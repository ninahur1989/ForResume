using System;
using Modul_3_2_HW.Services;

namespace Modul_3_2_HW
{
    public class Starter
    {
        public void Run()
        {
            var controller = LocatorService.ActionController;
            controller.Action();
        }
    }
}
