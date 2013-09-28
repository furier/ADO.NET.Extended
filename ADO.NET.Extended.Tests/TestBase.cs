#region File Header

// //////////////////////////////////////////////////////
// /// File: TestBase.cs
// /// Author: Sander Struijk
// /// Date: 2013-09-28 14:50
// //////////////////////////////////////////////////////

#endregion

#region Using Directives

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace ADO.NET.Extended.Tests
{
    //[TestClass]
    /// <summary>   Test base. </summary>
    /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
    public abstract class TestBase
    {
        /// <summary>   The test context instance. </summary>
        protected TestContext testContextInstance;

        /// <summary>   Gets or sets the test context which provides information about and functionality for the current test run. </summary>
        /// <value> The test context. </value>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        //[ClassInitialize]
        /// <summary>   My class initialize. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        /// <param name="testContext">  The test context. </param>
        public virtual void MyClassInitialize(TestContext testContext) {}

        //[ClassCleanup]
        /// <summary>   My class cleanup. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        public virtual void MyClassCleanup() {}

        //[TestInitialize]
        /// <summary>   My test initialize. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        public virtual void MyTestInitialize() {}

        //[TestCleanup]
        /// <summary>   My test cleanup. </summary>
        /// <remarks>   Sander Struijk, 31.08.2013. </remarks>
        public virtual void MyTestCleanup() {}
    }
}