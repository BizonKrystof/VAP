using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        // Vytváření instance třídy CommandProcessor
        CommandProcessor processor = new CommandProcessor();

        // Vytváří smyčku a umožňuje pro porgram běžet bez zastavení dokud ho ručně neukončíme 
        while (true)
        {

            // Vypíše se "Vstup: " jako indikace pro zadání vstupu
            Console.Write("Vstup: ");

            // program sleduje řádek pro příkazy a veškeré zadané vstupy zadává do "command" 
            string command = Console.ReadLine();

            // zpracovává příkazy z command do processoru
            processor.ExecuteCommand(command);
        }
    }
}

class CommandProcessor
{

    // Vytvoření Listu (array)
    private List<string> words = new List<string>();

    // nastavení základní pozice pro zápis
    private int currentIndex = -1;

    public void ExecuteCommand(string command)
    {

        //Odělování příkazů pomocí :
        string[] parts = command.Split(':');

        //Pokud příkaz nebude mít pouze dva parametry vypíše se "Neplatný příkaz!"
        if (parts.Length != 2)
        {
            Console.WriteLine("Neplatný příkaz!");
            return;
        }
        //Odstraňuje případné mezery v příkazu
        string action = parts[0].Trim();
        string word = parts[1].Trim();

        switch (action)
        {

            // při zadání příkazu "Pridat" odkážeme na funkci AddWord
            case "Pridat":
                AddWord(word);
                break;

            // při zadání příkazu "Zpet" odkážeme na funkci ShowPreviousWord
            case "Zpet":
                ShowPreviousWord();
                break;

            // při zadání příkazu "Vpred" odkážeme na funkci ShowNextWord
            case "Vpred":
                ShowNextWord();
                break;

            // pokud příkaz neodpovídá víše zadaným vypíše se "Neznámý příkaz!"
            default:
                Console.WriteLine("Neznámý příkaz!");
                break;
        }
    }


    // přidá záznam do daného indexu posune index pro další zápis a vypíše zadané slovo
    private void AddWord(string word)
    {
        words.Add(word);
        currentIndex = words.Count - 1;
        Console.WriteLine(word);
    }
    // pokud index není menší než 0 pozice indexu se zmenší a vypíše se zápis na daném indexu
    private void ShowPreviousWord()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        Console.WriteLine(words[currentIndex]);
    }
    // pokud index není na posledním zadaném poli pozice indexu se posune zvětší a vypíše se zápis na daném indexu
    private void ShowNextWord()
    {
        if (currentIndex < words.Count - 1)
        {
            currentIndex++;
        }
        Console.WriteLine(words[currentIndex]);
    }
}
