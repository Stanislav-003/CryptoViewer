using System.Text.Json.Serialization;

namespace CryptoViewer;

public class CryptoResponse<T>
{
    [JsonPropertyName("data")]
    public IList<T> Response { get; set; } = null!;
}
