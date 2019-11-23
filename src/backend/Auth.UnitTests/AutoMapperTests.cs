using Auth.Application;
using Auth.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auth.UnitTests
{
    /// <summary> Unit tests for auto mapper </summary>
    public class AutoMapperTests
    {
        /// <summary>
        /// Test for valid profile configurations
        /// </summary>
        [Fact]
        public void TestConfiguration()
        {
            var assemblies = new[]
            {
                typeof(InfrastructureExtensions).Assembly,
                typeof(ApplicationExtensions).Assembly
            };

            var mapperConfiguration = new MapperConfiguration(x => x.AddMaps(assemblies));

            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
