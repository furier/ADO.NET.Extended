using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADO.NET.Extended.Tests
{
    //[TestClass]
    public abstract class TestBase
    {
        protected TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        protected TestBase()
        {
        }

        //[ClassInitialize]
        public virtual void MyClassInitialize(TestContext testContext) { }

        //[ClassCleanup]
        public virtual void MyClassCleanup() { }

        //[TestInitialize]
        public virtual void MyTestInitialize() { }

        //[TestCleanup]
        public virtual void MyTestCleanup() { }
    }
}