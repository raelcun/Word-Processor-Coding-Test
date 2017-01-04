using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace US.WordProcessor.Tests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void FlattenSingleLevel()
        {
            var a = new List<List<int>> {new List<int> {1, 2}, new List<int> {2}};
            var ev = new List<int> {1, 2, 2};
            var av = a.Flatten();

            Assert.IsTrue(ev.SequenceEqual(av));
        }

        [TestMethod]
        public void FlattenMultiLevel()
        {
            var a = new List<List<List<int>>>
            {
                new List<List<int>> {new List<int> {1, 2}},
                new List<List<int>> {new List<int> {2}}
            };
            var ev = new List<List<int>> {new List<int> {1, 2}, new List<int> {2}};
            var av = a.Flatten().ToList();

            Assert.AreEqual(ev.Count, av.Count);
            for (int i = 0; i < ev.Count; i++)
                Assert.IsTrue(ev[i].SequenceEqual(av[i]));
        }
    }
}
