namespace Pets.Web.Areas.Admin.Models.Users
{
    using System.Collections.Generic;

    using Pets.Data.Models;
    using Pets.Web.Areas.Admin.Models.Base;

    public class UserListVM : PaginatedWithMappingVM<ApplicationUser>
    {
        public List<UserVM> Users { get; set; }
    }
}