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

namespace DotNotTests
{
    [TestClass]
    public class ChallengesControllerTests
    {
        private ChallengesController _controller;
        private DotNotDBContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            // Create fake data
            var challenges = Builder<ChallengeModel>.CreateListOfSize(10).Build();

            _dbContext = Substitute.For<DotNotDBContext>();
            _dbContext.Challenges.Returns(new TestDbSet<ChallengeModel>(challenges));

            _controller = new ChallengesController(_dbContext);
        }

        [TestMethod]
        public void DetailsShouldReturnCorrectChallenge()
        {
            _controller.WithCallTo(c => c.Details(1)).ShouldRenderDefaultView().WithModel<ChallengeViewModel>(p => p.Challenge.ID == 1);
        }

        [TestMethod]
        public void SubmittingFlagShouldSolveChallenge()
        {
            ChallengeViewModel cm = new ChallengeViewModel();
            cm.Challenge= _dbContext.Challenges.First();

            _controller.WithCallTo(c => c.Submit(cm)).ShouldRenderView("Details").WithModel<ChallengeViewModel>(p => p.Success == true);
        }
    

        [TestMethod]
        public void UserShouldRecievePointsForChallenge()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UserChallengeShouldHaveAPassedStatus()
        {
            Assert.Fail();
      
        }



    }
}
