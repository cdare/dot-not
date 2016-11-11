using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dot_not;
using dot_not.Controllers;
using dot_not.Models;
using NSubstitute;
using FizzWare.NBuilder;
using TestStack.FluentMVCTesting;

namespace dot_not.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;
        private IDotNotDBContext _dbContext;

        [TestMethod]
        public void HomeIndexTests()
        {

            var challenges = Builder<ChallengeModel>.CreateListOfSize(10).Build();

            _dbContext = Substitute.For<IDotNotDBContext>();
            _dbContext.Challenges.Returns(new TestDbSet<ChallengeModel>(challenges));

            _controller = new HomeController(_dbContext);

            _controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView().WithModel<HomeViewModel>(vm => vm.Challenges.Count() == 10);
        }

    }
}
