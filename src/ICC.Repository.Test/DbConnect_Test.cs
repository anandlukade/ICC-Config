using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICC.Repository;

namespace ICC.Repository.Test
{
    [TestClass]
    public class DbConnect_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Icc().GetPipelineValues("afr","HDAddOnStatusUpdate","ds");
        }
    }
}
