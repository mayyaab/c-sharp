﻿using System;
using System.Collections.Generic;
using System.Text;

namespace List1
{
    public class List
    {
        private Node firstElement;

        public void AddElement(int data)
        {
            var addElement = new Node
            {
                data = data,
                next = firstElement
            };

            firstElement = addElement;
        }

        public int GetSize()
        {
            int index = 0;
            //initilizer; conditioner; itarator
            for (var element = firstElement; element != null; element = element.next)
            {
                index++;
                // var element = firstElement - initialized element
                // element != null - comparesent 
                //element = element.next - action which we perform at the end of the loop 
            }
            return index;
        }


        public void AddNElement(int index, int data)
        {
            if (index < 0)
            {
                throw new Exception("Index is negative");
            }
            if (index > GetSize())
            {
                throw new Exception("Index is bigger than list size");
            }
            Node addElement = new Node();
            addElement.data = data;
            if (index == 0)
            {
                addElement.next = firstElement;
                firstElement = addElement;
            }
            else
            {
                Node currentElement = firstElement;
                for (int currentIndex = 0; currentIndex < index - 1; currentIndex++)
                {
                    currentElement = currentElement.next;
                }
                addElement.next = currentElement.next;
                currentElement.next = addElement;
            }
        }

        public void DeleteNElement(int index)
        {
            Node currentElement = firstElement;
            /*if (firstElement == null)
            {
                throw new Exception("No element to delete");
            }*/
            if (index < 0)
            {
                throw new Exception("Index is negative");
            }
            if (index >= GetSize())
            {
                throw new Exception("Index is bigger than list size");
            }
            if (index == 0)
            {
                firstElement = firstElement.next;
            }
            else
            {
                for (int currentIndex = 0; currentIndex < index - 1; currentIndex++)
                {

                    currentElement = currentElement.next;
                }
                currentElement.next = currentElement.next.next;
            }
        }

        public void PrintList()
        {
            for (Node currentNode = firstElement; currentNode != null; currentNode = currentNode.next)
            {
                Console.WriteLine(currentNode.data);
            }

            // first initialization
            // condition if 
            // body 
            // last statement
            // goto condition if
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
            }

        }

    }
}