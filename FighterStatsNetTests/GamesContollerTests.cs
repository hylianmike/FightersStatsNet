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

            var game = new Game { GameId = 505, Name = "Street Fighter 3rd Strike" };
            context.Add(game);

            var fighter = new Fighter { FighterId = 580, Name = "Ryu", Gender = 'M', PlayStyle = "All-Rounder", SkillLevel = 7, Game = game, GameId = 505 };
            context.Add(fighter);

            var attack = new Attack { AttackId = 610, Name = "Hadouken", ButtonInput = "Quarter-Circle Forward + Punch", Fighter = fighter, FighterId = 580 };
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
    }
}