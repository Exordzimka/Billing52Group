using AutoMapper;
using Billing52Group;
using Xunit;

namespace Billing52Group.Tests
{
    public class MapperConfigurationTests
    {
        [Fact(DisplayName = "Validate AutoMapper configuration")]
        public void CheckMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Program));
            });

            config.AssertConfigurationIsValid();
        }
    }
}
