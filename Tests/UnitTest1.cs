using _2210_NeedhamBrayden_Project3;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("Crate Tests")]
        [TestMethod]
        public void CrateDefaultCtorTest()
        {
            Crate crate = new Crate();
            Assert.IsNotNull(crate);
            Assert.AreEqual(crate.IdNumber,"0");
            Assert.AreEqual(crate.Price,0);
        }
        [TestMethod]
        public void CrateCopyCtorTest() 
        { 
            Crate toCopy = new Crate();
            Crate copy = new Crate(toCopy);
            Assert.IsNotNull(copy);
            Assert.AreEqual(toCopy.CompareTo(copy),0);
        }
        [TestMethod]
        public void CrateTimeTest()
        {
            Crate crate = new Crate("061543",20);
            Assert.IsNotNull(crate);
            Assert.AreEqual(crate.GetTime(),(uint)20);
        }

        [TestCategory("Truck Tests")]
        [TestMethod]
        public void CreateListOfCrates()
        {
            //Arrange
            Truck truck = new Truck();
            List<Crate> crates = new List<Crate>();

            //Act
            crates = truck.GenerateCrates();

            //Assert
            Assert.IsTrue(crates.Count > 0 && crates.Count <= 5);
        }

        [TestMethod]
        public void LoadTrailerFromList()
        {
            //Arrange
            Truck truck = new();
            List<Crate> crates = truck.GenerateCrates();

            //Act
            truck.Load(crates);

            //Assert
            Assert.AreEqual(crates.Count, truck.Trailer.Count);
        }

        [TestMethod]
        public void LoadTrailer()
        {
            //Arrange
            Truck truck = new();
            Crate crate = new();
            Crate crate2 = new();
            Crate crate3 = new();

            //Act
            truck.Load(crate);
            truck.Load(crate2);
            truck.Load(crate3);

            //Assert
            Assert.AreEqual(3, truck.Trailer.Count);
        }

        [TestMethod]
        public void UnloadReturnsCrate()
        {
            //Arrange
            Truck truck = new();
            Crate crate = new();
            truck.Load(crate);

            //Act
            Crate returned = truck.Unload(out uint time);

            //Assert
            Assert.AreEqual(crate, returned);
        }

        [TestMethod]
        public void UnloadReturnsTime()
        {
            //Arrange
            Truck truck = new();
            string ID = "1";
            uint time = 10;

            Crate crate = new(ID, time);
            truck.Load(crate);

            //Act
            truck.Unload(out uint unloadTime);

            //Assert
            Assert.AreEqual(time, unloadTime);
        }
        [TestCategory("Dock Tests")]
        [TestMethod]
        public void TruckEnterDock()
        {
            Dock dock = new Dock();
            Truck truck = new();
            dock.NewTruckIn(truck);
        }

        [TestCategory("Road Tests")]
        [TestMethod]
        public void UpdatingDocksIncrementsTime()
        {
            //Arrange
            Road r = new();
            Dock d = new();

            //Act
            r.UpdateTimeViaDock();

            //Assert
            Assert.AreEqual((uint)10, r.Time); 
        }

        [TestMethod]
        public void CrateUnloadTime()
        {
            //Arrange
            Road r = new();
            r.IncrementTime();

            Crate c = new();
            var time = c.GetTime();
            Truck t = new(r.Time);
            t.Load(c);

            //Act
            t.Unload(r.Time);

            //Assert
            Assert.AreEqual((uint)10, c.TimeWhenUnloaded);
            Assert.AreNotEqual(10, time);
        }

        [TestMethod]
        public void MultipleCratesUnloadTime()
        {
            Road r = new();
            Truck t = new();

            List<Crate> crates = new();

            for (int i = 0; i < 5; i++)
            {
                Crate c = new();
                crates.Add(c);
            }

            t.Load(crates);
            crates.Clear();

            var count = t.Trailer.Count;

            for (int i = 0; i < count; i++)
            {
                Crate c = t.Unload(r.Time);
                crates.Add(c);
                r.IncrementTime();
            }

            Assert.AreEqual((uint)0, crates[0].TimeWhenUnloaded);
            Assert.AreEqual((uint)10, crates[1].TimeWhenUnloaded);
            Assert.AreEqual((uint)20, crates[2].TimeWhenUnloaded);
            Assert.AreEqual((uint)30, crates[3].TimeWhenUnloaded);
            Assert.AreEqual((uint)40, crates[4].TimeWhenUnloaded);

        }
    }
}