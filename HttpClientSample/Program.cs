using HttpClientSample;
using System.Net.Http.Headers;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

HttpClient client = new();

void ShowCard(Card card)
{
    Console.WriteLine($"Description: \t{card.Description}");
}

async Task<Card> GetCardAsync(string id)
{
    Card card = null;

    HttpResponseMessage response = await client.GetAsync(id);
    if (response.IsSuccessStatusCode)
    {
        card = await response.Content.ReadAsAsync<Card>();
    }
    return card;
}

async Task RunAsync()
{
    client.BaseAddress = new Uri("https://deathtrapdungeonapiver1.azurewebsites.net/api/card/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    try
    {
        Card card = new();
        card = await GetCardAsync("35");
        ShowCard(card);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.ReadLine();
}

RunAsync().GetAwaiter().GetResult();