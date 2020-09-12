using Lists;
using NUnit.Framework;
using Lists.IListok;
using Lists.LinkedList;
using Lists.DoubleLinkedList;
using System;

namespace ListsTests
{
    public class Tests
    {
        [TestFixture(1)]
        [TestFixture(2)]
        [TestFixture(3)]
        public class ListTest
        {
            IList list;
            int q;

            public ListTest(int _q)
            {
                q = _q;
            }

            [SetUp]
            public void ListSelect()
            {
                switch (q)
                {
                    case 1:
                        list = new ArrayList();
                        break;
                    case 2:
                        list = new LinkedList();
                        break;
                    case 3:
                        list = new DoubleLinkedList();
                        break;
                }
            }

            public void InitArray(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    list.AddLast(array[i]);
                }
            }

            [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, ExpectedResult = new int[] { 10, 20, 30, 40, 50, 60 })]
            [TestCase(new int[] { 0 }, ExpectedResult = new int[] { 0 })]
            [TestCase(new int[] { }, ExpectedResult = new int[] { })]
            public int[] ReturnArrayTest(int[] array)
            {
                InitArray(array);
                list.ReturnArray();
                return list.ReturnArray();
            }

            [TestCase(new int[] { 10, 20, 30 }, 40, ExpectedResult = new int[] { 10, 20, 30, 40 })]
            [TestCase(new int[] { }, 10, ExpectedResult = new int[] { 10 })]
            [TestCase(new int[] { }, null, ExpectedResult = new int[] { 0 })]
            public int[] AddLastTest(int[] array, int a)
            {
                InitArray(array);
                list.AddLast(a);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 10, 20, 30 }, new int[] { 40, 50 }, ExpectedResult = new int[] { 10, 20, 30, 40, 50 })]
            [TestCase(new int[] { }, new int[] { 40, 50 }, ExpectedResult = new int[] { 40, 50 })]
            [TestCase(new int[] { -50 }, new int[] { }, ExpectedResult = new int[] { -50 })]
            public int[] AddLastTest(int[] array, int[] a)
            {
                InitArray(array);
                list.AddLast(a);
                return list.ReturnArray();
            }


            [TestCase(new int[] { 10, 20, 30 }, 40, ExpectedResult = new int[] { 40, 10, 20, 30 })]
            [TestCase(new int[] { }, 10, ExpectedResult = new int[] { 10 })]
            [TestCase(new int[] { 0 }, 50, ExpectedResult = new int[] { 50, 0 })]            
            public int[] AddFirstTest(int[] array, int a)
            {
                InitArray(array);
                list.AddFirst(a);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 30, 40, 50, }, new int[] { 10, 20 }, ExpectedResult = new int[] { 10, 20, 30, 40, 50 })]
            [TestCase(new int[] { }, new int[] { 10, 20 }, ExpectedResult = new int[] { 10, 20 })]
            [TestCase(new int[] { 30, 40, 50 }, new int[] { }, ExpectedResult = new int[] { 30, 40, 50 })]
            [TestCase(new int[] { }, new int[] { }, ExpectedResult = new int[] { })]
            public int[] AddFirstTest(int[] array, int[] a)
            {
                InitArray(array);
                list.AddFirst(a);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 1, 2, 3 }, -2, 6, ExpectedResult = new int[] { 1, 2, 3 })]
            [TestCase(new int[] { }, 0, 0, ExpectedResult = new int[] { 0 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 0, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 0, 5 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 0, ExpectedResult = new int[] { 1, 2, 0, 3, 4, 5 })]
            [TestCase(new int[] { 1, 2, 3 }, 3, 5, ExpectedResult = new int[] { 1, 2, 3, 5 })]           
            public int[] AddAtIndexTest(int[] array, int i, int a)
            {
                InitArray(array);
                list.AddAtIndex(i, a);
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, ExpectedResult = new int[] { })]
            [TestCase(new int[] { -1, -3, 0 }, ExpectedResult = new int[] { -1, -3 })]
            [TestCase(new int[] { 1, 3, 4 }, ExpectedResult = new int[] { 1, 3 })]
            [TestCase(new int[] { 1 }, ExpectedResult = new int[] { })]
            public int[] RemoveLastTest(int[] array)
            {
                InitArray(array);
                list.RemoveLast();
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, 2, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 1 }, 0, ExpectedResult = new int[] { 1 })]
            [TestCase(new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = new int[] { 1 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 , 7 }, 3, ExpectedResult = new int[] { 1, 2, 3, 4 })]
            public int[] RemoveLastTest1(int[] array, int n)
            {
                InitArray(array);
                list.RemoveLast(n);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 8 }, ExpectedResult = new int[] { })]
            [TestCase(new int[] { }, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 33, 16, 350 }, ExpectedResult = new int[] { 16, 350 })]
            public int[] RemoveFirstTest(int[] array)
            {
                InitArray(array);
                list.RemoveFirst();
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, 3, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, ExpectedResult = new int[] { 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4 }, 8, ExpectedResult = new int[] { })]
            public int[] RemoveFirstTest1(int[] array, int n)
            {
                InitArray(array);
                list.RemoveFirst(n);
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, 20, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, ExpectedResult = new int[] { 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, ExpectedResult = new int[] { 1, 2, 3, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 9, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]           
            [TestCase(new int[] { 1 }, 0, ExpectedResult = new int[] { })]
            public int[] RemoveAtIndexTest(int[] array, int i)
            {
                InitArray(array);
                list.RemoveAtIndex(i);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 3, ExpectedResult = new int[] { 1, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { }, 0, 8, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 7, ExpectedResult = new int[] { 1, 2, 3 })]
            public int[] RemoveAtIndexTest(int[] array, int i, int n)
            {
                InitArray(array);
                list.RemoveAtIndex(i, n);
                return list.ReturnArray();
            }

            [TestCase(new int[] { 2, 3, 4, 5, 6 }, 1, ExpectedResult = new int[] { 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, ExpectedResult = new int[] { 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { }, null, ExpectedResult = new int[] { })]
            [TestCase(new int[] { 2, 3, 4, 5, 6 }, 6, ExpectedResult = new int[] { 2, 3, 4, 5})]
            public int[] RemoveAtValueTest(int[] array, int i)
            {
                InitArray(array);
                list.RemoveAtValue(i);
                return list.ReturnArray();
            }
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1)]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0 )]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 5 )]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 9)]
            [TestCase(new int[] { }, 5)]
            public void GetValueAtIndexTest(int[] array, int expected)
            {              
                try
                {
                    InitArray(array);
                    list.GetValueAtIndex(array[expected]);                   
                }
                catch
                {                   
                    if (array.Length < 0)
                    {
                        throw new IndexOutOfRangeException("-1");
                    }
                }            
            }
            [TestCase(new int[] { 1, 2, 2, 2, 2, 2 }, 2)]
            [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 5)]
            [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 7)]
            [TestCase(new int[] { }, 7)]
            [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 1)]
            [TestCase(new int[] { 1, 2, 3, 2, 5, 6 }, 6)]
            public void ContainsTest(int[] array, int i)
            {
                try
                {
                    InitArray(array);
                    list.Contains(array[i]);
                }
                catch
                {
                   if(i == 0)
                    throw new IndexOutOfRangeException("not found");                    
                }               
            }

            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = new int[] { 6, 5, 4, 3, 2, 1 })]
            [TestCase(new int[] { 1, -2, 3, 4, 5, -6 }, ExpectedResult = new int[] { -6, 5, 4, 3, -2, 1 })]
            [TestCase(new int[] { }, ExpectedResult = new int[] { })]           
            [TestCase(new int[] { 1, 2 }, ExpectedResult = new int[] { 2, 1 })]
            public int[] ReverseArrayTest(int[] array)
            {
                InitArray(array);
                list.ReverseArray();
                return list.ReturnArray();
            }

            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 47, ExpectedResult = new int[] { 1, 2, 47, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, -38, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -10, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -0, 0, ExpectedResult = new int[] { 0, 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { }, 5, 3, ExpectedResult = new int[] { })]
            [TestCase(new int[] { }, 0, 43, ExpectedResult = new int[] { })]
            public int[] ChangeValueAtIndexTest(int[] array, int i, int a)
            {
                InitArray(array);
                list.ChangeValueAtIndex(i, a);
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, ExpectedResult = 0)]
            [TestCase(new int[] { 0 }, ExpectedResult = 1)]
            [TestCase(new int[] { 0, 1 }, ExpectedResult = 2)]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 6)]
            public int GetSizeTest(int[] array)
            {
                InitArray(array);
                return list.GetSize();
            }

            [TestCase(new int[] { }, ExpectedResult = 0)]
            [TestCase(new int[] { 4 }, ExpectedResult = 4)]
            [TestCase(new int[] { 3, 2, 1, 7 }, ExpectedResult = 3)]
            [TestCase(new int[] { -45, 1, 2, 3, 4, -40 }, ExpectedResult = -45)]
            public int GetFirstTest(int[] array)
            {
                InitArray(array);
               return list.GetFirst();
     
            }

            [TestCase(new int[] { }, ExpectedResult = 0)]
            [TestCase(new int[] { 40 }, ExpectedResult = 40)]
            [TestCase(new int[] { 1, 2, 3, 7 }, ExpectedResult = 7)]
            [TestCase(new int[] { 54, 2, 5, 4, 3, -88 }, ExpectedResult = -88)]
            public int GetLastTest(int[] array)
            {
                InitArray(array);
                return list.GetLast();
            }

            [TestCase(new int[] { 1, 2, 3, 68, 5, 0 })]
            [TestCase(new int[] { 1, 2 })]
            [TestCase(new int[] { 1 })]
            [TestCase(new int[] { })]
            [TestCase(new int[] { 30, 2, -20, 80, 0, 5 })]           
            public void SearchMaxValueTest(int[] array)
            {               
                try
                { 
                    InitArray(array);
                    list.SearchMaxValue();
                }
                catch
                {
                    if (array.Length < 0)
                    {
                        throw new Exception("list is empty");
                    }
                }
            }

            [TestCase(new int[] { 1, 2, -3, 4, 5, 6, 0 })]
            [TestCase(new int[] { })]
            [TestCase(new int[] { 1, 2, 3, 4, 0, -40 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
            [TestCase(new int[] { 1, 2 })]
            [TestCase(new int[] { 1 })]

            public void SearchMinValueTest(int[] array)
            {
                try
                {
                    InitArray(array);
                    list.SearchMinValue();
                }
                catch
                {
                    if (array.Length < 0)
                    {
                        throw new Exception("list is empty");
                    }
                }
            }

            [TestCase(new int[] { 1, 2, -3, 4, 5, 6, 0 })]
            [TestCase(new int[] { })]
            [TestCase(new int[] { 1, 2 })]
            [TestCase(new int[] { 1 })]
            [TestCase(new int[] { 1, 2, 3, 4, 0, -40 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
            public void SearchMaxIndexTest(int[] array)
            {
                try
                {
                    InitArray(array);
                    list.SearchMaxIndex();
                }
                catch
                {
                    if (array.Length < 0)
                    {
                        throw new Exception("list is empty");
                    }
                }
            }
            [TestCase(new int[] { 1, 2, -3, 4, 5, 6, 0 })]
            [TestCase(new int[] { })]
            [TestCase(new int[] { 1, 2 })]
            [TestCase(new int[] { 1 })]
            [TestCase(new int[] { 1, 2, 3, 4, 0, -40 })]
            [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
            public void SearchMinIndexTest(int[] array)
            {
                try
                {
                    InitArray(array);
                    list.SearchMinIndex();
                }
                catch
                {
                    if (array.Length < 0)
                    {
                        throw new Exception("list is empty");
                    }
                }
            }

            [TestCase(new int[] { }, ExpectedResult = new int[] { })]
            [TestCase(new int[] { -6 }, ExpectedResult = new int[] { -6 })]
            [TestCase(new int[] { -1, -2, 3, 4, 5, 5, 0 }, ExpectedResult = new int[] { -2, -1, 0, 3, 4, 5, 5 })]
            public int[] BubbleSortAscendingTest(int[] array)
            {
                InitArray(array);
                list.BubbleSortAscending();
                return list.ReturnArray();
            }

            [TestCase(new int[] { }, ExpectedResult = new int[] { })]
            [TestCase(new int[] { -6 }, ExpectedResult = new int[] { -6 })]
            [TestCase(new int[] { -1, -2, 3, 4, 5, 5, 0 }, ExpectedResult = new int[] { 5, 5, 4, 3, 0, -1, -2 })]
            [TestCase(new int[] { -1, -3, -2, 7, 7, 5, 3 }, ExpectedResult = new int[] { 7, 7, 5, 3, -1, -2, -3 })]
            public int[] BubbleSortDescendingTest(int[] array)
            {
                InitArray(array);
                list.BubbleSortDescending();
                return list.ReturnArray();
            }
        }
    }
}
