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
    public class LeaseControllerTests : BaseTest
    {

        [TestMethod] // [0] | Get Leases 
        public void GetLeasesReturnLeases()
        {
            //Arrange
            var leasesController = new LeasesController();

            //Act
            IEnumerable<LeaseModel> lease = leasesController.GetLeases();

            //Assert
            Assert.IsTrue(lease.Count() > 0);
        }

        [TestMethod] // [1] | Get Lease
        public void GetLeaseReturnLease()
        {
            //Arrange
            var Lctrl = new LeasesController();

            //Act
            IHttpActionResult result = Lctrl.GetLease(1);

            //Assert
            //If action returns: NotFound()
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<LeaseModel>));

            //if Acction returns: Ok();
            OkNegotiatedContentResult<LeaseModel> contentReesult = (OkNegotiatedContentResult<LeaseModel>)result;
            Assert.IsTrue(contentReesult.Content.LeaseId == 1);
        }

        [TestMethod] // [2] Update Lease
        public void PutLeaseUpdateLease()
        {
            //Arrange
            var lCtrl = new LeasesController();

            var newLease = new LeaseModel
            {
                PropertyId = 1,
                TenantId = 1,
                StartDate = DateTime.Now,
                Rent = 2000

            };

            //The result of the PostRequest
            IHttpActionResult result = lCtrl.PostLease(newLease);

            //Cast result as the content result so I can gather information from Content Result
            CreatedAtRouteNegotiatedContentResult<LeaseModel> contentResult = (CreatedAtRouteNegotiatedContentResult<LeaseModel>)result;

            //REsult containts the property I had just created
            result = lCtrl.GetLease(contentResult.Content.LeaseId);

            //GET PropertyModel from Result
            OkNegotiatedContentResult<LeaseModel> propertyResult = (OkNegotiatedContentResult<LeaseModel>)result;

            //Act
            result = lCtrl.PutLease(propertyResult.Content.LeaseId, newLease);

            //Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]// [3] Create Lease
        public void POSTLeaseCreateLease()
        {
            //Arrange
            var lCtrl = new LeasesController();

            var newLease = new LeaseModel
            {
                PropertyId = 1,
                TenantId = 1,
                StartDate = DateTime.Now,
                Rent = 2000
            };

            //Result of the Post Request
            IHttpActionResult result = lCtrl.PostLease(newLease);

            //Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<LeaseModel>));

            //Cast
            CreatedAtRouteNegotiatedContentResult<LeaseModel> contentResult = (CreatedAtRouteNegotiatedContentResult<LeaseModel>)result;

            Assert.IsTrue(contentResult.Content.LeaseId != 0);

        }

        [TestMethod] // [4] Delete Lease
        public void DeleteLeaseDeleteLease()
        {
            //Arrange
            var lCtrl = new LeasesController();

            var newLease = new LeaseModel
            {

            PropertyId = 1,
            TenantId = 1,
            StartDate = DateTime.Now,
                Rent = 2000
            };

            //Add 'new property to database using post' 
            //Save returned value as RESULT
            IHttpActionResult result = lCtrl.PostLease(newLease);

            //Cast result as Content Result so I can gathere information from the content result
            CreatedAtRouteNegotiatedContentResult<LeaseModel> contentResult = (CreatedAtRouteNegotiatedContentResult<LeaseModel>)result;

            //Result contains the property I had just created
            result = lCtrl.GetLease(contentResult.Content.PropertyId);

            //Get PropertyModel from result
            OkNegotiatedContentResult<LeaseModel> leaseResult = (OkNegotiatedContentResult<LeaseModel>)result;

            //Act
            result = lCtrl.DeleteLease(contentResult.Content.LeaseId);

            //Assert

            //If action returns not found
           Assert.IsNotInstanceOfType(result, typeof(NotFoundResult));

            //If action retruns OK()
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<LeaseModel>));


        }
    }
}
