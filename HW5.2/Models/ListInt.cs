using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW5._2.Models
{
    internal class ListInt
    {
        private int[] _array;
        public int Length { 
            get
            {
                return _array.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public ListInt()
        {
            _array= new int[0];
        }
        public ListInt(int length)
        {
            _array = new int[length];
        }

        public ListInt(params int[] arr)
        {
            _array = arr;
        }

        public void Add(int value)
        {
            Array.Resize(ref _array, _array.Length+1);
            _array[^1] = value;
        }

        public void AddRange(params int[] values)
        {
            int start = _array.Length;
            Array.Resize(ref _array,_array.Length+values.Length);
            for (int i = start,j=0; i < _array.Length; i++)
            {
                _array[i] = values[j++];
            }
        }

        public bool Contains(int value)
        {
            foreach (int num in _array)
            {
                if(num==value)
                    return true;
            }

            return false;
        }

        public int Sum()
        {
            int sum = 0;
            foreach (int num in _array)
            {
                sum+= num;
            }

            return sum;
        }

        public void Remove(int num)
        {
            int index = Array.IndexOf(_array, num);

            if (index >= 0)
            {
                for (int i = index; i < _array.Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Array.Resize(ref _array, _array.Length - 1);
            }
        }

        public void RemoveRange(params int[] values)
        {
            int length = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                bool shouldRemove = false;
                for (int j = 0; j < values.Length; j++)
                {
                    if (_array[i] == values[j])
                    {
                        shouldRemove = true;
                        break; 
                    }
                }
                if (!shouldRemove)
                {
                    length++;
                }
            }
            int[] temp = new int[length];
            int k = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                bool shouldRemove = false;

                for (int j = 0; j < values.Length; j++)
                {
                    if (_array[i] == values[j])
                    {
                        shouldRemove = true;
                        break;
                    }
                }
                if (!shouldRemove)
                {
                    temp[k++] = _array[i];
                }
            }
            _array = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(_array[0].ToString());
            for (int i = 1; i < _array.Length; i++)
            {
                sb.Append(","+_array[i].ToString());
            }

            return sb.ToString();
        }
    }
}
