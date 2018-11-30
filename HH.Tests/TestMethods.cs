using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HH.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//NuGet Packages needed:  MSTest.TestAdapter and MSTest.TestFramework

namespace HH.Tests
{
    public class TestMethods
    {
    }
    
    [TestClass]
    public class Properties
    {
        [TestMethod]
        public void TestResultsView()
        {
            var controller = new PropertiesController();
        }

        [TestMethod]
        public void TestSearchView()
        {
            var controller = new PropertiesController();

        }
    }
}
