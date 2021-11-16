using FakeRESTAPI.Web.Models;

namespace FakeRESTAPI.Web.Services;

public interface IRepository
{
    IEnumerable<Book> LoadBooks();

    IEnumerable<Author> LoadAuthors();

    IEnumerable<User> LoadUsers();

    IEnumerable<CoverPhoto> LoadCoverPhotos();

    IEnumerable<Activity> LoadActivities();
}
