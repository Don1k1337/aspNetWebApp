using System;
using System.Collections.Generic;
using System.Text;
using Danil_Popov_1040.DAL.Entities;
using Danil_Popov_1040.Models;
using Xunit;

namespace Danil_Popov_1040.TESTS
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Dish>

            .GetModel(TestData.GetDishesList(), 1, 3);

            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]

        public void ListViewModelSelectsCorrectQty(int page, int qty,
        int id)
        {
            // Act
            var model = ListViewModel<Dish>

            .GetModel(TestData.GetDishesList(), page, 3);

            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]

        public void ListViewModelHasCorrectData(int page, int qty, int
        id)
        {
            // Act
            var model = ListViewModel<Dish>

            .GetModel(TestData.GetDishesList(), page, 3);

            // Assert
            Assert.Equal(id, model[0].DishId);
        }
    }
}
