using FakeRestAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeRestAPI.Web.Repository
{
    public interface IRepository
    {

        IEnumerable<Book> LoadBooks();

        IEnumerable<Author> LoadAuthors();

        IEnumerable<User> LoadUsers();

        IEnumerable<CoverPhoto> LoadCoverPhotos();
    }
}