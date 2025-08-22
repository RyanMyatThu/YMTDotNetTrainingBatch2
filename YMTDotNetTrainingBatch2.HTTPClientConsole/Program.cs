// See https://aka.ms/new-console-template for more information
HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7228/api/Products/List/1/10");
if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();
    Console.WriteLine(json);
}