using Microsoft.VisualStudio.TestTools.UnitTesting;
using dot_not.Controllers;
using dot_not.Models;
using NSubstitute;
using FizzWare.NBuilder;
using System.Linq;

namespace dot_not.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private AccountController _controller;
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

        [TestMethod]
        public void TestAccountRegister()
        {
            _controller.WithCallTo(c => c.Details(1)).ShouldRenderDefaultView().WithModel<ChallengeViewModel>(p => p.Challenge.ID == 1);
        }

        [TestMethod]
        public void SubmittingFlagShouldSolveChallenge()
        {
            ChallengeViewModel cm = new ChallengeViewModel();
            cm.Challenge = _dbContext.Challenges.First();

            _controller.WithCallTo(c => c.Submit(cm)).ShouldRenderView("Details").WithModel<ChallengeViewModel>(p => p.Success == true);
        }



    }
}
