using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opsin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opsin.Tests
{
    [TestClass()]
    public class NameToStructureTests
    {
        static readonly NameToStructure nts = NameToStructure.Instance;

        [TestMethod()]
        public void ParseChemicalNameTest()
        {
            nts.ParseToSmiles("acetonitrile");
            nts.ParseToCML("acetonitrile");
            nts.ParseChemicalName("acetonitrile");
        }
    }
}
