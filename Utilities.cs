using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Digital_Cloud_Technologies;

public class Utilities
{
    private static string RootPath = "api.coincap.io";
    private static string Version = "v2";
    private static string Method = "assets";

    private static HttpClient httpClient = new HttpClient();

    public static string PrettyJson(string unPrettyJson)
    {
        var oprions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

        return JsonSerializer.Serialize(jsonElement, oprions);
    }

    public static async Task<CryptoResponse<CryptoCurrency>?> FetchCryptoCoinInfo()
    {
        HttpResponseMessage response = await httpClient.GetAsync($"https://{RootPath}/{Version}/{Method}");

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<CryptoResponse<CryptoCurrency>>(content);
    }

    public static string FormatCryptoResponse(CryptoResponse<CryptoCurrency> cryptoResponse)
    {
        var result = new StringBuilder();

        foreach (var coin in cryptoResponse.Response)
        {
             result.AppendLine(coin.ToString());
        }

        return result.ToString();
    }
}
