using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nam_lab2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
   
        [Required(ErrorMessage = "Tieu de khong duoc trong")]
        [StringLength(250, ErrorMessage = "Tieu de sach khong duoc vuot qua 250 ky tu")]
        [Display(Name = "tieu de")]

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Image_cover
        {
            get
            {
                return image_cover;
            }

            set
            {
                image_cover = value;
            }
        }

        public Book()
        {

        }

        public Book(int id, string title, string author, string image_cover)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Image_cover = image_cover;
        }

        
    }
}