using System;

namespace MyMvcApp.Services
{
    public class GreetingService
    {
        public string GetWelcomeMessage()
        {
            var hour = DateTime.Now.Hour;

            return hour switch
            {
                >= 5 and < 12 => "Доброе утро!",
                >= 12 and < 18 => "Добрый день!",
                >= 18 and < 23 => "Добрый вечер!",
                _ => "Доброй ночи!"
            };
        }
    }
}
