namespace ContentFul.ApI.Models
{
    public interface IContentComponent : IContentComponentType
    {
        public SystemDetails Sys { get; set; }
    }
}
