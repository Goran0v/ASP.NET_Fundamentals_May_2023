using Forum.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostFormModel postViewModel);

        Task<PostFormModel> GetForEditOrDeleteByIdAsync(string Id);

        Task EditByIdAsync(string id, PostFormModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}
