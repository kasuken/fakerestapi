using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeRestAPI.Web.Models;
using NLipsum.Core;

namespace FakeRestAPI.Web.Repository
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<Author> LoadAuthors()
        {
            var Authors = new List<Author>();

            var authorCounter = 1;

            for (int i = 1; i < 201; i++)
            {
                var rnd = new Random();
                int random = rnd.Next(1, 4);

                for (int a = 0; a < random + 1; a++)
                {
                    var author = new Author();
                    author.IDBook = i;

                    author.ID = authorCounter;
                    author.FirstName = string.Format("First Name {0}", authorCounter.ToString());
                    author.LastName = string.Format("Last Name {0}", authorCounter.ToString());

                    authorCounter++;

                    Authors.Add(author);
                }
            }

            return Authors;
        }

        public IEnumerable<Book> LoadBooks()
        {
            var Books = new List<Book>();

            var rawText = Lipsums.LoremIpsum;
            var lipsum = new LipsumGenerator(rawText, false);

            for (int i = 1; i < 201; i++)
            {
                var book = new Book();
                book.ID = i;
                book.Title = string.Format("Book {0}", i.ToString());
                book.Description = lipsum.GenerateLipsum(1);
                book.Excerpt = lipsum.GenerateLipsum(5);
                book.PublishDate = DateTime.Now.AddDays(-i);
                book.PageCount = i * 100;

                Books.Add(book);
            }

            return Books;
        }

        public IEnumerable<User> LoadUsers()
        {
            var Users = new List<User>();

            for (int i = 1; i < 11; i++)
            {
                var user = new User();
                user.ID = i;
                user.UserName = string.Format("User {0}", i.ToString());
                user.Password = string.Format("Password{0}", i.ToString());

                Users.Add(user);
            }

            return Users;
        }

        public IEnumerable<CoverPhoto> LoadCoverPhotos()
        {
            var CoverPhotos = new List<CoverPhoto>();

            for (int i = 1; i < 201; i++)
            {
                var cover = new CoverPhoto();
                cover.ID = i;
                cover.IDBook = i;
                cover.Url = new Uri(string.Format("https://placeholdit.imgix.net/~text?txtsize=33&txt={0}{1}&w=250&h=350", "Book ", i.ToString()));

                CoverPhotos.Add(cover);
            }

            return CoverPhotos;
        }
    }
}