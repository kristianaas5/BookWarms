using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace BookWarms.web.Services;

public class ReviewsApiClient
{
    private readonly HttpClient _http;
    public ReviewsApiClient(HttpClient http) => _http = http;

    public record CreateReviewRequest(int LibraryId, int Rating, string ReviewText);
    public record BookReviewItemDto(int Id, int Rating, string ReviewText, DateTime Date, string Username);
    public record BookReviewsDto(double AverageRating, List<BookReviewItemDto> Reviews);

    public async Task<bool> AddReviewAsync(int libraryId, int rating, string reviewText, CancellationToken ct = default)
        => (await _http.PostAsJsonAsync("api/reviews", new CreateReviewRequest(libraryId, rating, reviewText), ct)).IsSuccessStatusCode;

    public async Task<BookReviewsDto> GetReviewsByBookAsync(int bookId, CancellationToken ct = default)
    {
        try
        {
            return await _http.GetFromJsonAsync<BookReviewsDto>($"api/reviews/by-book/{bookId}", ct)
                   ?? new BookReviewsDto(0, new());
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return new BookReviewsDto(0, new());
        }
    }

    public async Task<bool> DeleteReviewAsync(int reviewId, CancellationToken ct = default)
        => (await _http.DeleteAsync($"api/reviews/{reviewId}", ct)).IsSuccessStatusCode;

    public async Task<bool> RestoreReviewAsync(int reviewId, CancellationToken ct = default)
        => (await _http.PostAsync($"api/reviews/{reviewId}/restore", null, ct)).IsSuccessStatusCode;
}