using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeAlgorithm
{
    public static class TreeAlgorithms
    {   
		public static Node ProcessTree(List<NodeListItem> nodes)
		{
			Dictionary<int, int?> unsortedNodesList = new Dictionary<int, int?>();
			nodes.ForEach(x => unsortedNodesList.Add(x.Id, x.ParentId));

			List<Node> treeNodes = nodes.Select(x => new Node(x.Id)).ToList();

			treeNodes.ForEach(x => {
				List<int> currentNodeChildrenIds = unsortedNodesList.Where(y => y.Value == x.Id) //Get the nodes (from the given nodes list) where the parentId equals the current node's Id
																	  .Select(z => z.Key)		//Get a new List containing only the corresponding node Ids
																	  .ToList();

				x.Children = treeNodes.Where(x => currentNodeChildrenIds.Contains(x.Id)).ToList(); //Get the nodes whose Ids are contained in the above list (which has the Ids of the current node's children)
			});

			int rootNodeId = unsortedNodesList.First(y => y.Value == null).Key;
			return treeNodes.FirstOrDefault(x => x.Id == rootNodeId);
        }

        public static void PrintTree(Node treeNode, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            Console.WriteLine(treeNode.Id);

			List<Node> children = treeNode.Children;
            
            for (int i = 0; i < children.Count; i++)
                PrintTree(children[i], indent, i == children.Count - 1);
        }

		public static Node ProcessAndPrintTree(List<NodeListItem> nodes)
        {
			Node rootNode = ProcessTree(nodes);
			PrintTree(rootNode, "", true);

			return rootNode;
        }
    }

	public class Node
	{
		public int Id { get; set; }
		public List<Node> Children { get; set; }

		public Node(int id)
        {
			this.Id = id;
			this.Children = null;
        }
	}

	public class NodeListItem
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
	}
}
