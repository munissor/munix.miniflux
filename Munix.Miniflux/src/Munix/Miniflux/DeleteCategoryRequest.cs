namespace Munix.Miniflux
{
    public class DeleteCategoryRequest
    {
        public DeleteCategoryRequest(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        public int CategoryId { get; private set; }
    }
}
