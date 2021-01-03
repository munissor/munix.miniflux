namespace Munix.Miniflux
{
    public class UpdateCategoryRequest : CreateCategoryRequest
    {
        public UpdateCategoryRequest(string title)
            : base(title)
        {
        }
    }
}
