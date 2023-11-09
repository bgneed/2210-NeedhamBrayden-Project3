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
    }
}