using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Lists.IListok;


namespace Lists.LinkedList
{
    public class LinkedList : IList
    {
        private Node head;

        public int length { get; private set; }
        public int count { get; set; }

        public LinkedList()
        {
            head = null;
            length = 0;
        }

        public LinkedList(int a)
        {
            head = new Node(a);
            length = 1;
        }

        private void ResetArray()
        {
            head = null;
            length = 0;
        }

        public int[] ReturnArray()
        {
            int[] array = new int[length];
            if (length != 0)
            {
                int i = 0;
                Node tmp = head;
                do
                {
                    array[i] = tmp.Value;
                    i++;
                    tmp = tmp.Next;
                } while (tmp != null);
            }
            return array;
        }

        public void AddLast(int a)
        {
            if (length == 0)
            {
                head = new Node(a);
                length = 1;
            }
            else if (length == 1) 
            { 
                head.Next = new Node(a);
                length++;
            }
            else
            {
                Node tmp = head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(a);
                length++;
            }
        }

        public void AddLast(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                AddLast(a[i]);
            }
        }

        public void AddFirst(int a)
        {
            Node tmp = new Node(a);
            tmp.Next = head;
            head = tmp;
            length++;
        }

        public void AddFirst(int[] a)
        {
            int i = a.Length - 1;
            while (i != -1)
            {
                AddFirst(a[i]);
                i--;
            }
        }

