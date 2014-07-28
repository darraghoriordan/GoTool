using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GoTool.Models
{
    public class GoLinkViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string LinkName { get; set; }
         [Required]
      
        [MinLength(2)]
        public string GoUrl { get; set; }
        public string Owner { get; set; }
        [MinLength(2)]
        public string Description { get; set; }
    }
}