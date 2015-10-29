using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyManager.Core.Infrastructure;
using System.Linq;

namespace PropertyManager.Tests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void GenerateDatabaseText()
        {
            using (var db = new PropertyManagerDbContext())
            {
                var firstProperty = db.Properties.FirstOrDefault();

                Assert.IsNull(firstProperty);
            }
        }
    }
}
