using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Lists.IListok;

namespace Lists.DoubleLinkedList
{
    public class DoubleLinkedList : IList
    {
        private Node head;
        private Node tail;
        public int length { get; private set; }

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public DoubleLinkedList(int a)
        {
            head = new Node(a);
            tail = head;
            length = 1;
        }

        private void ShiftNodes(Node a, Node b)
        {
            if (a == head && b != tail)
            {
                a.Next = b.Next;
                b.Next.Prev = a;
                a.Prev = b;
                b.Next = a;
                b.Prev = null;
                head = b;

            }
            else if (a == head && b == tail)
            {
                a.Next = null;
                b.Next = a;
                a.Prev = b;
                b.Prev = null;
                head = b;
                tail = a;
            }
            else if (a != head && b == tail)
            {
                a.Next = null;
                b.Prev = a.Prev;
                a.Prev.Next = b;
                b.Next = a;
                a.Prev = b;
                tail = a;
            }
            else
            {
                a.Prev.Next = b;
                b.Next.Prev = a;
                a.Next = b.Next;
                b.Next = a;
                b.Prev = a.Prev;
                a.Prev = b;
            }
        }

        private void ResetArray()
        {
            head = null;
            tail = null;
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
                tail = head;
                length = 1;
            }
            else
            {
                tail.Next = new Node(a);
                tail.Next.Prev = tail;
                tail = tail.Next;
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
            if (length == 0)
            {
                head = new Node(a);
                tail = head;
                length = 1;
            }
            else
            {
                head.Prev = new Node(a);
                head.Prev.Next = head;
                head = head.Prev;
                length++;
            }
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
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if ((length > 0) && (index < length) && (index > 0))
            {
                if (index <= (length / 2))
                {
                    Node tmp = head;
                    int i = 0;
                    while (i <= length / 2)
                    {
                        if (i == index)
                        {
                            Node tmp2 = tmp.Prev;
                            tmp2.Next = new Node(value);
                            tmp2.Next.Next = tmp;
                            tmp2.Next.Prev = tmp2;
                            tmp.Prev = tmp2.Next;
                            length++;
                            break;
                        }
                        tmp = tmp.Next;
                        i++;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = tail;
                    int i = length - 1;
                    while (i >= length / 2)
                    {
                        if (i == index)
                        {
                            Node tmp2 = tmp.Prev;
                            tmp2.Next = new Node(value);
                            tmp2.Next.Next = tmp;
                            tmp2.Next.Prev = tmp2;
                            tmp.Prev = tmp2.Next;
                            length++;
                            break;
                        }
                        tmp = tmp.Prev;
                        i--;
                    }
                }
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                if (index <= (length / 2))
                {
                    Node tmp = head;
                    for (int i = 0; i < length / 2; i++)
                    {
                        if (i == index)
                        {
                            tmp.Value = value;
                        }
                        tmp = tmp.Next;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = tail;
                    for (int i = length - 1; i >= length / 2; i--)
                    {
                        if (i == index)
                        {
                            tmp.Value = value;
                        }
                        tmp = tmp.Prev;
                    }
                }
            }
        }

        public void RemoveLast()
        {
            if (length == 1)
            {
                tail = head;
                length--;
            }           
            else if (length > 0)
            {
                tail = tail.Prev;
                tail.Next = null;
                length--;
            }         
        }

        public void RemoveLast(int n)
        {
            if (n >= length)
            {
                ResetArray();
            }
            else if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    RemoveLast();
                }
            }
        }

        public void RemoveFirst()
        {
            if (length <= 1)
            {
                ResetArray();
            }
            else if (length > 1)
            {
                head = head.Next;
                head.Prev = null;
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
                for (int i = 0; i < n; i++)
                {
                    RemoveFirst();
                }
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (length <= 1)
            {
                ResetArray();
            }
            else if (index >= 0)
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else if (index == length - 1)
                {
                    RemoveLast();
                }
                else
                {
                    if (index <= (length / 2))
                    {
                        Node tmp = head;
                        int i = 0;
                        while (i <= length / 2)
                        {
                            if (i == index)
                            {
                                tmp.Next.Prev = tmp.Prev;
                                tmp.Prev.Next = tmp.Next;
                                length--;
                                break;
                            }
                            tmp = tmp.Next;
                            i++;
                        }
                    }
                    else if (index >= (length / 2))
                    {
                        Node tmp = tail;
                        int i = length - 1;
                        while (i >= length / 2)
                        {
                            if (i == index)
                            {
                                tmp.Next.Prev = tmp.Prev;
                                tmp.Prev.Next = tmp.Next;
                                length--;
                                break;
                            }
                            tmp = tmp.Prev;
                            i--;
                        }
                    }
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
                if (index <= (length / 2))
                {
                    Node tmp = head;
                    int i = 0;
                    while (i <= length / 2)
                    {
                        if (i == index)
                        {
                            value = tmp.Value;
                            break;
                        }
                        tmp = tmp.Next;
                        i++;
                    }
                }
                else if (index >= (length / 2))
                {
                    Node tmp = tail;
                    int i = length - 1;
                    while (i >= length / 2)
                    {
                        if (i == index)
                        {
                            value = tmp.Value;
                            break;
                        }
                        tmp = tmp.Prev;
                        i--;
                    }
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
                Node tmp = head;
                Node tmp2 ;
                tmp.Prev = tmp.Next;
                tmp.Next = null;
                tmp = tmp.Prev;
                while (tmp != tail)
                {
                    tmp2 = tmp.Next;
                    tmp.Next = tmp.Prev;
                    tmp.Prev = tmp2;
                    tmp = tmp.Prev;
                }
                tmp.Next = tmp.Prev;
                tmp.Prev = null;
                tmp2 = tail;
                tail = head;
                head = tmp2;
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
                return 0;
            }
            else
            {
                return head.Value;
            }
            
        }

        public int GetLast()
        {
            if (length == 0)
            {
                return 0;
            }
            else
            {
                Node tmp = tail;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                    tail = tmp;
                }
                return tail.Value;
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
            if (length > 0)
            {
                for (var i = 1; i < length; i++)
                {
                    Node current = head;
                    for (int j = 0; j < i; j++)
                    {
                        current = current.Next;
                    }

                    Node prev = current.Prev;
                    while (prev.Value > current.Value)
                    {
                        ShiftNodes(prev, current);
                        if (current == head)
                        {
                            break;
                        }

                        prev = current.Prev;
                    }
                }
            }
        }
      
        public void BubbleSortDescending()
        {
            for (var i = 1; i < length; i++)
            {
                if (length > 0)
                {
                    Node current = head;
                    for (int j = 0; j < i; j++)
                    {
                        current = current.Next;
                    }

                    Node prev = current.Prev;
                    while (prev.Value < current.Value)
                    {
                        ShiftNodes(prev, current);
                        if (current == head)
                        {
                            break;
                        }

                        prev = current.Prev;
                    }
                }
            }
        }  
    }
 }
