using System;
using DonkeysGOL.Console.View;
using NUnit.Framework;
using System.Timers;

namespace DonkeysGOL.Tests.DonkeysGOL.Console.Tests
{
    [TestFixture]
    public class CrudeRendererTests
    {
        [Test]
        public void PeriodicRenderWithNullArgument()
        {
            Assert.Throws<NullReferenceException>(() => CrudeRenderer.PeriodicRender(null));
        }

        [Test]
        public void RenderStateWithNullArgument()
        {
            Assert.Throws<NullReferenceException>(() => CrudeRenderer.RenderState(null));
        }
    }
}
