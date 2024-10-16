using System.Text.Json.Serialization;

namespace Digital_Cloud_Technologies;

public class CryptoCurrency
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("rank")]
    public string Rank { get; set; } = null!;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = null!; 

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("supply")]
    public string Supply { get; set; } = null!; 

    [JsonPropertyName("maxSupply")]
    public string MaxSupply { get; set; } = null!;

    [JsonPropertyName("marketCapUsd")]
    public string MarketCapUsd { get; set; } = null!; 

    [JsonPropertyName("volumeUsd24Hr")]
    public string VolumeUsd24Hr { get; set; } = null!;

    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; set; } = null!; 

    [JsonPropertyName("changePercent24Hr")]
    public string ChangePercent24Hr { get; set; } = null!; 

    [JsonPropertyName("vwap24Hr")]
    public string Vwap24Hr { get; set; } = null!;

    [JsonPropertyName("explorer")]
    public string Explorer { get; set; } = null!;

    public override string ToString()
    {
        return $"Id = {Id}\n" +
               $"Rank = {Rank}\n" +
               $"Symbol = {Symbol}\n" +
               $"Name = {Name}\n" +
               $"Supply = {Supply}\n" +
               $"MaxSupply = {MaxSupply}\n" +
               $"MarketCapUsd = {MarketCapUsd}\n" +
               $"VolumeUsd24Hr = {VolumeUsd24Hr}\n" +
               $"PriceUsd = {PriceUsd}\n" +
               $"ChangePercent24Hr = {ChangePercent24Hr}\n" +
               $"Vwap24Hr = {Vwap24Hr}\n" +
               $"Explorer = {Explorer}\n";
    }

    public string NumberingItems
    {
        get 
        {
            return $"{Rank}. {Name}";
        }
    }
}

   /* "id": "bitcoin",
      "rank": "1",
      "symbol": "BTC",
      "name": "Bitcoin",
      "supply": "19768068.0000000000000000",
      "maxSupply": "21000000.0000000000000000",
      "marketCapUsd": "1318696724384.1552138481176876",
      "volumeUsd24Hr": "13659500623.3964832459430735",
      "priceUsd": "66708.4271656772535307",
      "changePercent24Hr": "1.2167773961671586",
      "vwap24Hr": "66207.6050318988444482",
      "explorer": "https://blockchain.info/" */