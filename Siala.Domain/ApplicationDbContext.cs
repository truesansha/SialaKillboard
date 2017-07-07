using Siala.Domain.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Siala.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
    }
}