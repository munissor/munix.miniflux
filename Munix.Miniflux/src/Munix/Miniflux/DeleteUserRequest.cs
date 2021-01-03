namespace Munix.Miniflux
{
    public class DeleteUserRequest
    {
        public DeleteUserRequest(int userId)
        {
            this.UserId = userId;
        }

        public int UserId { get; }
    }
}
