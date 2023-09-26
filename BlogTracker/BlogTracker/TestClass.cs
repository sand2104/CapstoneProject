using BlogTracker.Controllers;
using BlogTracker.Data;
using BlogTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BlogTracker
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void BlogInfoTest()
        {
            //Arrange 
            var blogid = new BlogInfo { BlogInfoId = 1 };
            var blogTitle = new BlogInfo { Title = "Test" };

            //Act
            var blogIdTest = blogid.BlogInfoId;
            var blogTitleTest = blogTitle.Title;

            //Assert
            Assert.AreEqual(1, blogIdTest);
            Assert.AreEqual("Test", blogTitleTest);
        }

        [Test]
        public void EmpInfoTest()
        {
            //Arrange
            var empid = new EmpInfo { EmpInfoId = 1 };
            var empName = new EmpInfo { Name = "Name" };

            //Act
            var empIdTest = empid.EmpInfoId;
            var empNameTest = empName.Name;

            //Assert
            Assert.AreEqual(1, empIdTest);
            Assert.AreEqual("Name", empNameTest);
        }

        //Moq Test
        [Test]
        public async Task Create_ValidEmpInfo_RedirectsToIndex()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BlogTrackerDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mockContext = new Mock<BlogTrackerDbContext>(options);
            var controller = new EmpInfoesController(mockContext.Object);

            var empInfo = new EmpInfo
            {
                EmpInfoId = 1,
                EmailId = "test@example.com",
                Name = "John Doe",
                DateOfJoining = DateTime.Now,
                PassCode = 1234
            };

            // Act
            var result = await controller.Create(empInfo) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

    }
}
