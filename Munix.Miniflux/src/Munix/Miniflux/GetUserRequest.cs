namespace Munix.Miniflux
{
    public class GetUserRequest
    {
        public GetUserRequest(int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; }
    }
}
