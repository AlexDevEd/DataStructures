using System;
using System.Collections.Generic;
using System.Text;
using Lists.IListok;

namespace Lists
{
    public class ArrayList : IList
    {
        private int[] array;
        private int length;

        public int this[int a]
        {
            get { return array[a]; }
            set { array[a] = value; }
        }
        public int[] ReturnArray()
        {
            int[] arrayToReturn = new int[length];
            for (int i = 0; i < length; i++)
            {
                arrayToReturn[i] = array[i];
            }

            return arrayToReturn;
        }

        public ArrayList()
        {
            array = new int[0];
            length = 0;
        }

        public ArrayList(int a)
        {
            array = new int[1] { a };
            length = 1;
        }

        public ArrayList(int[] a)
        {
            array = a;
            length = a.Length;
        }

        private void UpArraySize()
        {
            int newL = Convert.ToInt32(array.Length + 1);
            int[] newArray = new int[newL];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        private void DownArraySize()
        {
            int newL = Convert.ToInt32(array.Length - 1);
            int[] newArray = new int[newL];

            for (int i = 0; i < array.Length - 1; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }
       
        public void AddLast(int a)
        {
            if (length >= array.Length)
            {
                UpArraySize();
            }

            array[length] = a;
            length++;
        }

        public void AddLast(int[] a)
        {
            while (length + a.Length > array.Length)
            {
                UpArraySize();
            }

            for (int i = 0; i < a.Length; i++)
            {
                array[length + i] = a[i];
            }

            length += a.Length;
        }

        public void AddFirst(int a)
        {   
            length++;
            int[] newArray = new int[length];
            for (int i = 0; i < length -1 ; i++)
            {
                newArray[i + 1] = array[i];                
            }
            array = newArray;
            array[0] = a;
  
        }

        public void AddFirst(int[] a)
        {           
            length += a.Length;
            int[] newArray = new int[length];
            for (int i = 0; i < length - a.Length; i++)
            {
                newArray[i + a.Length] = array[i];
            }
            array = newArray;

            for (int i = 0; i < a.Length; i++)
            {
                array[i] = a[i];
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
                if (length >= array.Length)
                {
                    UpArraySize();
                }
                int[] newArray = new int[length + 1];
                for (int i = 0; i < length; i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = index; i < length; i++)
                {
                    newArray[i + 1] = array[i];
                }
                newArray[index] = value;
                array = newArray;
                length++;
            }
        }

        public void ChangeValueAtIndex(int index, int value)
        {
            if ((length > 0) && (index < length) && (index >= 0))
                array[index] = value;
        }

        public void RemoveLast()
        {
            if (length > 0)
            {
                DownArraySize();
                length--;
            }
        }

        public void RemoveLast(int n)
        {
            while (n != 0)
            {
                RemoveLast();
                n--;
            }
        }

        public void RemoveFirst()
        {
            if (length > 0)
            {
                int[] newArray = new int[length];
                for (int i = 0; i < length - 1; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;

                DownArraySize();
                length--;
            }
        }

        public void RemoveFirst(int n)
        {
            while (n != 0)
            {
                RemoveFirst();
                n--;
            }
        }

        public void RemoveAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                int[] newArray = new int[length];
                newArray = array;
                for (int i = index; i < length - 1; i++)
                {
                    newArray[i] = array[i + 1];
                }
                array = newArray;

                DownArraySize();
                length--;
            }
        }

        public void RemoveAtIndex(int index, int n)
        {
            while (n != 0)
            {
                RemoveAtIndex(index);
                n--;
            }
        }

        public void RemoveAtValue(int value)
        {
            for (int i = 0; i < length; i++)
            {
                if (array[i] == value)
                {
                    RemoveAtIndex(i);
                    i--;
                }
            }
        }

        public int GetValueAtIndex(int index)
        {
            if ((length > 0) && (index < length) && (index >= 0))
            {
                return array[index];
                
            }
            else throw new IndexOutOfRangeException();
        }

        public int Contains(int value)
        {
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                if (array[i] == value)
                { result += i; }
               
            }
            if (result == 0)
            {
                throw new IndexOutOfRangeException("not found");
            }
            return result;          
        }

        public void ReverseArray()
        {
            for (int i = 0, j = array.Length - 1; i < j; i++, j--)
            {
                int tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
            }
        }

        public int GetSize()
        {
            
            return array.Length;
        }

        public int GetFirst()
        {
            if (length == 0)
            {
                return 0;
            }
           return array[0];           
        }

        public int GetLast()
        {           
            if (length == 0)
            {
                return 0;
            }
            else
            {
             return array[length - 1];
            }
        }

        public int SearchMaxValue()
        {
            if (length > 0)
            {
                int a = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (a < array[i])
                    {
                        a = array[i];
                    }
                }
                return a;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMinValue()
        {
            if (length > 0)
            {
                int a = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (a > array[i])
                    {
                        a = array[i];
                    }
                }
                return a;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMaxIndex()
        {
            if (length > 0)
            {
                int a = array[0];
                int b = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (a < array[i])
                    {
                        a = array[i];
                        b = i;
                    }
                }
                return b;
            }
            else throw new Exception("list is empty");
        }

        public int SearchMinIndex()
        {
            if (length > 0)
            {
                int a = array[0];
                int b = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (a > array[i])
                    {
                        a = array[i];
                        b = i;
                    }
                }
                return b;
            }
            else throw new Exception("list is empty");
        }

        public void BubbleSortAscending()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }


        public void BubbleSortDescending()
        {
            for (int i = 0; i < array.Length -1; i++)
            {
                int minIndex = i;
                for (int j = i ; j < array.Length; j++)
                {
                    if (array[j] > array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }


    }
}



