namespace CSharp12_Patern_5_15_03
{
    interface IObserver
    {
        void Update(int temperature, int humidity);
    }

    // Конкретний спостерігач (наприклад, дисплей погоди)
    class WeatherDisplay : IObserver
    {
        public void Update(int temperature, int humidity)
        {
            Console.WriteLine($"Weather display: Temperature {temperature}°C, Humidity {humidity}%");
        }
    }

    // Інтерфейс суб'єкта
    interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Стан погоди 
    class WeatherStation : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private int temperature;
        private int humidity;

        public void SetWeather(int temperature, int humidity)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо стан погоди
            WeatherStation weatherStation = new WeatherStation();

            // Створюємо дисплеї погоди)
            WeatherDisplay display1 = new WeatherDisplay();
            WeatherDisplay display2 = new WeatherDisplay();

            // Реєструємо дисплеї погоди у стан погоди
            weatherStation.RegisterObserver(display1);
            weatherStation.RegisterObserver(display2);

            // Встановлюємо новий стан погоди
            weatherStation.SetWeather(25, 70);

            // Видаляємо одного зі дисплеїв погоди
            weatherStation.RemoveObserver(display1);

            // Встановлюємо новий стан погоди
            weatherStation.SetWeather(20, 60);
        }
    }
}
