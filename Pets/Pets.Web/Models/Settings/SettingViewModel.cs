namespace Pets.Web.Models.Settings
{
    using Pets.Common.Mapping;
    using Pets.Data.Models;

    public class SettingViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
