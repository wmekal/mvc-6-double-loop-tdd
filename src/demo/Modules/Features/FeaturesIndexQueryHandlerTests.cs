using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNet.Mvc;
using Xunit;
using Licensing.Web.Models;

namespace Licensing.Web.Modules.Features
{
    [Trait("category","unit")]
    public class FeaturesIndexQueryHandlerTests
    {
        [Fact]
        public void Handle_WhenCalled_ReturnsFeaturesIndexView()
        {
            var unitUnderTest = new FeaturesIndexQueryHandlerBuilder()
                .Build();

            var result = unitUnderTest.Handle() as ViewResult;

            Assert.Equal("/Modules/Features/FeaturesIndex", result.ViewName);
        }

        [Fact]
        public void Handle_WhenNoFeatures_ReturnsViewWithEmptyList()
        {
            var unitUnderTest = new FeaturesIndexQueryHandlerBuilder()
                .Build();

            var viewResult = unitUnderTest.Handle() as ViewResult;
            var result = viewResult.ViewData.Model as List<FeaturesIndexQueryHandler.ResultItem>;

            var expected = new List<FeaturesIndexQueryHandler.ResultItem>();
            result.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void Handle_WhenFeatures_ReturnsViewWithAllFeaturesList()
        {
            var unitUnderTest = new FeaturesIndexQueryHandlerBuilder()
                .WithData(context =>
                {
                    context.Features.Add(new Feature { Name = "feature 1" });
                    context.Features.Add(new Feature { Name = "feature 2" });
                })
                .Build();

            var viewResult = unitUnderTest.Handle() as ViewResult;
            var result = viewResult.ViewData.Model as List<FeaturesIndexQueryHandler.ResultItem>;

            var expected = new List<FeaturesIndexQueryHandler.ResultItem>{
                new FeaturesIndexQueryHandler.ResultItem { Id = 1, Name = "feature 1"},
                new FeaturesIndexQueryHandler.ResultItem { Id = 2, Name = "feature 2"}
            };
            result.ShouldBeEquivalentTo(expected);
        }
    }
}
