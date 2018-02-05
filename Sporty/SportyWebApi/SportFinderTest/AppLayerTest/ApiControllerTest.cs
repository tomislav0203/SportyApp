using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Infrastructure.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DomainModels;
using Moq;
using SportFinderApi.Controllers;
using SportFinderApi.DTO;
using SportFinderApi.Models;

namespace SportFinderTest.AppLayerTest
{
    [TestClass]
    public class ApiControllerTest
    {
        public ApiControllerTest()
        {
            // stvori mock objekte
            IList<User> mockUsers = new List<User>
                {
                    new User { Id = 1, FirstName = "Luka", LastName = "Modric", UserName = "luka123", Password = "neSjecamSe", City = new City()},
                    new User { Id = 2, FirstName = "Zdravko", LastName = "Mamic", UserName = "zdravko123", Password = "dinamo", City = new City()},
                    new User { Id = 3, FirstName = "Ivan", LastName = "Pernar", UserName = "ivan123", Password = "mrzimPlavo", City = new City()}
                };

            // mockaj repository
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

            // vrati sve korisnike
            mockUserRepository.Setup(m => m.All(x => true)).Returns(mockUsers);

            // vrati korisnika po Id
            mockUserRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int i) => mockUsers.Where(x => x.Id == i).SingleOrDefault());

            this.MockUsersRepository = mockUserRepository.Object;

        }

        public readonly IUserRepository MockUsersRepository;

        [TestMethod]
        public void ApiTest()
        {
            // Arrange
            var controller = new UsersController(MockUsersRepository);
            IHttpActionResult actionResult;

            // Act    
            actionResult = controller.GetById(1);
            var createdResult = actionResult as OkNegotiatedContentResult<UserDto>;

            // Provjeri dobar dohvat
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("luka123", createdResult.Content.UserName);

            // Act    
            actionResult = controller.GetById(null);
            var createdResult2 = actionResult as IHttpActionResult;

            // Provjeri null parametar i povratno BadRequest
            Assert.IsNotNull(createdResult2);
            Assert.IsInstanceOfType(createdResult2, typeof(BadRequestResult));

            // Act    
            actionResult = controller.GetById(7);
            var createdResult3 = actionResult as IHttpActionResult;

            // Provjeri null parametar i povratno BadRequest
            Assert.IsNotNull(createdResult2);
            Assert.IsInstanceOfType(createdResult3, typeof(NotFoundResult));
        }
    }
}
