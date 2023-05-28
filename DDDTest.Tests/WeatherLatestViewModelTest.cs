using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDDWinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            Mock<IWeatherRepository> weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(
                new WeatherEntity(
                    1,
                    Convert.ToDateTime("2018/01/01 12:34:56"),
                    2,
                    12.3f));

            weatherMock.Setup(x => x.GetLatest(2)).Returns(
                new WeatherEntity(
                    2,
                    Convert.ToDateTime("2018/01/02 16:34:56"),
                    1,
                    22.45f));

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));
            areas.Add(new AreaEntity(3, "沖縄"));
            var areasMock = new Mock<IAreasRepository>();
            areasMock.Setup(x => x.GetData()).Returns(areas);

            WeatherLatestViewModel viewModel = new WeatherLatestViewModel(
                    weatherMock.Object,
                    areasMock.Object);
            Assert.IsNull(viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionsText);
            Assert.AreEqual("", viewModel.TemperatureText);
            Assert.AreEqual(3, viewModel.Areas.Count);
            Assert.AreEqual(1, viewModel.Areas[0].AreaId);
            Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
            Assert.AreEqual(2, viewModel.Areas[1].AreaId);
            Assert.AreEqual("神戸", viewModel.Areas[1].AreaName);

            viewModel.SelectedAreaId = 1;
            viewModel.Search();
            Assert.AreEqual(1, viewModel.SelectedAreaId);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionsText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.SelectedAreaId = 2;
            viewModel.Search();
            Assert.AreEqual(2, viewModel.SelectedAreaId);
            Assert.AreEqual("2018/01/02 16:34:56", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionsText);
            Assert.AreEqual("22.45 ℃", viewModel.TemperatureText);

            viewModel.SelectedAreaId = 3;
            viewModel.Search();
            Assert.AreEqual(3, viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionsText);
            Assert.AreEqual("", viewModel.TemperatureText);
        }
    }
}
