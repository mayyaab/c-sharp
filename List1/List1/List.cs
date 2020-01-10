using System;
using System.Collections.Generic;
using System.Text;

namespace List1
{
    public enum SortingOrder
    {
        Unsorted,
        Ascending,
        Descending
    }

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
            /*if (firstElement == null)
            {
                return 0;
            }*/
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
                throw new IndexOutOfRangeException("Index is negative");
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
                    if (currentElement == null)
                    {
                        throw new IndexOutOfRangeException("Index is bigger than list size");
                    }
                    currentElement = currentElement.next;
                }
                if (currentElement == null)
                {
                    throw new IndexOutOfRangeException("Index is bigger than list size");
                }
                addElement.next = currentElement.next;
                currentElement.next = addElement;
            }
        }

        public void DeleteNElement(int index)
        {
            Node currentElement = firstElement;
            if (firstElement == null)
            {
                throw new IndexOutOfRangeException("No element to delete");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is negative");
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
                if (currentElement.next == null)
                {
                    throw new IndexOutOfRangeException("Index is bigger than list size");
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

        public int GetValueOfElement(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Element can not be negative");
            }
            var currentElement = firstElement;
            if (firstElement == null)
            {
                throw new IndexOutOfRangeException("Index is bigger than list size");
            }
            for (int currentIndex = 0; currentIndex < index; currentIndex++)
            {

                currentElement = currentElement.next;
                if (currentElement == null)
                {
                    throw new IndexOutOfRangeException("Index is bigger than list size");
                }
            }
            return currentElement.data;
        }

        public void DeleteElementByValue(int data)
        {
            if (IsEmpty())
            {
                return;
            }

            Node currentElement = firstElement;
            if (currentElement.data == data)
            {
                firstElement = firstElement.next;
            }

            for (int currentIndex = 0; currentElement.next != null; currentIndex++)
            {
                if (currentElement.next.data == data)
                {
                    currentElement.next = currentElement.next.next;
                }
                else
                {
                    currentElement = currentElement.next;
                }
            }
        }

        public int GetIndexByValue(int data)
        {
            Node currentElement = firstElement;
            for (int currentIndex = 0; currentElement != null; currentIndex++)
            {
                if (currentElement.data == data)
                {
                    return currentIndex;
                }
                else
                {
                    currentElement = currentElement.next;
                }
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return firstElement == null;
        }

        public void DeleteElementByValueIfValueKnown(int data)
        {
            int index = 0;
            while (true) // for (;;) // do {} while (true)
            {
                index = GetIndexByValue(data);
                if (index == -1)
                {
                    return;
                }
                DeleteNElement(index);
            }
        }

        public int ReturnTheBiggestValueInTheList()
        {
            if (firstElement == null)
            {
                throw new ArgumentOutOfRangeException("No element in the list");
            }
            Node currentElement = firstElement;
            int max = currentElement.data;

            while (currentElement != null)
            {
                if (currentElement.data >= max)
                {
                    max = currentElement.data;
                }
                currentElement = currentElement.next;
            }
            return max;
        }

        public int ReturnTheMinValueInTheList()
        {
            if (firstElement == null)
            {
                throw new ArgumentOutOfRangeException("No element in the list");
            }
            Node currentElement = firstElement;
            int min = currentElement.data;

            while (currentElement != null)
            {
                if (currentElement.data <= min)
                {
                    min = currentElement.data;
                }
                currentElement = currentElement.next;
            }
            return min;
        }

        public bool IsSymmetric()
        {
            int size = GetSize();

            for (int i = 0; i < size / 2; i++)
            {
                int leftSideIndex = i;
                int rightSideIndex = size - 1 - i;

                int leftSideValue = GetValueOfElement(leftSideIndex);
                int rightSideValue = GetValueOfElement(rightSideIndex);

                if (rightSideValue != leftSideValue)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsSortedAscending()
        {
            if (firstElement == null)
            {
                return true;
            }
            
            for (Node currentElement = firstElement; currentElement.next != null; currentElement = currentElement.next )
            {
                if (currentElement.data > currentElement.next.data)
                {
                    return false;
                }    
            }
            return true;
        }

        public bool IsSortedDescending()
        {
            if (firstElement == null)
            {
                return true;
            }

            for (Node currentElement = firstElement; currentElement.next != null; currentElement = currentElement.next)
            {
                if (currentElement.data < currentElement.next.data)
                {
                    return false;
                }
            }
            return true;
        }

        public SortingOrder IncreasingOrDecrising()
        {
            if (IsSortedAscending())
            {
                return SortingOrder.Ascending;
            }
            else if (IsSortedDescending())
            {
                return SortingOrder.Descending;
            }
            else
            {
                return SortingOrder.Unsorted;
            }
        }
    }
}