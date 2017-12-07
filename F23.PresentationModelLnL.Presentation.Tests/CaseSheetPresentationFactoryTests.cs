using System;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.ReadModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace F23.PresentationModelLnL.Presentation.Tests
{
    [TestClass]
    public class CaseSheetPresentationFactoryTests
    {
        [TestMethod]
        public async Task GetCaseSheetDetailsAsync_HappyPath()
        {
            // Arrange
            var caseSheetDetails = new CaseSheetDetails
            {
                Id = 1,
                CaseDate = new DateTime(2017, 1, 1),
                CaseSheetNumber = "CS-1",
                IsProcessed = false,
                LocationId = 1,
                LocationName = "Test Location",
                TotalCost = 50m
            };
            var mockRepo = new Mock<ICaseSheetRepository>();
            mockRepo.Setup(x => x.GetCaseSheetDetailsAsync(1)).ReturnsAsync(caseSheetDetails);
            var factory = new CaseSheets.CaseSheetPresentationFactory(mockRepo.Object);

            // Act
            var result = await factory.GetCaseSheetDetailsAsync(caseSheetDetails.Id, false, false, 1);

            // Assert
            // TODO.JS: case sheet products
            Assert.AreEqual(caseSheetDetails, result.CaseSheetDetails);
            Assert.IsFalse(result.CanDelete);
            Assert.IsFalse(result.CanEdit);
        }
    }
}
