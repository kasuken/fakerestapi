using FakeRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeRestAPI.Web.Repositories
{
    public interface IRepository
    {

        IEnumerable<Book> LoadBooks();

        IEnumerable<Author> LoadAuthors();

        IEnumerable<User> LoadUsers();

        IEnumerable<CoverPhoto> LoadCoverPhotos();

        IEnumerable<Activity> LoadActivities();
    }
}