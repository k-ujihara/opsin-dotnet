using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Opsin.Tests
{
    [TestClass()]
    public class NameToInchiTests
    {
        static readonly NameToInchi nti = new NameToInchi();

        [TestMethod()]
        public void NameToInchiTest()
        {
            nti.ParseToInchi("acetonitrile");
            nti.ParseToStdInchi("acetonitrile");
            nti.ParseToStdInchiKey("acetonitrile");
        }
    }
}
