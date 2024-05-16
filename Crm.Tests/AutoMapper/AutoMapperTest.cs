using AutoMapper;
using Crm.Application.AutoMapper;
using NUnit.Framework;
using static Crm.Tests.Enum.Enum;


namespace Crm.Tests.AutoMapper
{
    [TestFixture]
    public class AutoMapperTest
    {
        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());
            config.AssertConfigurationIsValid();
        }

        [TestCase(1, ExpectedResult = RowStatusEnum.Modified)]
        [TestCase(2, ExpectedResult = RowStatusEnum.Removed)]
        [TestCase(3, ExpectedResult = RowStatusEnum.Added)]
        public RowStatusEnum AutoMapper_ConvertFromByte_IsValid(
            byte rowStatusEnum)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());
            var mapper = config.CreateMapper();
            return mapper.Map<byte, RowStatusEnum>(rowStatusEnum);
        }

        [TestCase(RowStatusEnum.Modified, ExpectedResult = 1)]
        [TestCase(RowStatusEnum.Removed, ExpectedResult = 2)]
        [TestCase(RowStatusEnum.Added, ExpectedResult = 3)]
        public byte AutoMapper_ConvertFromEnum_IsValid(
            RowStatusEnum rowStatusEnum)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperSetup>());
            var mapper = config.CreateMapper();
            return mapper.Map<RowStatusEnum, byte>(rowStatusEnum);
        }
    }
}
