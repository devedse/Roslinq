using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Devedse.Roslinq.Structure;
using System.Linq;

namespace Devedse.Roslinq.Tests
{
    [TestClass]
    public class BasicTests
    {
        private const string SolutionPath = @"..\..\..\Devedse.Roslinq.sln";

        [TestMethod]
        public void LoadsASolution()
        {
            var solution = new DeveSolution(SolutionPath);
            Assert.AreNotEqual(0, solution.AllMethods);
        }

        [TestMethod]
        public void ThisMethodExistsInThisClass()
        {
            //Blahblah123123identifier123123:)
            var solution = new DeveSolution(SolutionPath);
            var thisMethod = solution.AllMethods.Where(t => t.InnerCode.Contains("//Blahblah123123identifier123123:)")).Single();

            Assert.AreEqual(nameof(BasicTests), thisMethod.Parent.Name);
        }
    }
}
