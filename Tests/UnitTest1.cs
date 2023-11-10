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
        [TestCategory("Time Increment Test")]
        [TestMethod]
        public void AddTime()
        {
            TimeIncrement.AddIncrement();
            Assert.AreEqual(TimeIncrement.GetIncrement(), "Early Morning");
            TimeIncrement.AddIncrement();
            TimeIncrement.AddIncrement();
            TimeIncrement.AddIncrement();
            TimeIncrement.AddIncrement();
            TimeIncrement.AddIncrement();
            TimeIncrement.AddIncrement();
            Assert.AreEqual(TimeIncrement.GetIncrement(), "Morning");
        }

        [TestCategory("Truck Tests")]
        [TestMethod]
        public void CreateListOfCrates()
        {
            //Arrange
            Truck truck = new();
            List<Crate> crates = new();

            //Act
            crates = truck.GenerateCrates();

            //Assert
            Assert.IsTrue(crates.Count > 0 && crates.Count <= 100);
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
        public void JoinLineIncrementsCount()
        {
            //Arrange
            Truck truck = new();
            Dock dock = new();

            //Act
            dock.JoinLine(truck);

            //Assert
            Assert.AreEqual(1, dock.Line.Count);
        }

        [TestMethod]
        public void SendOffReturnsTruck()
        {
            //Arrange
            Crate crate = new();
            Truck truck = new();
            Dock dock = new();
            truck.Load(crate);
            dock.JoinLine(truck);

            //Act
            Truck returned = dock.SendOff();

            //Assert
            Assert.AreEqual(truck, returned);
        }

        [TestMethod]
        public void SendOffIncrementsTime()
        {
            //Arrange
            string ID = "1";
            uint time = 10;
            List<Crate> crates = new();

            for (int i = 0; i < 10; i++)
            {
                Crate c = new(ID, time);
                crates.Add(c);
            }

            Truck truck = new();
            Dock dock = new();

            //Act
            truck.Load(crates);

            dock.JoinLine(truck);

            dock.SendOff();

            //Assert
            Assert.AreEqual((uint)100, dock.TotalTimeInUse);
        }
    }
}