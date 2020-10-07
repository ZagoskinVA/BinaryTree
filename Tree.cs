
using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree<Tkey, Tvalue>   where Tkey : IComparable, IComparable<Tkey>
    {
        public Node<Tkey, Tvalue> Root { get; private set; }
        private List<Node<Tkey,Tvalue>> data;
        
        public void Add(Tkey key, Tvalue data)
        {
            if (Root == null)
                Root = new Node<Tkey, Tvalue>(key, data);
            else
                Root.AddNode(key, data);
        }
        // Поискпо ключу
        public Tvalue FindByKey(Tkey key)
        {
            var result = FindByKey(key, Root);
            return result;
         }

        private Tvalue FindByKey(Tkey key,Node<Tkey,Tvalue> node)
        {


          
            if (node == null)
                return default(Tvalue);
            if (node.Key.CompareTo(key) == 0)
                return node.Data;
            else if (node.Key.CompareTo(key) == 1)
                FindByKey(key, node.LeftNode);
            else
                FindByKey(key, node.RightNode);
            return default(Tvalue);
         }
         // Поиск в интервале
         public IEnumerable<Node<Tkey,Tvalue>> FindInInterval(Tkey startPoint, Tkey endPoint)
         {
         	data = new List<Node<Tkey,Tvalue>>();
         	FindInInterval(Root,startPoint,  endPoint);
         	var list = new List<Node<Tkey,Tvalue>>(data);
         	data = null;
         	return list;



         }
         private void FindInInterval(Node<Tkey,Tvalue> node, Tkey startPoint, Tkey endPoint)
         {
         	if(node != null)
         	{
	         	if(node.Key.CompareTo(startPoint) == 1 && node.Key.CompareTo(endPoint) == -1)
	         	{
	         		data.Add(node);
                    FindInInterval(node.RightNode, startPoint, endPoint);
                    FindInInterval(node.LeftNode, startPoint, endPoint);
	         	}
                else if(node.Key.CompareTo(startPoint) == -1)
	         	         FindInInterval(node.RightNode, startPoint, endPoint);
                else if(node.Key.CompareTo(endPoint) == 1)
	         	         FindInInterval(node.LeftNode, startPoint, endPoint);
                                            
         	}
         }

         

         // Обход дерева
        public IEnumerable<Node<Tkey,Tvalue>> PreOrderTravers()
        {
        	data = new List<Node<Tkey,Tvalue>>();
            PreOrderTravers(Root);
            var list = new List<Node<Tkey,Tvalue>>(data);
            data = null;
            return list;

         }
        private void PreOrderTravers(Node<Tkey, Tvalue> node)
        {

            if(node != null)
            {
                PreOrderTravers(node.LeftNode);
                data.Add(node);
                PreOrderTravers(node.RightNode);
             }

        }

        



    }
}
