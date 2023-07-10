using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.Gedcom.Core;

namespace velocist.Tests {

    /// <summary>
    /// Gedcom tests
    /// </summary>
    [TestClass]
    public class Gedcom {

        private static TestContext testContext;

        /// <summary>
        /// Initialize the class test
        /// </summary>
        /// <param name="_testContext">TestContext</param>
        [ClassInitialize]
        public void SetupTests(TestContext _testContext) {
            try {
                testContext = _testContext;
            } catch (Exception ex) {
                testContext.WriteLine(ex.Message, ex);
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        [TestMethod]
        public void ReadFile() {
            try {
                IEnumerable<string> list = GedcomFileManager.Read(@"C:\Users\Cristina\Desktop\base.txt");

                Assert.IsNotNull(list, "List is null");
                testContext.WriteLine("Get succesfull.");
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }

        /// <summary>
        /// Sets the TreeView.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        [TestMethod]
        public void SetTreeView() {
            try {
                IEnumerable<string> list = GedcomFileManager.Read(@"C:\Users\Cristina\OneDrive\Genealogia\RootsMagic\Data\baseMyHeritage202205171523_v2ToRootMagic.ged");



                Assert.IsNotNull(list, "List is null");
                testContext.WriteLine("Get succesfull.");
            } catch (Exception ex) {
                throw new Exception($"{ex.Message + Environment.NewLine + ex.InnerException}", ex);
            }
        }


    }
}
