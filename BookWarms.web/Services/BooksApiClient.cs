using System.Net.Http;
using System.Net.Http.Json;

namespace BookWarms.web.Services;

public class BooksApiClient
{
    private readonly HttpClient _http;
    public BooksApiClient(HttpClient http) => _http = http;

    public async Task<IReadOnlyList<BookDto>> GetBooksAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<BookDto>>("api/books", ct) ?? Array.Empty<BookDto>();

    public async Task<PagedResult<BookDto>> SearchBooksAsync(string? q, string? sortBy, bool desc, int page, int pageSize, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<PagedResult<BookDto>>(
               $"api/books/search?q={Uri.EscapeDataString(q ?? "")}&sortBy={Uri.EscapeDataString(sortBy ?? "Title")}&desc={desc}&page={page}&pageSize={pageSize}", ct)
           ?? new PagedResult<BookDto>(Array.Empty<BookDto>(), 0, page, pageSize);

    public async Task<BookDto?> GetBookAsync(int id, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<BookDto>($"api/books/{id}", ct);

    // Return error text to display on the page
    public async Task<(BookDto? Result, string? Error)> AddBookAsync(BookDto dto, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("api/books", dto, ct);
        if (!resp.IsSuccessStatusCode)
            return (null, $"({(int)resp.StatusCode}) " + await resp.Content.ReadAsStringAsync(ct));
        return (await resp.Content.ReadFromJsonAsync<BookDto>(cancellationToken: ct), null);
    }

    public async Task<bool> UpdateBookAsync(BookDto dto, CancellationToken ct = default)
        => (await _http.PutAsJsonAsync($"api/books/{dto.Id}", dto, ct)).IsSuccessStatusCode;

    public async Task<bool> DeleteBookAsync(int id, CancellationToken ct = default)
        => (await _http.DeleteAsync($"api/books/{id}", ct)).IsSuccessStatusCode;

    public async Task<bool> RestoreBookAsync(int id, CancellationToken ct = default)
        => (await _http.PostAsync($"api/books/{id}/restore", null, ct)).IsSuccessStatusCode;
}

public record BookDto(
    int Id,
    string Title,
    string Author,
    string Genre,
    string Description,
    int PageCount,
    bool IsDeleted
);

public record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize);

