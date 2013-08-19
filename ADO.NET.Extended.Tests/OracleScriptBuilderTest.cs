#region Using statements

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ADO.NET.Extended.Connection.Database.Implementation;
using ADO.NET.Extended.Connection.Database.Interface;
using ADO.NET.Extended.Connection.Database.Oracle.Implementation;
using ADO.NET.Extended.Utilities.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace ADO.NET.Extended.Tests
{
    /// <summary>
    ///     This is a test class for OracleScriptBuilderTest and is intended
    ///     to contain all OracleScriptBuilderTest Unit Tests
    /// </summary>
    [TestClass]
    public class OracleScriptBuilderTest : TestBase
    {
        private readonly ICollection<ICommand> _testCommandCollection2 = new Collection<ICommand> {new OracleCommand("GRANT SELECT ON DUAL"), new OracleCommand("REVOKE SELECT ON DUAL")};

        private readonly ICollection<ICommand> _testCommandCollection4 = new Collection<ICommand>
                                                                             {
                                                                                     new OracleCommand("GRANT SELECT ON DUAL"),
                                                                                     new OracleCommand("REVOKE SELECT ON DUAL"),
                                                                                     new OracleCommand("GRANT SELECT ON DUAL"),
                                                                                     new OracleCommand("REVOKE SELECT ON DUAL")
                                                                             };

        private readonly string _testExpectedScript2 = string.Format("BEGIN{0}" +
                                                                     "EXECUTE IMMEDIATE ('GRANT SELECT ON DUAL');{0}" +
                                                                     "EXECUTE IMMEDIATE ('REVOKE SELECT ON DUAL');{0}" +
                                                                     "END;{0}",
                                                                     Environment.NewLine);

        private readonly string _testExpectedScript4 = string.Format("BEGIN{0}" +
                                                                     "EXECUTE IMMEDIATE ('GRANT SELECT ON DUAL');{0}" +
                                                                     "EXECUTE IMMEDIATE ('REVOKE SELECT ON DUAL');{0}" +
                                                                     "EXECUTE IMMEDIATE ('GRANT SELECT ON DUAL');{0}" +
                                                                     "EXECUTE IMMEDIATE ('REVOKE SELECT ON DUAL');{0}" +
                                                                     "END;{0}",
                                                                     Environment.NewLine);

        /// <summary>
        ///     A test for Create
        /// </summary>
        [TestMethod]
        public void CreateTest_WithBatchSize0()
        {
            var target = new OracleScriptBuilder();
            var commands = _testCommandCollection2;
            const int batchSize = 0;
            var expected = _testExpectedScript2;
            var actual = target.Create(commands, batchSize);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     A test for Create
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            var target = new OracleScriptBuilder();
            var commands = _testCommandCollection2;
            var expected = _testExpectedScript2;
            var actual = target.Create(commands);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With2CommandsAndWithBatchSize0()
        {
            const int batchSize = 0;
            var commands = _testCommandCollection2;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = commands,
                                                                         Script = _testExpectedScript2
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With2CommandsAndWithBatchSize2()
        {
            var commands = _testCommandCollection2;
            const int batchSize = 2;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = commands,
                                                                         Script = _testExpectedScript2
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With2CommandsAndWithBatchSize3()
        {
            var commands = _testCommandCollection2;
            const int batchSize = 3;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = commands,
                                                                         Script = _testExpectedScript2
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With4CommandsAndWithBatchSize0()
        {
            var commands = _testCommandCollection4;
            const int batchSize = 0;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = commands,
                                                                         Script = _testExpectedScript4
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With4CommandsAndWithBatchSize5()
        {
            var commands = _testCommandCollection4;
            const int batchSize = 5;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = commands,
                                                                         Script = _testExpectedScript4
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        /// <summary>
        ///     A test for CreateScriptBundles
        /// </summary>
        [TestMethod]
        public void CreateScriptBundlesTest_With4CommandsAndWithBatchSize2()
        {
            var commands = _testCommandCollection4;
            const int batchSize = 2;
            ICollection<ScriptBundle> expected = new Collection<ScriptBundle>
                                                     {
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = _testCommandCollection2,
                                                                         Script = _testExpectedScript2
                                                                 },
                                                             new ScriptBundle
                                                                 {
                                                                         Commands = _testCommandCollection2,
                                                                         Script = _testExpectedScript2
                                                                 }
                                                     };
            CreateScriptBundlesParameterisedTest(commands, batchSize, expected);
        }

        private void CreateScriptBundlesParameterisedTest(ICollection<ICommand> commands, int batchSize, ICollection<ScriptBundle> expected)
        {
            var target = new OracleScriptBuilder();
            var actual = target.CreateScriptBundles(commands, batchSize);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.AreEqual(expected));
        }
    }
}
