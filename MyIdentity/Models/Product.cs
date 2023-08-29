using Microsoft.AspNetCore.Identity;

namespace MyIdentity.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }


        //navigation :

        public IdentityUser? IdentityUser { get; set; }
        public string? IdentityUserId { get; set; }


    }
}
