using System.Collections;

namespace Ipr.Linq
{
    public unsafe class MyEnumerator<T> : IEnumerator<T>
    {
        private MyLinkedArray<T> _array;

        private int _index = -1;

        public MyEnumerator(MyLinkedArray<T> array)
        {
            _array = array;
        }

        public T Current => _array[_index];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public bool MoveNext()
        {
            if(_index >= _array.Count())
            {
                return false;
            }
            else
            {
                _index++;  
            }
            
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}