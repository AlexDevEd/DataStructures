using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.IListok
{
    public interface IList
    {
        int[] ReturnArray();

        void AddLast(int a);

        void AddLast(int[] a);

        void AddFirst(int a);

        void AddFirst(int[] a);

        void AddAtIndex(int index, int value);

        void ChangeValueAtIndex(int index, int value);

        void RemoveLast();

        void RemoveLast(int value);

        void RemoveFirst();

        void RemoveFirst(int value);

        void RemoveAtIndex(int index);

        void RemoveAtIndex(int index, int value);

        void RemoveAtValue(int value);

        int GetValueAtIndex(int index);

        int Contains(int value);

        void ReverseArray();

        int GetSize();

        int GetFirst();

        int GetLast();

        int SearchMaxValue();

        int SearchMinValue();

        int SearchMaxIndex();

        int SearchMinIndex();

        void BubbleSortAscending();

        void BubbleSortDescending();
        
    }
}

