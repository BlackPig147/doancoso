using DoAnCoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCoSo.ViewModels
{
    public class ComicViewModel
    {
        public int Comic { get; set; }
        public IEnumerable<Comic> Comics { get; set; }
        public string PictureChap { get; set; }
    }
}