        public void AddAtIndex(int index, int value)
        {
            if (index == length)
            {
                AddLast(value);
            }
            else if ((length > 0) && (index < length) && (index >= 0))
            {
                Node tmp = head;
                if (index == 0)
                {
                    tmp = new Node(value);
                    tmp.Next = head;
                    head = tmp;
                }
                else
                if (index > 0)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        tmp = tmp.Next;
                    }
                    Node c = new Node(value);
                    c.Next = tmp.Next;
                    tmp.Next = c;
                }
                length++;
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                Node tmp = head;
                for (int i = 0; i < length; i++)
                {
                    if (i == index)
                    {
                        tmp.Value = value;
                    }
                    tmp = tmp.Next;
                }
            }
        }

        public void RemoveLast()
        {
            if (length > 0)
            {
                Node tmp = head;
                for (int i = 0; i < length - 2; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                length--;
            }
        }

        public void RemoveLast(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n <= length)
            {
                Node tmp = head;
                for (int i = 0; i < length - 1 - n; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                length = length - n;
            }
        }

        public void RemoveFirst()
        {
            if (length > 0)
            {
                Node tmp = head;
                tmp = tmp.Next;
                head = tmp;
                length--;
            }
        }

        public void RemoveFirst(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n >= 0)
            {
                Node tmp = head;
                for (int i = 0; i < n; i++)
                {
                    tmp = tmp.Next;
                }
                head = tmp;
                length = length - n;
            }
        }

        public void RemoveAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                if (index == 0)
                {
                    Node tmp = head;
                    tmp = tmp.Next;
                    head = tmp;
                    length--;
                }

                if (index > 0)
                {
                    Node tmp = head;
                    for (int i = 2; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    Node c = tmp.Next;
                    c = c.Next;
                    tmp.Next = c;
                    length--;
                }
            }
        }

        public void RemoveAtIndex(int index, int n)
        {
            while (n > 0)
            {
                RemoveAtIndex(index);
                n--;
            }
        }

        public void RemoveAtValue(int value)
        {
            Node tmp = head;
            for (int i = 0; i < length; i++)
            {
                if (tmp.Value == value)
                {
                    RemoveAtIndex(i);
                    i--;
                }
                tmp = tmp.Next;
            }
        }

        public int GetValueAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                int value = 0;
                Node tmp = head;
                for (int i = 0; i < length; i++)
                {
                    if (i == index)
                    {
                        value = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return value;
            }
            else throw new Exception("-1");
        }

        public int Contains(int value)
        {
            Node tmp = head;
            int b = 0;
            for (int i = 0; i < length; i++)
            {
                if (tmp.Value == value) { b += i; };
                tmp = tmp.Next;
            }
            if (b == 0)
            { throw new IndexOutOfRangeException("not found"); }
            return b;
        }

        public void ReverseArray()
        {
            if (length > 0)
            {
                Node current = head;
                Node prev = null;
                Node next;
                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }
                current.Next = prev;
                head = current;
            }
        }

        public int GetSize()
        {
            return length;
        }

        public int GetFirst()
        {
            if (length == 0)
            {
                return  0;
            }
            return head.Value;
        }

        public int GetLast()
        {
            if (length == 0)
            {
                return 0;
            }
            else
            {
                Node tmp = head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                    head = tmp;
                }
                return head.Value;
            }
        }

        public int SearchMaxValue()
        {
            if (length > 0)
            {
                Node tmp = head;
                int b = tmp.Value;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value >= b) { b = tmp.Value; };
                    tmp = tmp.Next;
                }
                return b;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMinValue()
        {
            if (length > 0)
            {
                Node tmp = head;
                int b = tmp.Value;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value <= b) { b = tmp.Value; };
                    tmp = tmp.Next;
                }
                return b;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMaxIndex()
        {
            if (length > 0)
            {
                Node tmp = head;
                int b = tmp.Value;
                int a = 0;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value > b) { b = tmp.Value; a = i; };
                    tmp = tmp.Next;
                }
                return a;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMinIndex()
        {
            if (length > 0)
            {
                Node tmp = head;
                int b = tmp.Value;
                int a = 0;
                for (int i = 0; i < length; i++)
                {
                    if (tmp.Value < b) { b = tmp.Value; a = i; };
                    tmp = tmp.Next;
                }
                return a;
            }
            else throw new Exception("list is empty");
        }

        public void BubbleSortAscending()
        {
            Node prev = null;
            Node minPrev = null;
            Node min = head;
            Node tmp = head;

            while (tmp != null)
            {
                if (min.Value > tmp.Value)
                {
                    min = tmp;
                    minPrev = prev;
                }
                prev = tmp;
                tmp = tmp.Next;
            }
            if (minPrev != null)
            {
                minPrev.Next = minPrev.Next.Next;
                min.Next = head;
                head = min;
            }

            Node place = head;

            for (int i = 1; i < length; i++)
            {
                prev = place;
                minPrev = place;
                min = place.Next;
                tmp = place.Next;

                while (tmp != null)
                {
                    if (min.Value > tmp.Value)
                    {
                        min = tmp;
                        minPrev = prev;
                    }
                    prev = tmp;
                    tmp = tmp.Next;
                }

                minPrev.Next = minPrev.Next.Next;
                min.Next = place.Next;
                place.Next = min;
                place = place.Next;
            }
        }
        public void BubbleSortDescending()
        {
            Node prev = null;
            Node minPrev = null;
            Node min = head;
            Node tmp = head;

            while (tmp != null)
            {
                if (min.Value < tmp.Value)
                {
                    min = tmp;
                    minPrev = prev;
                }
                prev = tmp;
                tmp = tmp.Next;
            }
            if (minPrev != null)
            {
                minPrev.Next = minPrev.Next.Next;
                min.Next = head;
                head = min;
            }

            Node place = head;

            for (int i = 1; i < length; i++)
            {
                prev = place;
                minPrev = place;
                min = place.Next;
                tmp = place.Next;

                while (tmp != null)
                {
                    if (min.Value < tmp.Value)
                    {
                        min = tmp;
                        minPrev = prev;
                    }
                    prev = tmp;
                    tmp = tmp.Next;
                }

                minPrev.Next = minPrev.Next.Next;
                min.Next = place.Next;
                place.Next = min;
                place = place.Next;
            }
        }  
    }
}
