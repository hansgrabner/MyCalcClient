using Newtonsoft.Json;
using System.Text;

public class Calculation
{
    public int Number1 { get; set; }
    public int Number2 { get; set; }
    public int Result { get; set; }
}

public class MyClientApp
{
    public static void Main()
    {
        Calculation c1 = new Calculation();
        c1.Number1 = 12;
        c1.Number2 = 20;
        Post(c1);
    }

    public static void Post(Calculation c)
    {
      

        var json = JsonConvert.SerializeObject(c);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        HttpClient client = new HttpClient();

        string url = "https://localhost:7256/api/Calculation";

        var response = client.PostAsync(url, data).Result;
       

        var result = response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }

}