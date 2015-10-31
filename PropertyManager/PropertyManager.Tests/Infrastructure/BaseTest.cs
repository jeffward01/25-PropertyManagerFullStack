using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PropertyManager.Tests.Infrastructure
{

    public class BaseTest
    {
        public BaseTest()
        {
            WebApiConfig.SetupAutoMapper(); 
        }
    }
}
