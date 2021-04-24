using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PieGallery.Security.MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieGallery.Security
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext
            (DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }
    }
}
