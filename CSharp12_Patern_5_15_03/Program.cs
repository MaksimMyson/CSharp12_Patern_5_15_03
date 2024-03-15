namespace CSharp12_Patern_5_15_03
{
    // Погода
    class Weather
    {
        public string City { get; private set; }
        public int Temperature { get; private set; }
        public int Humidity { get; private set; }

        public Weather(string city, int temperature, int humidity)
        {
            City = city;
            Temperature = temperature;
            Humidity = humidity;
        }

        public void Display()
        {
            Console.WriteLine($"Weather in {City}: Temperature {Temperature}°C, Humidity {Humidity}%");
        }
    }

    // Знімок стану погоди
    class WeatherSnapshot
    {
        public Weather Weather { get; }

        public WeatherSnapshot(Weather weather)
        {
            Weather = weather;
        }
    }

    //   Зберігання та відновлення знімків стану погоди
    class Caretaker
    {
        public WeatherSnapshot Snapshot { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //  Початковий стан погоди
            Weather initialWeather = new Weather("New York", 20, 60);
            initialWeather.Display();

            // Зберігаємо знімок поточного стану погоди
            WeatherSnapshot snapshot = new WeatherSnapshot(initialWeather);
            Caretaker caretaker = new Caretaker();
            caretaker.Snapshot = snapshot;

            // Змінюємо стан погоди
            initialWeather = new Weather("Chicago", 15, 50);
            initialWeather.Display();

            // Відновлюємо попередній стан погоди з знімка
            initialWeather = caretaker.Snapshot.Weather;
            Console.WriteLine("Restoring previous weather state...");
            initialWeather.Display();
        }
    }
}
