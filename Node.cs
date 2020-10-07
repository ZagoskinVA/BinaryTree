
using System;
using System.Collections;

namespace BinaryTree
{
    public class Node<Tkey,Tvalue> where Tkey : IComparable,IComparable<Tkey>
    {
        public Tkey Key { get; }
        public Tvalue Data { get; }
        public Node<Tkey, Tvalue> LeftNode { get; private set; }
        public Node<Tkey,Tvalue> RightNode { get; private set; }

        public Node(Tkey key , Tvalue value)
        {
            Key = key;
            Data = value;
        }

        public void AddNode(Tkey key, Tvalue data) 
        {

            if( Key.CompareTo(key) == 1) 
            {
                if (LeftNode == null)
                {
                    LeftNode = new Node<Tkey, Tvalue>(key, data);
                }
                else
                    LeftNode.AddNode(key,data);
            }
            else 
            {
                if (RightNode == null)
                    RightNode = new Node<Tkey, Tvalue>(key, data);
                else
                    RightNode.AddNode(key, data);
             }

        }


    }
}
