using GitHubRepositoryApp.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubRepositoryApp.BL.Interface
{
    public interface IBookmarkManager
    {
        void AddBookmark(BookmarkDTO bookmark);
        void RemoveBookmark(int bookmarkId);
        List<BookmarkDTO> GetBookmarks();
        void SaveBookmarksToSession();
    }
}
