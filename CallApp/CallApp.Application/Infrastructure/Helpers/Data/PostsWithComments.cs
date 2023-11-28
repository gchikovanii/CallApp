namespace CallApp.Application.Infrastructure.Helpers.Data
{
    public class PostsWithComments
    {
        public Posts Post { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
