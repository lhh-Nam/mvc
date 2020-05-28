using Nam_lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nam_lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Nguyen Dinh Anh - University" + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1 ");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2 ");
            books.Add("Professional ASP.NET MVC - Author Name Book 2 ");
            ViewBag.books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1 ", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2 ", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC", "Author Name Book 2 ", "/Content/Images/book3.jpg"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1 ", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2 ", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC", "Author Name Book 2 ", "/Content/Images/book3.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1 ", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2 ", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC", "Author Name Book 2 ", "/Content/Images/book3.jpg"));

            if (id == null)
            {
                return HttpNotFound();
            }

            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
            
            return View("ListBookModel",books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, Image_cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1 ", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS3 Responsive web Design cookbook", "Author Name Book 2 ", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC", "Author Name Book 2 ", "/Content/Images/book3.jpg"));

            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            return View("ListBookModel", books);
        }
    }
}


   