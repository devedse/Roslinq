using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslync.Structure;

namespace Roslync.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void LoadsASolution()
        {
            var solution = new DeveSolution(@"..\..\..\Roslync.sln");
            Assert.AreNotEqual(0, solution.AllMethods);
        }
    }
}
