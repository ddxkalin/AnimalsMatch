namespace Pets.Services.Interfaces
{
    using System.Linq;
    using Pets.Data.Common.Models;

    public interface ICatCrudService<T> where T : BaseDeletableModel<string>
    {
        IQueryable<T> GetAll();
    }
}
