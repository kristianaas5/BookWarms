using System;
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
    {
        var resp = await _http.PutAsJsonAsync($"api/user/{dto.Id}", dto, ct);
        return resp.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(int id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"api/user/{id}", ct);
        return resp.IsSuccessStatusCode;
    }

    // Optional library/reviews calls (keep if referenced elsewhere)
    public async Task<IReadOnlyList<LibraryDto>> GetUserLibraryAsync(int userId, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<LibraryDto>>($"api/user/{userId}/library", ct)
           ?? Array.Empty<LibraryDto>();

    public async Task<IReadOnlyList<ReviewDto>> GetUserReviewsAsync(int userId, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<ReviewDto>>($"api/user/{userId}/reviews", ct)
           ?? Array.Empty<ReviewDto>();
}

public record UserDto(int Id, string Username, string Email, bool IsDeleted);

// If you reference these in pages, keep them here; otherwise you can remove.
public enum ShelfType { WantToRead, CurrentlyReading, Read }
public record LibraryDto(int Id, int UserId, int BookId, ShelfType ShelfType, BookDto? Book, bool IsDeleted);
public record ReviewDto(int Id, int LibraryId, int Rating, string ReviewText, DateTime Date, LibraryDto? Library);