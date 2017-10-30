using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Raven.AspNet.MvcExtensions.Test.Models
{
    public class TestModel
    {
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
        [Range(1,20,ErrorMessage = "Id必须在1到20之间")]
        public int Id { get; set; }
    }
}