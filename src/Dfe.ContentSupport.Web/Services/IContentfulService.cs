using Microsoft.AspNetCore.Mvc.RazorPages;

public interface IContentfulService {

    Task<object> GetContent();
}