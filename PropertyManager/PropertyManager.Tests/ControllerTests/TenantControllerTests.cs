using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyManager.Controllers;
using PropertyManager.Core.Domain;
using PropertyManager.Core.Infrastructure;
using PropertyManager.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PropertyManager.Tests.Infrastructure;
using System.Web.Http.Results;


namespace PropertyManager.Tests.ControllerTests
{
    [TestClass]
    public class TenantControllerTests : BaseTest
    {
        [TestMethod] // [0] | Get Tenants 
        public void GetTenantsReturnTenants()
        {
            //Arrange
            //Properties go here
            var tenantsController = new TenantsController();

            //Act
            IEnumerable<TenantModel> tenant = tenantsController.GetTenants();

            //Assert
            Assert.IsTrue(tenant.Count() > 0);
        }

        [TestMethod] // [1] | Get Tenant
        public void GetTenantFromIDReturnTenant()
        {
            //Arrange
            var Tctrl = new TenantsController();

            //Act
            IHttpActionResult result = Tctrl.GetTenant(1);

            //If action returns: NotFound()
            Assert.IsNotInstanceOfType(result, typeof(NotFoundResult));

            //if Acction returns: Ok();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TenantModel>));

        }

        [TestMethod] // [2] Update Tenant
        public void PutTenantUpdatesTenant()
        {
           
           
            //Arrange
            var tCtrl = new TenantsController();

            var newTenant = new TenantModel
            {
                FirstName = "Test",
                LastName = "LastNameTest",
                Telephone = "12223334444",
                EmailAddress = "test@example.com"
            };

            //The result of the Post Request
            IHttpActionResult result = tCtrl.PostTenant(newTenant);

            //Cast result of the content result so that I can gether information form the Contente
            CreatedAtRouteNegotiatedContentResult<TenantModel> contentResult = (CreatedAtRouteNegotiatedContentResult<TenantModel>)result;

            //Result containts the tenant I have just created
            result = tCtrl.GetTenant(contentResult.Content.TenantId);

            //Get tenant model from result
            OkNegotiatedContentResult<TenantModel> tenantResult = (OkNegotiatedContentResult<TenantModel>)result;

            //Act
            result = tCtrl.PutTenant(tenantResult.Content.TenantId, newTenant);

            //Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]// [3] Create Tenant
        public void PostTenantCreatesTenant()
        {
            //arrange 
            var Tcrtl = new TenantsController();

            //Act
            var newTenant = new TenantModel
            {
                FirstName = "Test",
                LastName = "LastNameTest",
                Telephone = "12223334444",
                EmailAddress = "test@example.com"
            };

            //Result of the post request
            IHttpActionResult result = Tcrtl.PostTenant(newTenant);

            //Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<TenantModel>));
        }

        [TestMethod] // [4] Delete Tenant
        public void DeletePropertyDeleteProperty()
        {
            //Arrange
            var tctrl = new TenantsController();

            //Act
            var newTenant = new TenantModel
            {
                FirstName = "Test",
                LastName = "LastNameTest",
                Telephone = "12223334444",
                EmailAddress = "test@example.com"
            };

            //Add 'new tenant' to database using post
            //save returned value as result
            IHttpActionResult result = tctrl.PostTenant(newTenant);

            //Cast result as content result so I can gather intel on it
            CreatedAtRouteNegotiatedContentResult<TenantModel> contentResult = (CreatedAtRouteNegotiatedContentResult<TenantModel>)result;

            //Result contains the property I had just created 
            result = tctrl.GetTenant(contentResult.Content.TenantId);

            //get tenantmodel from result
            OkNegotiatedContentResult<TenantModel> tenantResult = (OkNegotiatedContentResult<TenantModel>)result;

            //Act
            result = tctrl.DeleteTenant(contentResult.Content.TenantId);

            //Assert
            //If action returns not found
            Assert.IsNotInstanceOfType(result, typeof(NotFoundResult));

            //If action retruns OK()
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TenantModel>));


        }

    }
}
