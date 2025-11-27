using System;
using System.Threading.Tasks;
using Geometry.Domain;
using Moq;
using Xunit;

namespace Geometry.Application.Tests
{
    public class CylinderServiceTests
    {
        private readonly Mock<ICylinderRepository> _repoMock;
        private readonly CylinderService _service;

        public CylinderServiceTests()
        {
            _repoMock = new Mock<ICylinderRepository>();
            _service = new CylinderService(_repoMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateAndSaveCylinder()
        {
            // Arrange
            double radius = 3;
            double height = 10;

            // Act
            var result = await _service.CreateAsync(radius, height);

            // Assert
            Assert.Equal(radius, result.Radius);
            Assert.Equal(height, result.Height);

            _repoMock.Verify(r => r.AddAsync(It.IsAny<Cylinder>()), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnCylinder_WhenExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cylinder = new Cylinder(2, 5);
            _repoMock.Setup(r => r.GetAsync(id)).ReturnsAsync(cylinder);

            // Act
            var result = await _service.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cylinder.Radius, result!.Radius);
            Assert.Equal(cylinder.Height, result.Height);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull_WhenNotFound()
        {
            var id = Guid.NewGuid();
            _repoMock.Setup(r => r.GetAsync(id)).ReturnsAsync((Cylinder?)null);

            var result = await _service.GetAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateCylinder_WhenExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cylinder = new Cylinder(2, 3);

            _repoMock.Setup(r => r.GetAsync(id)).ReturnsAsync(cylinder);

            // Act
            await _service.UpdateAsync(id, 10, 20);

            // Assert
            Assert.Equal(10, cylinder.Radius);
            Assert.Equal(20, cylinder.Height);

            _repoMock.Verify(r => r.UpdateAsync(cylinder), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenCylinderNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _repoMock.Setup(r => r.GetAsync(id)).ReturnsAsync((Cylinder?)null);

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.UpdateAsync(id, 10, 20));
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepository()
        {
            var id = Guid.NewGuid();

            await _service.DeleteAsync(id);

            _repoMock.Verify(r => r.DeleteAsync(id), Times.Once);
        }
    }
}
