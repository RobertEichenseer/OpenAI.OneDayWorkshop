using Azure;

using Azure.Storage.Blobs;
using Azure.Storage.Sas;

using System.Text;
using System.Text.Json;
using System.Net.Http;

public class AiVisionHelper {

    private string _apiKeyVision = "";
    private string _endPointVision = "";

    private string _apiKeySearch = "";
    private string _endPointSearch = "";

    private string _connectionStringStorage = "";

    private string _textEmbeddingUrl = @"{AR_VISION_ENDPOINT}/computervision/retrieval:vectorizeText?api-version=2023-02-01-preview&modelVersion=latest";
    private string _imageEmbeddingUrl = @"{AR_VISION_ENDPOINT}/computervision/retrieval:vectorizeImage?api-version=2023-02-01-preview&modelVersion=latest";
    private string _imageEmbeddingPayload = @"{""url"":""{IMAGE_URL}""}";
    
    public AiVisionHelper(
        string apiKeyVision, string endPointVision, 
        string connectionStringStorage)
    {
        _apiKeyVision = apiKeyVision;
        _endPointVision = endPointVision;
        
        _connectionStringStorage = connectionStringStorage;

    }

    public async Task<float[]> GetTextEmbedding(string text)
    {
        //Compose API url & request payload
        string url = _textEmbeddingUrl.Replace("{AR_VISION_ENDPOINT}", _endPointVision);
        string requestPayload = $"{{\"text\":\"{text}\"}}";

        return  await GetEmbedding(url, requestPayload);
    }

    public async Task<float[]> GetImageEmbedding(string imageUrl)
    {
        //Compose API url & request payload
        string url = _imageEmbeddingUrl.Replace("{AR_VISION_ENDPOINT}", _endPointVision);
        string requestPayload = _imageEmbeddingPayload.Replace("{IMAGE_URL}", imageUrl);

        return await GetEmbedding(url, requestPayload);
    }

    private async Task<float[]> GetEmbedding(string url, string requestPayload)
    {
        //Post request to url
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKeyVision);
        HttpContent httpContent = new StringContent(requestPayload, Encoding.UTF8, "application/json");
        
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url) {
            Content = httpContent
        };
        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        //Check if request was successful
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {httpResponseMessage.StatusCode}");
            return new float[0];
        }
        
        //Parse response
        JsonDocument jsonDocument = JsonDocument.Parse(
            await httpResponseMessage.Content.ReadAsStringAsync()
        );

        return jsonDocument
                .RootElement.GetProperty("vector")
                .EnumerateArray()
                .Select(element => element.GetSingle())
                .ToArray();
    }

    public async Task<Uri> UploadLocalFile(string localFilePath, string containerName, string blobName)
    {
        //Create blob client
        BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionStringStorage);
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

        //Check if container exists and if not create it
        if (!await blobContainerClient.ExistsAsync())
        {
            await blobContainerClient.CreateAsync();
        }

        //Upload file
        using FileStream fileStream = File.OpenRead(localFilePath);
        await blobClient.UploadAsync(fileStream, true);

        //Create SAS token 
        BlobSasBuilder blobSasBuilder = new BlobSasBuilder() {
            BlobContainerName = containerName,
            BlobName = blobName,
            Resource = "b"
        };
        blobSasBuilder.SetPermissions(BlobSasPermissions.Read);
        blobSasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
        Uri sasUri = blobClient.GenerateSasUri(blobSasBuilder);

        return sasUri;

    }
}

public class ImageEmbedding
{
    public string ImageId { get; set; } = "";
    public string ImageDescription { get; set; } = "";
    public float[] ImageVector { get; set; } = new float[1024];
}
