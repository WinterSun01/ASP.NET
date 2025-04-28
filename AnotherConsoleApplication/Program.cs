namespace AnotherConsoleApplication
{
    //
    // SOLID
    //

    //
    // S - Single Responsibility Principle (SRP)
    //
    // Модуль должен отвечать за одного и только одного актора
    // ---
    // Идея: Класс должен отвечать только за одну задачу
    // Зачем: Чтобы изменения в одной части логики (программы) не ломали другие.
    //

    // Плохой пример:

    class Report_BadSolution
    {
        public string Text { get; set; }

        public void Print()
        {
            Console.WriteLine(Text);
        }

        public void SaveToFile(string filePath)
        {
            //...
        }
    }

    // Хороший пример:

    class Report
    {
        private string _text;

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }
    }

    class ReportPrinter
    {
        public void Print(Report report)
        {
            Console.WriteLine(report.GetText());
        }
    }

    class ReportSaver
    {
        public void SaveToFile(Report report, string filePath)
        {
            //...
        }
    }

    //
    // O - Open/Closed Principle
    // Программные сущности (классы) должны быть открыты для расширения, но закрыты
    // для модификации
    // Зачем: Чтобы можно было добавлять новую функциональность, не трогая существующий код
    //

    // Плохой пример

    class NotificationService_BadSolution
    {
        public void SendNotification(string message, string type)
        {
            if (type == "Email")
                Console.WriteLine("Email: ...");
            else if (type == "SMS")
                Console.WriteLine("SMS: ...");
            else if (type == "WhatsApp")
                Console.WriteLine("WhatsApp: ...");
            else if (type == "Telegram")
                Console.WriteLine("Telegram: ...");
        }
    }

    // Хороший пример

    interface INotifier
    {
        void SendNotification(string message);
    }

    class EmailNotifier : INotifier
    {
        public void SendNotification(string message)
        {
            // Sending email...
        }
    }

    class SMSNotifier : INotifier
    {
        public void SendNotification(string message)
        {
            // Sending SMS...
        }
    }

    class NotificationService
    {
        private readonly INotifier _notifier;
        public NotificationService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void SendNotification(string message)
        {
            _notifier.SendNotification(message);
        }
    }

    //
    // L - Liskov Substitution Principle (Принцип подстановки Лисков)
    // Функции, которые используют базовый тип, должны иметь возможность использовать подтипы базового типа не зная об этом.
    //
    // Идея: Подкласс должен вести себя как родительский класс, не ломая логику
    // Зачем: Чтобы можно было спокойно заменить родительский класс на потомка класса
    //

    // Плохой пример

    class Bird_BadSolution
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying...");
        }
    }

    class Penguin_BadSolution : Bird_BadSolution
    {
        public override void Fly()
        {
            Console.WriteLine("Penguins can't fly!!!");
        }
    }

    // Хороший пример

    class Bird
    {
        public virtual void Eat()
        {
            Console.WriteLine("Bird eating...");
        }
    }

    interface IFlyingBird
    {
        void Fly();
    }

    class Pigeon : Bird, IFlyingBird
    {
        public void Fly()
        {
            Console.WriteLine("Pigeon flying...");
        }
    }

    class Penguin : Bird
    {

    }

    //
    // I - Interface Segregation Principle (ISP) (Принцип разделения интерфейса)
    //
    // Много интерфейсов, специально предназначенных для клиентов, лучше, чем один интерфейс общего назначения
    //
    // Идея: Не заставляй класс реализовывать ненужные (!) методы
    // Зачем: Чтобы классы были простыми и понятными
    //

    // Плохой пример

    interface IWorker_BadSolution
    {
        void Work();
        void Eat();
    }

    class Employee_BadSolution : IWorker_BadSolution
    {
        public void Eat()
        {
            // Employee eating...
        }

        public void Work()
        {
            // Employee working...
        }
    }

    class Robot_BadSolution : IWorker_BadSolution
    {
        public void Eat()
        {
            // Do nothing...
        }

        public void Work()
        {
            // Robot working...
        }
    }

    // Хороший пример

    interface IWorkable
    {
        void Work();
    }

    interface IFeedable
    {
        void Eat();
    }

    class Eployee : IWorkable, IFeedable
    {
        public void Eat()
        {
            // Eating...
        }

        public void Work()
        {
            // Working...
        }
    }

    class Robot : IWorkable
    {
        public void Work()
        {
            // Working...
        }
    }

    //
    // D - Dependency Inversion Principle (DIP) (Принцип инверсии зависимостей)
    //
    // Зависимость на Абстракциях. Нет зависимости на что-то конкретное.
    // 
    // Идея: Зависимости должны быть абстрактными, а не конкретными
    // Зачем: Чтобы можно было легко менять детали реализации
    //
    //

    // Плохой пример

    class ConsoleLogger_BadSolution
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogger_BadSolution
    {
        public void Log(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class OrderService_BadSolution
    {
        private readonly FileLogger_BadSolution _logger = new FileLogger_BadSolution();

        public void ProcessOrder()
        {
            // Something...
            _logger.Log("Order processed.");
        }
    }

    // Хороший пример

    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.WriteAllText("logs.txt", message);
        }
    }

    class OrderService
    {
        private readonly ILogger _logger;

        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public void ProcessOrder()
        {
            // Something...
            _logger.Log("Order processed.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            /*
            Bird penguin = new Penguin();
            penguin.Eat();

            Pigeon pigeon = new Pigeon();
            pigeon.Eat();
            pigeon.Fly();
            */

            ILogger logger = new FileLogger();

            OrderService orderService = new OrderService(logger);
            orderService.ProcessOrder();
        }
    }
}