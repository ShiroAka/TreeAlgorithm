TreeAlgorithm

This project will contain programs in different languages to work with trees based on an unsorted nodes list, where each node contains an id and the id of its parent node.

=============================================================
For example, if I have the following tree:
    
    4
 2     6
7 1   8 3

And an unsorted list with the nodes:
  
[{id: 2, parent_id: 4},
  {id: 1, parent_id: 2},
  {id: 6, parent_id: 4},
  {id: 4, parent_id: null} .... ]
 
 
I want to put the nodes in the following structure:

Class Node {
  int id,
  List<Node> childs,

}

And be able to the tree's root, and do other things with said tree (e.g.: draw the tree in the console)
