using Microsoft.AspNetCore.Mvc.RazorPages;

public interface IContentfulService {

    Task<object> GetContent(string slug);
    Task<string> GenerateSitemap(string baseUrl);
}