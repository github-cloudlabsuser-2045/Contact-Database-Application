using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Linq;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController controller;
        private User testUser;

        [TestInitialize]
        public void Setup()
        {
            controller = new UserController();
            testUser = new User { Id = 1, Name = "Test User", Email = "testuser@example.com" };
            UserController.userlist.Add(testUser);
        }

        [TestMethod]
        public void Index()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as System.Collections.Generic.List<User>;
            Assert.AreEqual(UserController.userlist.Count, model.Count);
        }

        [TestMethod]
        public void Details()
        {
            var result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as User;
            Assert.AreEqual(testUser, model);
        }

        [TestMethod]
        public void Create_Get()
        {
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Post()
        {
            var user = new User { Id = 2, Name = "New User", Email = "newuser@example.com" };
            var result = controller.Create(user) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsTrue(UserController.userlist.Contains(user));
        }

        [TestMethod]
        public void Edit_Get()
        {
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as User;
            Assert.AreEqual(testUser, model);
        }

        [TestMethod]
        public void Edit_Post()
        {
            var user = new User { Id = 1, Name = "Updated User", Email = "updateduser@example.com" };
            var result = controller.Edit(1, user) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(user.Name, UserController.userlist.First(u => u.Id == 1).Name);
            Assert.AreEqual(user.Email, UserController.userlist.First(u => u.Id == 1).Email);
        }

        [TestMethod]
        public void Delete_Get()
        {
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as User;
            Assert.AreEqual(testUser, model);
        }

        [TestMethod]
        public void Delete_Post()
        {
            var result = controller.Delete(1, null) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsFalse(UserController.userlist.Contains(testUser));
        }
    }
}
