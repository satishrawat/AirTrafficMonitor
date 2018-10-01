﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.IntegrationTests
{
    [TestFixture()]
    public class GeneralTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container();
            _container.Configure();
            
        }

        [Test]
        public void Test1()
        {
            var fakeView = Substitute.For<IView>();
            fakeView
                .Render(Arg.Do<AirTrafficTrack>(arg => Console.Write(arg.RawData)));

            fakeView.Render(new AirTrafficTrack("test"));
        }
    }
}
