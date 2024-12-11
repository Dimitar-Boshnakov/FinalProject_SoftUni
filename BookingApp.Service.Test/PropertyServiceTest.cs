using BookingApp.Data.Models;
using BookingApp.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingApp.Data;
using BookingApp.Web.ViewModels.Models.Property;

namespace BookingApp.Service.Test
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private BookingDbContext dbContext;
        private PropertyService propertyService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // In-memory DB
                .Options;

            dbContext = new BookingDbContext(options);
            propertyService = new PropertyService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose(); // Dispose of the context to free resources
        }

        [Test]
        public async Task AddPropertyAsync_ShouldAddProperty_WhenDataIsValid()
        {
            // Arrange
            var newProperty = new AddPropertyViewModel
            {
                Name = "New Property",
                Description = "New Description",
                Location = "New Location",
                PricePerNight = 200,
                ImgUrl = "newimage.jpg"
            };
            var userId = Guid.NewGuid();

            // Act
            var result = await propertyService.AddPropertyAsync(newProperty, userId);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, dbContext.Properties.Count());
            var addedProperty = dbContext.Properties.First();
            Assert.AreEqual("New Property", addedProperty.PropertyName);
            Assert.AreEqual(userId, addedProperty.OwnerId);
        }

        [Test]
        public async Task UpdatePropertyAsync_ShouldUpdateProperty_WhenDataIsValid()
        {
            // Arrange
            var property = new Property
            {
                Id = Guid.NewGuid(),
                PropertyName = "Old Property",
                Description = "Old Description",
                Location = "Old Location",
                PricePerNight = 100,
                ImgUrl = "oldimage.jpg",
                OwnerId = Guid.NewGuid(),
                IsAvailable = true
            };
            dbContext.Properties.Add(property);
            await dbContext.SaveChangesAsync();

            var updatedProperty = new EditPropertyViewModel
            {
                Id = property.Id,
                Name = "Updated Property",
                Description = "Updated Description",
                Location = "Updated Location",
                PricePerNight = 300,
                ImgUrl = "updatedimage.jpg"
            };

            // Act
            var result = await propertyService.UpdatePropertyAsync(updatedProperty, property.OwnerId);

            // Assert
            Assert.IsTrue(result);
            var updatedEntity = dbContext.Properties.First(p => p.Id == property.Id);
            Assert.AreEqual("Updated Property", updatedEntity.PropertyName);
            Assert.AreEqual("Updated Description", updatedEntity.Description);
        }

        [Test]
        public async Task DeletePropertyAsync_ShouldRemoveProperty_WhenOwnerIsValid()
        {
            // Arrange
            var property = new Property
            {
                Id = Guid.NewGuid(),
                PropertyName = "Test Property",
                Description = "Test Description",
                Location = "Test Location",
                PricePerNight = 100,
                ImgUrl = "testimage.jpg",
                OwnerId = Guid.NewGuid(),
                IsAvailable = true
            };
            dbContext.Properties.Add(property);
            await dbContext.SaveChangesAsync();

            // Act
            var result = await propertyService.DeletePropertyAsync(property.Id, property.OwnerId);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, dbContext.Properties.Count());
        }

        [Test]
        public async Task DeletePropertyAsync_ShouldNotRemoveProperty_WhenOwnerIsInvalid()
        {
            // Arrange
            var property = new Property
            {
                Id = Guid.NewGuid(),
                PropertyName = "Test Property",
                Description = "Test Description",
                Location = "Test Location",
                PricePerNight = 100,
                ImgUrl = "testimage.jpg",
                OwnerId = Guid.NewGuid(),
                IsAvailable = true
            };
            dbContext.Properties.Add(property);
            await dbContext.SaveChangesAsync();

            var invalidOwnerId = Guid.NewGuid();

            // Act
            var result = await propertyService.DeletePropertyAsync(property.Id, invalidOwnerId);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, dbContext.Properties.Count());
        }
    }
}
