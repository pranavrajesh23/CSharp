using System;
using System.Threading.Tasks;
class Program{
    static async Task Main(string[] args){
        Console.WriteLine("Fetching data...");
        string data = await FetchDataAsync();
        Console.WriteLine($"Data received: {data}");
    }
    static async Task<string> FetchDataAsync(){
        await Task.Delay(2000);
        return "Sample data from server";
    }
}
