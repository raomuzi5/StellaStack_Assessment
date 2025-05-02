using ProductCatalogApp.BlazorClient.Shared;
using System.Net.Http.Json;

namespace ProductCatalogApp.BlazorClient.Client.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int productId);
        Task CreateAsync(ProductDto product);
        Task UpdateAsync(ProductDto product);
        Task DeleteAsync(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/product");
        }

        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"api/product/{productId}");
        }

        public async Task CreateAsync(ProductDto product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(ProductDto product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"api/product/{productId}");
            response.EnsureSuccessStatusCode();
        }
    }

}
