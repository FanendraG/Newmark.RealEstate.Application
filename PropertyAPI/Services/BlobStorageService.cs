using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstateApi.Configurations;
using RealEstateApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApi.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly AzureBlobSettings _settings;
        private readonly HttpClient _httpClient;

        public BlobStorageService(IOptions<AzureBlobSettings> settings)
        {
            _settings = settings.Value;
            _httpClient = new HttpClient();
        }

        public async Task<(List<Property>?, string?)> GetPropertiesAsync()
        {
            try
            {
                // Construct full URL with SAS Token
                string blobFullUrl = $"{_settings.BlobUrl}{_settings.SasToken}";

                // Fetch JSON content from Azure Blob Storage
                HttpResponseMessage response = await _httpClient.GetAsync(blobFullUrl);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, "Blob not found: The requested JSON file does not exist.");
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return (null, "Unauthorized access: Invalid or expired SAS token.");
                }
                if (!response.IsSuccessStatusCode)
                {
                    return (null, $"Unexpected error: {response.ReasonPhrase} ({(int)response.StatusCode})");
                }

                // Read and deserialize JSON
                string jsonContent = await response.Content.ReadAsStringAsync();
                var properties = JsonConvert.DeserializeObject<List<Property>>(jsonContent);

                if (properties == null)
                {
                    return (null, "Deserialization error: JSON format is invalid.");
                }

                return (properties, null);
            }
            catch (HttpRequestException httpEx)
            {
                return (null, $"Network error: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                return (null, $"JSON Parsing error: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                return (null, $"Server error: {ex.Message}");
            }
        }
    }
}
