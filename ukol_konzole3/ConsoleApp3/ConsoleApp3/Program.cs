using System;
using System.Collections.Generic;

class CityDatabase
{
    //cities může obsahovat 2 stringy ... 1. Název 2.Počet obyvatel
    private Dictionary<string, string> cities = new Dictionary<string, string>();

    // přidává názvy samostatným stringům
    public void AddCity(string name, string population)
    {
        cities[name] = population;
    }

    // pokud vybereme správně zadané jméno města z databáze vrátí nám jeho přidělenou populaci pokud je jmeno špatně vrátí Nezname mesto
    public string GetPopulation(string name)
    {
        return cities.ContainsKey(name) ? cities[name] : "Nezname mesto";
    }

    // Vypíše poslední zadané město a jeho populaci
    public string GetLastCity()
    {
        if (cities.Count == 0)
            return "V aplikaci nejsou zadne mesta";

        var lastCity = new KeyValuePair<string, string>(null, null);
        foreach (var city in cities)
        {
            lastCity = city;
        }
        return $"{lastCity.Key}: {lastCity.Value}";
    }

    // Vypíše veškerá zadaná města a jejich populaci
    public string GetAllCities()
    {
        if (cities.Count == 0)
            return "V aplikaci nejsou zadne mesta";

        string allCities = "";
        foreach (var city in cities)
        {
            allCities += $"{city.Key}: {city.Value}\n";
        }
        return allCities;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CityDatabase database = new CityDatabase();
        while (true)
        {
            // Sleduje řádek, pokud je první zadaný comand "pridej"  následovně můžeme zadat jméno následně populaci vždy odděleno mezerou to se následně zapíše do Dabáze
            string[] command = Console.ReadLine().Split();
            if (command[0].ToLower() == "pridej")
            {
                string cityName = command[1];
                string population = command[2];
                database.AddCity(cityName, population);
            }
            //  Pokud první zadaný comand není "pridej" ale je "obyvatele" můžeme zadat jméno města z databáze se vypíše populace daného města
            else if (command[0].ToLower() == "obyvatele")
            {
                string cityName = command[1];
                string population = database.GetPopulation(cityName);
                Console.WriteLine(population);
            }
            // Pokud první zadaný command je "posledni" z databáze se vypíše poslední zápis
            else if (command[0].ToLower() == "posledni")
            {
                string lastCityInfo = database.GetLastCity();
                Console.WriteLine(lastCityInfo);
            }
            // Pokud první zadaný command je "mesta" z databáze se vypíšou veškeré zápisy
            else if (command[0].ToLower() == "mesta")
            {
                string allCitiesInfo = database.GetAllCities();
                Console.WriteLine(allCitiesInfo);
            }
            else
            {
                // Pokud první command neodpovídá žádým víše zadaným vypíše se "Neznamy prikaz"
                Console.WriteLine("Neznamy prikaz");
            }
        }
    }
}