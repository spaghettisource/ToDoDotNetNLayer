using System.Web.Mvc;
using AutoMapper;
using Core;
using Moq;
using ToDoDotNet.Controllers;
using ToDoDotNet.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ToDoDotNet.Tests
{
    [TestFixture]
    public class TestToDoController
    {
        [Test]
        public async Task Index()
        {
            // Arrange
            var repository = new Mock<IToDoRepository>();
            var mapper = new Mock<IMapper>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var query = new Mock<ToDoQueryResource>();
            ToDoController controller = new ToDoController(repository.Object, unitOfWork.Object, mapper.Object);

            // Act
            ViewResult result = await controller.Index(query.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Edit()
        {
            // Arrange
            var repository = new Mock<IToDoRepository>();
            var mapper = new Mock<IMapper>();
            var unitOfWork = new Mock<IUnitOfWork>();
            ToDoController controller = new ToDoController(repository.Object, unitOfWork.Object, mapper.Object);

            // Act
            ViewResult result = await controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
