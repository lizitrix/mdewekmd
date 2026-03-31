using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public string GetBrandModelCombined()
    {
        string upperBrand = Brand.ToUpper();
        string lowerModel = Model.ToLower();
        string combined = upperBrand + " - " + lowerModel;
        string replacedCombined = combined.Replace(" ", "_");
        return replacedCombined;
    }

    public string GetCarInfo()
    {
        string info = Brand + " " + Model + " (" + Year + ")";
        if (info.Contains("20"))
        {
            int yearIndex = info.IndexOf(Year.ToString());
            if (yearIndex >= 0 && info.Length > yearIndex + 4)
            {
                string yearPart = info.Substring(yearIndex, 4);
                info = info.Replace(yearPart, "[" + yearPart + "]");
            }
        }
        return info;
    }
}

public class CarManager
{
    private List<Car> cars;

    public CarManager()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public List<Car> FilterByBrand(string brand)
    {
        return cars.FindAll(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));
    }

    public List<Car> FindCarsOlderThan(int year)
    {
        return cars.FindAll(c => c.Year < year);
    }

    public void DisplayCars(List<Car> carsToDisplay)
    {
        foreach (var car in carsToDisplay)
        {
            Console.WriteLine(car.GetCarInfo());
            string combined = car.GetBrandModelCombined();
            string[] parts = combined.Split('-');
            Console.WriteLine("  Combined (Brand-Model): " + combined);
            Console.WriteLine("  Split parts count: " + parts.Length);
            Console.WriteLine("  Brand length: " + car.Brand.Length);
        }
    }
}

public class Program
{
    public static void Main()
    {
        CarManager manager = new CarManager();

        manager.AddCar(new Car("Toyota", "Camry", 2015));
        manager.AddCar(new Car("Honda", "Civic", 2008));
        manager.AddCar(new Car("Toyota", "Corolla", 2020));
        manager.AddCar(new Car("Ford", "Focus", 2010));
        manager.AddCar(new Car("BMW", "X5", 2019));

        Console.WriteLine("All cars:");
        manager.DisplayCars(manager.FilterByBrand(""));

        Console.WriteLine("\nToyota cars:");
        manager.DisplayCars(manager.FilterByBrand("Toyota"));

        Console.WriteLine("\nCars older than 2012:");
        manager.DisplayCars(manager.FindCarsOlderThan(2012));
    }
}
