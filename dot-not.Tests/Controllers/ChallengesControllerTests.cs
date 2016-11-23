using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dot_not.Controllers;
using System.Web.Mvc;
using dot_not.Models;
using System.Collections.Generic;
using NSubstitute;
using FizzWare.NBuilder;
using System.Linq;
using TestStack.FluentMVCTesting;
using System.Net;

namespace dot_not.Tests.Controllers
{
    [TestClass]
    public class ChallengesControllerTests
    {
        private ChallengesController _controller;
        private IDotNotDBContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            // Create fake data
            var challenges = Builder<ChallengeModel>.CreateListOfSize(10).Build();

            _dbContext = Substitute.For<IDotNotDBContext>();
            _dbContext.Challenges.Returns(x => new TestDbSet<ChallengeModel>(challenges));

            _controller = new ChallengesController(_dbContext);
        }

    }
}
