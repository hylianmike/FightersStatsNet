using FightersStatsNet.Controllers;
using FightersStatsNet.Data;
using FightersStatsNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FighterStatsNetTests
{
    [TestClass]
    public class GamesContollerTests
    {
        private ApplicationDbContext context;
        private GamesController controller;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            context = new ApplicationDbContext(options);

            Game game = new Game { GameId = 505, Name = "Street Fighter 3rd Strike" };
            context.Add(game);

            Fighter fighter = new Fighter { FighterId = 580, Name = "Ryu", Gender = 'M', PlayStyle = "All-Rounder", SkillLevel = 7, Game = game, GameId = 505 };
            context.Add(fighter);

            Attack attack = new Attack { AttackId = 610, Name = "Hadouken", ButtonInput = "Quarter-Circle Forward + Punch", Fighter = fighter, FighterId = 580 };
            context.Add(attack);
            context.SaveChanges();

            controller = new GamesController(context);
        }

        #region "Index Tests"

        [TestMethod]
        public void IndexLoadView()
        {
            var result = (ViewResult)controller.Index().Result;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexGetsDatabaseInformation()
        {
            var result = (ViewResult)controller.Index().Result;
            List<Game> games = (List<Game>)result.Model;

            CollectionAssert.AreEqual(context.Game.ToList(), games);
        }
        #endregion

        #region "Details Tests"

        [TestMethod]
        public void DetailsNoID()
        {
            var result = (ViewResult)controller.Details(null).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidID()
        {
            var result = (ViewResult)controller.Details(900).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DetailsNoGameTable()
        {
            context.Game = null;

            var result = (ViewResult)controller.Details(505).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIDLoadsView()
        {
            var result = (ViewResult)controller.Details(505).Result;

            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIDLoadsObject()
        {
            var result = (ViewResult)controller.Details(505).Result;

            Assert.AreEqual(result.Model, context.Game.Find(505));
        }

        #endregion

        #region "Create Tests"

        [TestMethod]
        public void CreateLoadsView()
        {
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateInvalidModel()
        {
            controller.ModelState.AddModelError("This is a failure", "Model Invalid");
            var result = (ViewResult)controller.Create(new Game { GameId = 505, Name = "Street Fighter 3rd Strike" }).Result;

            Assert.AreEqual("Create Error", result.ViewName);
        }

        [TestMethod]
        public void CreateValidModelLoadsView()
        {
            var result = (ViewResult)controller.Create(new Game { GameId = 900, Name = "Street Fighter 3rd Strike" }).Result;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void CreateValidModelAddsObject()
        {
            Game game = new Game { GameId = 900, Name = "Street Fighter 3rd Strike" };
            controller.Create(game);

            Assert.AreEqual(game, context.Game.Find(900));
        }
        #endregion

        #region "Edit Tests"

        [TestMethod]
        public void EditNoID()
        {
            var result = (ViewResult)controller.Edit(null).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidID()
        {
            var result = (ViewResult)controller.Edit(900).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void EditNoGameTable()
        {
            context.Game = null;

            var result = (ViewResult)controller.Edit(505).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void EditValidIDLoadsView()
        {
            var result = (ViewResult)controller.Edit(505).Result;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIDLoadsObject()
        {
            var result = (ViewResult)controller.Edit(505).Result;

            Assert.AreEqual(result.Model, context.Game.Find(505));
        }

        [TestMethod]
        public void SaveEditWrongID()
        {
            var result = (ViewResult)controller.Edit(900, context.Game.Find(505)).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void SaveEditInvalidModel()
        {
            controller.ModelState.AddModelError("This is a failure", "Model Invalid");
            var result = (ViewResult)controller.Edit(505, context.Game.Find(505)).Result;

            Assert.AreEqual("Edit Error", result.ViewName);
        }

        [TestMethod]
        public void SaveEditValidModel()
        {
            var result = (ViewResult)controller.Edit(505, context.Game.Find(505)).Result;

            Assert.AreEqual("Index", result.ViewName);
        }

        #endregion

        #region "Delete Tests"

        [TestMethod]
        public void DeleteNoID()
        {
            var result = (ViewResult)controller.Delete(null).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidID()
        {
            var result = (ViewResult)controller.Delete(900).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DeleteNoGameTable()
        {
            context.Game = null;

            var result = (ViewResult)controller.Delete(505).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIDLoadsView()
        {
            var result = (ViewResult)controller.Delete(505).Result;

            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIDLoadsObject()
        {
            var result = (ViewResult)controller.Delete(505).Result;

            Assert.AreEqual(result.Model, context.Game.Find(505));
        }

        [TestMethod]
        public void DeleteConfirmedNoGameTable()
        {
            context.Game = null;

            var result = (ViewResult)controller.DeleteConfirmed(505).Result;

            Assert.AreEqual("NewError", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedReturnsIndexView()
        {
            var result = (ViewResult)controller.DeleteConfirmed(505).Result;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedDeletesItem()
        {
            controller.DeleteConfirmed(505);

            Assert.AreEqual(null, context.Game.Find(505));
        }

        #endregion

    }
}