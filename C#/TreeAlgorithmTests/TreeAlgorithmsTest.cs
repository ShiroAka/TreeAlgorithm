using NUnit.Framework;
using System.Collections.Generic;
using TreeAlgorithm;

namespace UnitTests
{
    public class TreeAlgorithmsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<NodeListItem> nodeList = new List<NodeListItem>();
            nodeList.Add(new NodeListItem { Id = 2, ParentId = 4 });
            nodeList.Add(new NodeListItem { Id = 1, ParentId = 2 });
            nodeList.Add(new NodeListItem { Id = 6, ParentId = 4 });
            nodeList.Add(new NodeListItem { Id = 4, ParentId = null });
            nodeList.Add(new NodeListItem { Id = 8, ParentId = 6 });
            nodeList.Add(new NodeListItem { Id = 7, ParentId = 2 });
            nodeList.Add(new NodeListItem { Id = 3, ParentId = 6 });

            Node rootNode = TreeAlgorithms.ProcessAndPrintTree(nodeList);

            Assert.AreEqual(rootNode.Id, 4);
        }
    }
}