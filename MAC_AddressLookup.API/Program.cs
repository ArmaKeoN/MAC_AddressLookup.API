using MAC_AddressLookup.API;
using Newtonsoft.Json;
using System.Net.Http.Headers;

Console.WriteLine("Please proivde a MAC address: ");
string macAddress = Console.ReadLine();

string url = $"https://api.macaddress.io/v1?apiKey=at_7rligFVhix4xCZ5GR68QQ5C6MdVvB&output=json&search={macAddress}";

using HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Accept.Add(
   new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = client.GetAsync(url).Result;
Root root = new Root();

if (response.IsSuccessStatusCode)
{
    string jsonResult = await response.Content.ReadAsStringAsync();
    root = JsonConvert.DeserializeObject<Root>(jsonResult);
}
else
{
    Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                  response.ReasonPhrase);
}

if (root.macAddressDetails.isValid)
{
    Console.WriteLine("The provided MAC Address to search for is valid and here are the following details:");
    Console.WriteLine("Company Name: " + root.vendorDetails.companyName);
    Console.WriteLine("MAC Address: " + root.macAddressDetails.searchTerm);
    Console.ReadLine();
}