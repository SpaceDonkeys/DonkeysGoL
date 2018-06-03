using System;
using DonkeysGOL.Core.Models;
using NUnit.Framework;

namespace DonkeysGOL.Tests.DonkeysGOL.Core.Tests
{
    [TestFixture]
    public class SpaceTests
    {
        private Space space;
        

        [SetUp]
        public void TestInitialize()
        {
            space = new Space(100);
            setFixedValuesInSpaceArray();
        }

        [Test]
        public void InitializationByDefaultConstructor()
        {
            Space temp = new Space();
            Assert.IsNotNull(temp.SpaceArray);
        }

        [Test]
        public void InitializationByOneParameterConstructor()
        {
            Space temp = new Space(50);
            Assert.IsNotNull(temp.SpaceArray);
        }

        [Test]
        public void InitializationByTwoParameterConstructor()
        {
            Space temp = new Space(50, 30);
            Assert.IsNotNull(temp.SpaceArray);
        }

        [Test]
        public void PassNegativeToOneParameterConstructor()
        {
            Assert.Throws<OverflowException>(() => new Space(-10));
        }

        [Test]
        public void PassFirstNegativeToTwoParameterConstructor()
        {
            Assert.Throws<OverflowException>(() => new Space(-10, 50));
        }

        [Test]
        public void GetCellWithTooSmallParameters()
        {
            Assert.AreEqual(space.GetCell(-10, -30), space.SpaceArray[90, 70]);
        }

        [Test]
        public void GetCellWithValidParameters()
        {
            Assert.AreEqual(space.GetCell(10, 10), space.SpaceArray[10, 10]);
        }

        [Test]
        public void GetCellWithTooBigParameters()
        {
            Assert.AreEqual(space.GetCell(150, 111), space.SpaceArray[50,11]);
        }

        [Test]
        public void CountNeighborhoodForNotBoundaryCell()
        {
            Space tempSpace = new Space(4);

            for (int i = 1; i <= 3; ++i)
                for (int j = 1; j <= 3; ++j)
                    tempSpace.SpaceArray[i, j] = true;

            Assert.AreEqual(8u, tempSpace.CountNeighborhood(2, 2));
        }

        [Test]
        public void CountNeighborhoodForVerticalBoundaryCell()
        {
            Space tempSpace = createTempSpaceForTest();

            Assert.AreEqual(6u, tempSpace.CountNeighborhood(2, 0));
        }

        [Test]
        public void CountNeighborhoodForHorizontalBoundaryCell()
        {
            Space tempSpace = createTempSpaceForTest();

            Assert.AreEqual(6u, tempSpace.CountNeighborhood(0, 1));
        }

        [Test]
        public void CountNeighborhoodForCornerCell()
        {
            Space tempSpace = createTempSpaceForTest();

            Assert.AreEqual(7u, tempSpace.CountNeighborhood(3, 3));
        }


        private void setFixedValuesInSpaceArray()
        {
            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++j)
                {
                    if (((i * 100 + j) % 3) == 0)
                        space.SpaceArray[i, j] = true;
                    else
                        space.SpaceArray[i, j] = false;
                }
            }
        }

        private Space createTempSpaceForTest()
        {
            Space temp = new Space(4);

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (i == 0 || i == 3)
                        temp.SpaceArray[i, j] = true;
                    else if (j == 0 || j == 3)
                        temp.SpaceArray[i, j] = true;
                    else
                        temp.SpaceArray[i, j] = false;
                }
            }

            return temp;
        }

    }
}
