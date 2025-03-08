using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Ultilites;
using ASC.Web.Configuration;
using ASC.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ASC.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void HomeController_Index_View_Test()
        {
            var controller = new HomeController(optionMock.Object);
            controller.ControllerContext.HttpContext = mockHTTPContext.Object;
            Assert.IsType(typeof(ViewResult), controller.Index());
        }

        [Fact]
        public void HomeController_Index_NoModel_Test()
        {
            var controller = new HomeController(optionMock.Object);
            controller.ControllerContext.HttpContext = mockHTTPContext.Object;
            Assert.Null((controller.Index() as ViewResult).ViewData.Model);
        }

        [Fact]
        public void HomeController_Index_Validation_Test()
        {
            var controller = new HomeController(optionMock.Object);
            controller.ControllerContext.HttpContext = mockHTTPContext.Object;
            Assert.Equal(0, (controller.Index() as ViewResult).ViewData.ModelState.ErrorCount);

        }
        [Fact]
        public void HomeController_Index_Session_Test()
        {
            var controller = new HomeController(optionMock.Object);
            controller.ControllerContext.HttpContext = mockHTTPContext.Object;
            controller.Index();
            Assert.NotNull(controller.HttpContext.Session.GetSession<ApplicationSettings>);
        }

        private readonly Mock<IOptions<ApplicationSettings>> optionMock;
        private readonly Mock<HttpContext> mockHTTPContext;
        public HomeControllerTests()
        {
            optionMock = new Mock<IOptions<ApplicationSettings>>();
            mockHTTPContext = new Mock<HttpContext>();
            mockHTTPContext.Setup(p => p.Session).Returns(new FakeSession());
            optionMock.Setup(ap => ap.Value).Returns(new ApplicationSettings
            {
                ApplicationTitle = "ASC"
            });
        }
    }
}
