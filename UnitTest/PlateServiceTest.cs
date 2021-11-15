using BackendHomework.Core.Entities;
using BackendHomework.Core.Exceptions;
using BackendHomework.Core.Interfaces;
using BackendHomework.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PlateServiceTest
    {
        private Mock<IPlateRepository> _plateRepository;
        private PlateService _plateService;
        [SetUp]
        public void SetUp()
        {
            _plateRepository = new Mock<IPlateRepository>();
            _plateService = new PlateService(_plateRepository.Object);
        }

        [Test]
        public async Task UpdatePlate_ShouldReturnSuccess_WhenUpdateAnExistingPlate()
        {
            var userId = Guid.NewGuid().ToString();
            var plate = new Plate()
            {
                Id = Guid.NewGuid(),
                Description = "Chicken crepe",
                Name = "Crepes",
                Price = 12000,
                Type = "Main",
                UserId = userId

            };

            _plateRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(plate);
            _plateRepository.Setup(x => x.Update(It.IsAny<Plate>())).ReturnsAsync(true);
            var response = await _plateService.UpdatePlate(plate, userId);
            Assert.IsTrue(response);
        }

        [Test]
        public  void  UpdatePlate_ShouldReturnException_WhenUpdateAnUnexistingPlate()
        {
            var userId = Guid.NewGuid().ToString();
            var plate = Mock.Of<Plate>();

            _plateRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync((Plate)null);
             
            Assert.ThrowsAsync<BusinessException>(async () => await _plateService.UpdatePlate(plate, userId));
        }

        [Test]
        public void UpdatePlate_ShouldReturnException_WhenAPlateDontBelongsToUser()
        {
            var userId = Guid.NewGuid().ToString();
            var plate = Mock.Of<Plate>();

            _plateRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(plate);
             
            Assert.ThrowsAsync<BusinessException>(async () => await _plateService.UpdatePlate(plate, userId));
        }
    }
}
