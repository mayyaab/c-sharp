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

        public int MaxElement()
        {
            return MaxElement(0);
        }

        public int MaxElement(int startingIndex)
        {
            if (firstElement == null)
            {
                throw new ArgumentOutOfRangeException("No element in the list");
            }
            Node currentElement = firstElement;
            for (int i = 0; i != startingIndex; i++)
            {
                if (currentElement == null)
                {
                    throw new IndexOutOfRangeException("Index is bigger than list");
                }
                currentElement = currentElement.next;
            }

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

        public int MinElement()
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

        public Node MinElementReturnNode()
        {
            return MinElementReturnNode(firstElement);
        }

        public Node MinElementReturnNode(Node startingNode)
        {
            if (startingNode == null)
            {
                throw new ArgumentOutOfRangeException("No element in the list");
            }

            Node currentElement = startingNode;
            
            Node minNode = currentElement;

            while (currentElement != null)
            {
                if (currentElement.data <= minNode.data)
                {
                    minNode = currentElement;
                }
                currentElement = currentElement.next;
            }
            return minNode;
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

            for (Node currentElement = firstElement; currentElement.next != null; currentElement = currentElement.next)
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

            // return IsSortedAscending() ? SortingOrder.Ascending : IsSortedDescending() ? SortingOrder.Descendin : SortingOrder.Unsorted;

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

        public List Reverse()
        {
            List listSecond = new List();

            for (Node currentElemenet = firstElement; currentElemenet != null; currentElemenet = currentElemenet.next)
            {
                listSecond.AddElement(currentElemenet.data);
            }
            return listSecond;
        }

        public bool IsEqual(List list)
        {
            Node currentElement = firstElement;

            for (int i = 0; currentElement != null; i++)
            {
                if (currentElement.data != list.GetValueOfElement(i))
                {
                    return false;
                }
                currentElement = currentElement.next;
            }
            return true;
        }

        public bool IsEqual2(List list)
        {
            if (list  == null)
            {
                throw new ArgumentNullException("Argument null");
            }

            Node currentElement = this.firstElement;
            Node currentElemntList = list.firstElement;

            while (currentElement != null && currentElemntList != null)
            {
                if (currentElement.data != currentElemntList.data)
                {
                    return false;
                }
                currentElement = currentElement.next;
                currentElemntList = currentElemntList.next;
            }
            return (currentElement == null && currentElemntList == null);
        }

        public bool IsSemetricSecondWay()
        {
            List listSemetric = this.Reverse();
            if (listSemetric.IsEqual(this))
            {
                return true;
            }
            return false;
        }

        public bool IsSortedAscendingIfDeleteOneNode()
        {
            if (firstElement == null)
            {
                return true;
            }
            Node currentElement = firstElement;
            if (IsSortedAscending())
            {
                Console.WriteLine("Already sorted");
                return false;
            }
            for (int i = 0; currentElement.next != null; i++)
            {
                if (currentElement.data > currentElement.next.data)
                {
                    int elementValue = GetValueOfElement(i);
                    DeleteNElement(i);

                    if (IsSortedAscending())
                    {
                        Console.WriteLine("Need to delete element {0} with value {1}", i+1, elementValue);
                        return true;
                    }
                }
                currentElement = currentElement.next;
            }
            return false;
        }

        public int CountSpecificElement(int data)
        {
            int count = 0;
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                if (data == currentElement.data)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsPresentedInTheList(int data)
        {
            return IsPresentedInTheList(data, null);
        }

        private bool IsPresentedInTheList(int data, Node tail)
        {
            for (Node currentElement = firstElement; currentElement != tail; currentElement = currentElement.next)
            {
                if (data == currentElement.data)
                {
                    return true;
                }
            }
            return false;
        }

        public int DistinctElementsInTheList()
        {
            int count = 0;
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                if (CountSpecificElement(currentElement.data) == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public List UniqElementsInTheList()
        {
            List UniqList = new List();
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                if (UniqList.IsPresentedInTheList(currentElement.data) == false)
                {
                    UniqList.AddElement(currentElement.data);
                }
            }
            return UniqList;

        }

        public int DistinctElementsInTheListV2()
        {
            int count = 0;
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                if (!IsPresentedInTheList(currentElement.data, currentElement))
                {
                    count++;
                }
            }
            return count;
        }

        public int DistinctElementsInTheListV3()
        {
            Dictionary<int, bool> distinct = new Dictionary<int, bool>();
            int count = 0;
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                if (!distinct.ContainsKey(currentElement.data))
                {
                    count++;
                    distinct[currentElement.data] = true;
                }
            }
            return count;
        }

        public void SortList()
        {
            if (firstElement == null)
            {
                throw new IndexOutOfRangeException("No element to sort");
            }
            List newList = new List();

            for (int i = 0; !this.IsSortedAscending(); i++)    
            {
                int n = this.MaxElement();
                newList.AddElement(n);
                this.DeleteElementByValue(n);                
            }
            firstElement.next = newList.firstElement;
        }

        public void Swap(Node left, Node right)
        {
            int data = left.data;
            left.data = right.data;
            right.data = data;
        }

        public void SortListV2()
        {
            if (firstElement == null)
            {
                throw new ArgumentOutOfRangeException("No element in the list");
            }
            for (Node currentElement = firstElement; currentElement != null; currentElement = currentElement.next)
            {
                Node right = MinElementReturnNode(currentElement);
                Swap(currentElement, right);
            }
        }
    }
}