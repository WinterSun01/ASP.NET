using Microsoft.Extensions.DependencyInjection;

namespace Homework2
{
    //интерфейс для логирования
    interface ILogger
    {
        void Log(string message);
    }

    //вывод логирования в консоль
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    //интерфейс муз. жанра
    interface IMusic
    {
        string GetGenre();
    }

    //класс для реализации муз. жанра
    class RockMusic : IMusic
    {
        public string GetGenre()
        {
            return "Rock";
        }
    }

    //муз. проигрыватель
    class MusicPlayer
    {
        private readonly ILogger _logger;
        private readonly IMusic _music;

        public MusicPlayer(ILogger logger, IMusic music)
        {
            _logger = logger;
            _music = music;
        }

        public void PlayMusic()
        {
            _logger.Log($"Playing {_music.GetGenre()} music...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //создание DI-контейнера
            IServiceCollection serviceCollection = new ServiceCollection();

            //регистрация зависимостей
            serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
            serviceCollection.AddSingleton<IMusic, RockMusic>();
            serviceCollection.AddSingleton<MusicPlayer>();

            //создание ServiceProvider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            //получение и использование MusicPlayer
            MusicPlayer musicPlayer = serviceProvider.GetRequiredService<MusicPlayer>();
            musicPlayer.PlayMusic();
        }
    }
}

