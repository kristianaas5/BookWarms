using System.Net.Http;
using System.Net.Http.Json;

namespace BookWarms.web.Services;

public class UsersApiClient
{
    private readonly HttpClient _http;
    public UsersApiClient(HttpClient http) => _http = http;

    // Users CRUD
    public async Task<IReadOnlyList<UserDto>> GetUsersAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<UserDto>>("api/user", ct) ?? Array.Empty<UserDto>();

    public async Task<UserDto?> GetUserAsync(int id, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<UserDto>($"api/user/{id}", ct);

    public async Task<UserDto?> AddUserAsync(UserDto dto, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("api/user", dto, ct);
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<UserDto>(cancellationToken: ct);
    }

    public async Task<bool> UpdateUserAsync(UserDto dto, CancellationToken ct = default)
        => (await _http.PutAsJsonAsync($"api/user/{dto.Id}", dto, ct)).IsSuccessStatusCode;

    public async Task<bool> DeleteUserAsync(int id, CancellationToken ct = default)
        => (await _http.DeleteAsync($"api/user/{id}", ct)).IsSuccessStatusCode;

    public async Task<bool> RestoreUserAsync(int id, CancellationToken ct = default)
        => (await _http.PostAsync($"api/user/{id}/restore", null, ct)).IsSuccessStatusCode;

    // Library
    public async Task<IReadOnlyList<LibraryDto>> GetUserLibraryAsync(int userId, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<LibraryDto>>($"api/user/{userId}/library", ct)
           ?? Array.Empty<LibraryDto>();

    public async Task<LibraryDto?> AddToLibraryAsync(int userId, int bookId, ShelfType shelf, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync($"api/user/{userId}/library", new AddLibraryItemRequest(bookId, shelf), ct);
        if (!resp.IsSuccessStatusCode) return null;
        return await resp.Content.ReadFromJsonAsync<LibraryDto>(cancellationToken: ct);
    }

    public async Task<bool> UpdateLibraryShelfAsync(int userId, int libraryId, ShelfType shelf, CancellationToken ct = default)
        => (await _http.PutAsJsonAsync($"api/user/{userId}/library/{libraryId}/shelf", new UpdateShelfRequest(shelf), ct)).IsSuccessStatusCode;

    public async Task<bool> DeleteLibraryItemAsync(int userId, int libraryId, CancellationToken ct = default)
        => (await _http.DeleteAsync($"api/user/{userId}/library/{libraryId}", ct)).IsSuccessStatusCode;

    // Reviews list for user
    public async Task<IReadOnlyList<ReviewDto>> GetUserReviewsAsync(int userId, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<ReviewDto>>($"api/user/{userId}/reviews", ct)
           ?? Array.Empty<ReviewDto>();

    // Reading stats
    public async Task<UserReadingStatsDto> GetUserStatsAsync(int userId, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<UserReadingStatsDto>($"api/user/{userId}/stats", ct)
           ?? new UserReadingStatsDto(new List<YearlyStatDto>(), new List<GenreStatDto>());
}

// DTOs
public record UserDto(int Id, string Username, string Email, bool IsDeleted);

public enum ShelfType { WantToRead, CurrentlyReading, Read }

public record LibraryDto(int Id, int UserId, int BookId, ShelfType ShelfType, BookDto? Book, bool IsDeleted);

public record ReviewDto(int Id, int LibraryId, int Rating, string ReviewText, DateTime Date, LibraryDto? Library);

public record UserReadingStatsDto(List<YearlyStatDto> Yearly, List<GenreStatDto> TopGenres);
public record YearlyStatDto(int Year, int BooksRead, int PagesRead);
public record GenreStatDto(string Genre, int Count);

// Request DTOs for library endpoints
public record AddLibraryItemRequest(int BookId, ShelfType ShelfType);
public record UpdateShelfRequest(ShelfType ShelfType);