using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Danil_Popov_1040.Controllers;
using Danil_Popov_1040.DAL.Entities;
using Xunit;

namespace Danil_Popov_1040.TESTS
{
    public class ProductControllerTests
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controller = new ProductController();
            controller._dishes = new List<Dish>

            {
            new Dish{ DishId=1},
            new Dish{ DishId=2},
            new Dish{ DishId=3},
            new Dish{ DishId=4},
            new Dish{ DishId=5}
            };

            // Act
            var result = controller.Index(page) as ViewResult;
            var model = result?.Model as List<Dish>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].DishId);
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controller = new ProductController();
            var data = TestData.GetDishesList();
            controller._dishes = data;
            var comparer = Comparer<Dish>

            .GetComparer((d1, d2) => d1.DishId.Equals(d2.DishId));

            // act
            var result = controller.Index(2) as ViewResult;

            var model = result.Model as List<Dish>;
            // assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);
        }

    }
    public class TestData
    {


        public static List<Dish> GetDishesList()
        {
            return new List<Dish>
            {
            new Dish{ DishId=1, DishGroupId=1},
            new Dish{ DishId=2, DishGroupId=1},
            new Dish{ DishId=3, DishGroupId=2},
            new Dish{ DishId=4, DishGroupId=2},
            new Dish{ DishId=5, DishGroupId=3}
            };

        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }

    }


}
