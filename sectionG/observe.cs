using System;
using System.Collections.Generic;

// Observer Interface
interface IObserver
{
    void Update(string weather);
}

// Subject Interface
interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// ConcreteSubject Class
class WeatherStation : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string weather;

    public void AddObserver(IObserver observer)
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
            observer.Update(weather);
        }
    }

    public void SetWeather(string newWeather)
    {
        weather = newWeather;
        NotifyObservers();
    }
}

// ConcreteObserver Class
class PhoneDisplay : IObserver
{
    private string weather;

    public void Update(string weather)
    {
        this.weather = weather;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("Phone Display: Weather updated - " + weather);
    }
}

// ConcreteObserver Class
class TVDisplay : IObserver
{
    private string weather;

    public void Update(string weather)
    {
        this.weather = weather;
        Display();
    }

    private void Display()
    {
        Console.WriteLine("TV Display: Weather updated - " + weather);
    }
}

// Usage
class WeatherApp
{
    static void Main(string[] args)
    {
        WeatherStation weatherStation = new WeatherStation();

        IObserver phoneDisplay = new PhoneDisplay();
        IObserver tvDisplay = new TVDisplay();

        // Register observers
        weatherStation.AddObserver(phoneDisplay);
        weatherStation.AddObserver(tvDisplay);

        // Simulating weather changes
        weatherStation.SetWeather("Sunny");
        weatherStation.SetWeather("Rainy");
        weatherStation.SetWeather("Cloudy");

        // Remove one observer
        weatherStation.RemoveObserver(tvDisplay);

        // Notify remaining observer
        weatherStation.SetWeather("Windy");
    }
}
