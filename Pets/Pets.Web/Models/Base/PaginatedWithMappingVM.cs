namespace Pets.Web.Views.Base
{
    using Pets.Common.Mapping;

    public class PaginatedWithMappingVM<T> : IMapFrom<T>
    {
        public int CurrentPage { get; set; }

        public int NextPage { get; set; }

        public int PreviousPage { get; set; }

        public int TotalPages { get; set; }

        public bool ShowPagination { get; set; }
    }
}