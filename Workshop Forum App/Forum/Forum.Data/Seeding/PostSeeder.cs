using Forum_App.Data.Models;

namespace Forum_App.Data.Seeding
{
    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "This is my first ever post"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "This is just another post"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content = "This is yet another post"
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
