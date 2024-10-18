using System.Text.Json.Serialization;

namespace Digital_Cloud_Technologies;

public class CryptoResponse<T>
{
    [JsonPropertyName("data")]
    public IList<T> Response { get; set; } = null!;
}
