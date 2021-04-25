using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieGallery.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }

        public int Id { get; set; }
    }
}
