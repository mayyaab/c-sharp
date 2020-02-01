using System;
using System.Collections.Generic;
using System.Text;

namespace List1
{
    public class DoublyLinkedList
    {
        private Node2 firstElement;
        public void AddElement(int data)
        {
            Node2 addedNode = new Node2();
            addedNode.data = data;
            addedNode.next = firstElement;
            addedNode.prev = null;
            firstElement = addedNode;
        }

        public void DeleteElement()
        {
            if (firstElement == null)
            {
                Console.WriteLine("No element to delete");
            }
            else
            {
                firstElement = firstElement.next;
                firstElement.prev = null;
            }
        }

        public void DeleteNElement(Node2 nodeToDelete)
        {
            // check for validity of the passed argument here
            if (nodeToDelete == null)
            {
                throw new IndexOutOfRangeException("Not valid element null");
            }

            if (nodeToDelete.next == null)
            {
                nodeToDelete.prev.next = null; 
            }
            if (firstElement == nodeToDelete)
            {
                firstElement = firstElement.next;
                firstElement.prev = null;
            }
            else
            {
                nodeToDelete.next.prev = nodeToDelete.prev;
                nodeToDelete.prev.next = nodeToDelete.next;
            }

        }

        public Node2 GetNodeByIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index can not be negative");
            }
            var currentElement = firstElement;
            for (int currentIndex = 0; currentIndex < index; currentIndex++)
            {

                currentElement = currentElement.next;
                if (currentElement == null)
                {
                    throw new IndexOutOfRangeException("Index is bigger than list size");
                }
            }
            return currentElement;
        }

        public int GetSize()
        {
            int index = 0;
            for (var element = firstElement; element != null; element = element.next)
            {
                index++;  
            }
            return index;
        }

        public void PrintList()
        {
            for (Node2 currentNode = firstElement; currentNode != null; currentNode = currentNode.next)
            {
                Console.WriteLine(currentNode.data);
            }
        }


    }
}