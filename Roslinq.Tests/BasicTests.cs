using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslinq.Structure;

namespace Roslinq.Tests
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
