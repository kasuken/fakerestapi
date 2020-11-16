using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeRestAPI.Models;
using NLipsum.Core;

namespace FakeRestAPI.Web.Repositories
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<Author> LoadAuthors()
        {
            var authors = new List<Author>();

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

                    authors.Add(author);
                }
            }

            return authors;
        }

        public IEnumerable<Book> LoadBooks()
        {
            var books = new List<Book>();

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

                books.Add(book);
            }

            return books;
        }

        public IEnumerable<User> LoadUsers()
        {
            var users = new List<User>();

            for (int i = 1; i < 11; i++)
            {
                var user = new User();
                user.ID = i;
                user.UserName = string.Format("User {0}", i.ToString());
                user.Password = string.Format("Password{0}", i.ToString());

                users.Add(user);
            }

            return users;
        }

        public IEnumerable<CoverPhoto> LoadCoverPhotos()
        {
            var coverPhotos = new List<CoverPhoto>();

            for (int i = 1; i < 201; i++)
            {
                var cover = new CoverPhoto();
                cover.ID = i;
                cover.IDBook = i;
                cover.Url = new Uri(string.Format("https://placeholdit.imgix.net/~text?txtsize=33&txt={0}{1}&w=250&h=350", "Book ", i.ToString()));

                coverPhotos.Add(cover);
            }

            return coverPhotos;
        }

        public IEnumerable<Activity> LoadActivities()
        {
            var activities = new List<Activity>();

            for (int i = 1; i < 31; i++)
            {
                var activity = new Activity();
                activity.ID = i;
                activity.Title = string.Format("Activity {0}", i.ToString());
                activity.DueDate = DateTime.Now.AddHours(i);
                activity.Completed = i % 2 == 0;

                activities.Add(activity);
            }

            return activities;
        }
    }
}