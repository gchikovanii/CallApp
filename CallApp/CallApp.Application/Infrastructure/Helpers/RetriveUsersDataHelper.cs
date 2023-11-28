using CallApp.Application.Infrastructure.Helpers.Data;
using CallApp.Infrastructure.Errors.CustomErrors;
using CallApp.Infrastructure.Globalization;
using Mapster;
using System.Text.Json;

namespace CallApp.Application.Infrastructure.Helpers
{
    public static class RetriveUsersDataHelper
    {
        public static async Task<List<Todo>> GetUserTodosAsync(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://jsonplaceholder.typicode.com/users/{userId}/todos";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string content = await response.Content.ReadAsStringAsync();
                    List<Todo> result = JsonSerializer.Deserialize<List<Todo>>(content);
                    if(result == null)
                        throw new NotFoundException(ErrorMessages.NotFound);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
        public static async Task<List<Albums>> GetUserAlbumsAsync(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://jsonplaceholder.typicode.com/users/{userId}/albums";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string content = await response.Content.ReadAsStringAsync();
                    List<Albums> result = JsonSerializer.Deserialize<List<Albums>>(content);
                    if (result == null)
                        throw new NotFoundException(ErrorMessages.NotFound);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
        public static async Task<List<PostsWithComments>> GetUserPostsWithCommentsAsync(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string postsUrl = $"https://jsonplaceholder.typicode.com/users/{userId}/posts";
                    HttpResponseMessage postsResponse = await client.GetAsync(postsUrl);
                    string postsContent = await postsResponse.Content.ReadAsStringAsync();
                    List<Posts> posts = JsonSerializer.Deserialize<List<Posts>>(postsContent);
                    if (posts == null)
                        throw new NotFoundException(ErrorMessages.NotFound);
                    List<PostsWithComments> postsWithComments = new List<PostsWithComments>();
                    foreach (var post in posts)
                    {
                        string commentsUrl = $"https://jsonplaceholder.typicode.com/posts/{post.id}/comments";
                        HttpResponseMessage commentsResponse = await client.GetAsync(commentsUrl);
                        string commentsContent = await commentsResponse.Content.ReadAsStringAsync();
                        List<Comments> comments = JsonSerializer.Deserialize<List<Comments>>(commentsContent);

                        postsWithComments.Add(new PostsWithComments
                        {
                            Post = post,
                            Comments = comments
                        });
                    }
                    return postsWithComments;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }


    }
}
