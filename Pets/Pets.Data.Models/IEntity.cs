using System;

namespace Pets.Data.Models
{
    public interface IEntity
    {
        int ID { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
