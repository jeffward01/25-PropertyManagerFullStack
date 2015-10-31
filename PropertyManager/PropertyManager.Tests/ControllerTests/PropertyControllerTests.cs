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
    public class PropertyControllerTests : BaseTest
    { 
        [TestMethod] // [0] | Get Properties
        public void GetPropertiesReturnProperties()
        {
            //Arrange
            //Properties Go Here
            var PropertiesController = new PropertiesController();

            //Act
            //Call the mthod in question that needs to be tested
            IEnumerable<PropertyModel> property = PropertiesController.GetProperties();

            //Assert
            Assert.IsTrue(property.Count() > 0);

        }

        [TestMethod] //[1] | Get Property from ID
        public void GetPropertyFromIdReturnProperty()
        {
            //Arrange
            var PropertiesController = new PropertiesController();

            //Act
            IHttpActionResult result = PropertiesController.GetProperty(1);

            //Assert
            //If action returns: NotFound()
            Assert.IsNotInstanceOfType(result, typeof(NotFoundResult));

            //if Acction returns: Ok();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PropertyModel>));
           
        }

        [TestMethod] //[2] | Update Property
        public void PutPropertyUpdatesProperty()
        {
            //Arrange
            var propertiesController = new PropertiesController();

            var newProp = new PropertyModel
            {
                Name = "Wonder Mansion",
                Address1 = "122 Wonka Way",
                Address2 = "",
                City = "Golden Coast",
                Zip = "23123",
                State = "CA"
               
            };

            
            //The result of the PostRequest
            IHttpActionResult result = propertiesController.PostProperty( newProp);

            //Cast result as the content result so I can gather information from Content Result
            CreatedAtRouteNegotiatedContentResult<PropertyModel> contentResult = (CreatedAtRouteNegotiatedContentResult<PropertyModel>)result;

            //REsult containts the property I had just created
            result = propertiesController.GetProperty(contentResult.Content.PropertyId);

            //GET PropertyModel from Result
            OkNegotiatedContentResult<PropertyModel> propertyResult = (OkNegotiatedContentResult<PropertyModel>)result;

            //Act
            result = propertiesController.PutProperty(propertyResult.Content.PropertyId, newProp);

            //Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod] //[3] | Create Property
        public void PostPropertyCreatesProperty()
        {
            //Arrange
            var propertiesController = new PropertiesController();

            //act 
            var newProp = new PropertyModel
            {
                Name = "Wonder Mansion",
                Address1 = "122 Wonka Way",
                Address2 = "",
                City = "Golden Coast",
                Zip = "23123",
                State = "CA"
            };

            //Result of the Post Request
            IHttpActionResult result = propertiesController.PostProperty(newProp);

            //Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<PropertyModel>));

            //Cast
            CreatedAtRouteNegotiatedContentResult<PropertyModel> contentResult = (CreatedAtRouteNegotiatedContentResult<PropertyModel>)result;

            Assert.IsTrue(contentResult.Content.PropertyId != 0);
        }

        [TestMethod] // [4] | Delete Property
        public void DeletePropertyDeleteProperty()
        {
            //Arrange
            var propertiesController = new PropertiesController();

            //act 
            var dbProp = new PropertyModel
            {
                Name = "Wonder Mansion",
                Address1 = "122 Wonka Way",
                Address2 = "",
                City = "Golden Coast",
                Zip = "23123",
                State = "CA"
            };

            //Add 'new property to database using post' 
            //Save returned value as RESULT
            IHttpActionResult result = propertiesController.PostProperty(dbProp);

            //Cast result as Content Result so I can gathere information from the content result
            CreatedAtRouteNegotiatedContentResult<PropertyModel> contentResult = (CreatedAtRouteNegotiatedContentResult<PropertyModel>)result;

            //Result contains the property I had just created
            result = propertiesController.GetProperty(contentResult.Content.PropertyId);

            //Get PropertyModel from result
            OkNegotiatedContentResult<PropertyModel> propertyResult = (OkNegotiatedContentResult<PropertyModel>)result;

            //Act
            result = propertiesController.DeleteProperty(contentResult.Content.PropertyId);

            //Assert

            //If action returns not found
            Assert.IsNotInstanceOfType(result, typeof(NotFoundResult));

            //If action retruns OK()
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PropertyModel>));



        }
    }
}
