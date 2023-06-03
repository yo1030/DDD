﻿using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDDWinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherListViewModelTest
    {
        [TestMethod]
        public void 天気一覧画面シナリオ()
        {
            Mock<IWeatherRepository> weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WeatherEntity>();
            entities.Add(
                new WeatherEntity(
                    1,
                    "東京",
                    Convert.ToDateTime("2018/01/01 12:34:56"),
                    2,
                    12.3f));

            entities.Add(
                new WeatherEntity(
                    2,
                    "神戸",
                    Convert.ToDateTime("2018/01/02 16:34:56"),
                    1,
                    22.45f));

            weatherMock.Setup(x => x.GetData()).Returns(entities);

            WeatherListViewModel viewModel =
                new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);
            viewModel.Weathers[0].AreaId.Is("0001");
            viewModel.Weathers[0].AreaName.Is("東京");
            viewModel.Weathers[0].DataDate.Is("2018/01/01 12:34:56");
            viewModel.Weathers[0].Condition.Is("曇り");
            viewModel.Weathers[0].Temperature.Is("12.30 ℃");
        }
    }
}
