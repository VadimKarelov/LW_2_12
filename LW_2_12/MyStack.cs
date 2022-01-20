using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_12
{
    internal class MyStack<T> : IEnumerable<T>
    {
        public int Count
        {
            get
            {
                int count = 0;
                if (_last != null)
                {
                    count++;
                    for (; _last.PreviousElement != null; count++) { }
                }
                return count;
            }
        }

        private Element<T>? _last;
        private bool _disposed = false;

        public MyStack()
        {
            _last = null;
        }

        public MyStack(int capacity)
        {
            if (capacity < 0) throw new Exception("Capacity can't be less than zero");

            for (int i = 0; i < capacity; i++)
            {
                this.Push(default(T));
            }
        }

        public MyStack(MyStack<T> collection)
        {
            // get elements from stack
            List<T> ts = new List<T>();
            while (collection.Count > 0)
            {
                ts.Add(collection.Remove());                
            }

            // copy to new (this stack)
            while (ts.Count > 0)
            {
                this.Push(ts[ts.Count - 1]);
                ts.RemoveAt(ts.Count - 1);
            }
        }

        public void Push(T value)
        {
            if (_last == null)
            {
                // if collection is empty, set value as last element
                _last = new Element<T>(value, null, null);
            }
            else
            {
                // create new element with reference to previous last element
                Element<T> newElement = new Element<T>(value, _last, null);
                // set reference to the new element
                _last.NextElement = newElement;
                // change last element
                _last = newElement;
            }
        }

        public void Push(T[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                this.Push(values[i]);
            }
        }

        public T Get()
        {
            if (_last != null)
                return _last.Value;
            else
                throw new Exception("Stack is empty");
        }

        public Element<T>? GetAsElement()
        {
            return _last;
        }

        public T Remove()
        {
            if (_last != null)
            {
                Element<T>? deletedElement = _last;
                _last = _last.PreviousElement;
                T? value = deletedElement.Value;
                deletedElement.Dispose();
                return value;
            }
            else
                throw new Exception("Stack is empty");
        }

        public void Remove(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Remove();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            if (this.Count > 0 && value != null)
            {
                foreach (T item in this)
                {
                    if (item != null && item.Equals(value))
                        return true;
                }
            }
            return false;
        }

        public MyStack<T> Clone()
        {
            return new MyStack<T>(this);
        }

        public MyStack<T> ShallowCopy()
        {
            MyStack<T> res = new MyStack<T>();
            res._last = _last;
            return res;
        }

        // ========= Очистка ресурсов =========
        public void Dispose()
        {
            if (!_disposed)
            {
                Remove(this.Count);
                _disposed = true;
            }            
        }
    }

    class Element<T> : IDisposable
    {
        public T Value;

        public Element<T>? NextElement;
        public Element<T>? PreviousElement;

        private bool _disposed = false;

        public Element(T value, Element<T>? prev, Element<T>? next)
        {
            Value = value;
            NextElement = next;
            PreviousElement = prev;
        }

        // ========= Очистка ресурсов =========
        public void Dispose()
        {
            if (!_disposed)
            {
                NextElement = null;
                PreviousElement = null;
                Value = default;

                _disposed = true;
            }
        }
    }

    class MyEnumerator<T> : IEnumerator<T>
    {
        Element<T>? _begin;
        Element<T>? _current;

        public MyEnumerator(MyStack<T> stack)
        {
            _begin = stack.GetAsElement();
            _current = _begin;
        }

        public object Current { get { return _current; } }

        T IEnumerator<T>.Current
        {
            get
            {
                if (_current != null)
                {
                    return _current.Value;
                }
                else
                {
                    return default;
                }
            }
        }

        public bool MoveNext()
        {
            if (_current != null && _current.PreviousElement != null)
            {
                _current = _current.PreviousElement;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _current = _begin;
        }

        public void Dispose() 
        {
            _current = null;
            _begin = null;
        }
    }
}