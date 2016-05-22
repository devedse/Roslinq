using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Devedse.Roslinq.Structure;

namespace Devedse.Roslinq.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void LoadsASolution()
        {
            var solution = new DeveSolution(@"..\..\..\Roslinq.sln");
            Assert.AreNotEqual(0, solution.AllMethods);
        }
    }
}
