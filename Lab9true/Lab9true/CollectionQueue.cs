﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab9true
{
    internal class CollectionQueue : IOrderedDictionary
    {
        private Queue _queue;
        public override string ToString()
        {
            return base.ToString();
        }
        public CollectionQueue()
        {
         _queue = new Queue();
        }
        public void AddElement(object key, object value) // добавление элемента в коллекцию
        {
            _queue.Enqueue(value);
        }
        public int IndexOfKey(object key)
        {
            int n = -1;
            foreach (var el in _queue)
            {

                if (el is Services != false)
                {
                    n++;
                    var c = el as Services;
                    if (c.title == (string)key)
                    {
                        return n;
                    }
                }
                else break;

             }

            for (var i = 0; i < _queue.Count; i++)
            {
                if (((DictionaryEntry)_queue.ToArray()[i]).Key == key)
                    return i;
            }
       
            // key not found, return -1.
            return -1;
        }


       public object? this[int index] {
            get
            {
                
                foreach (var el in _queue)
                {
                    if (el is Services != false)
                    {
                        var arr = _queue.ToArray();
                       return arr.ElementAt(index);

                    }
                    else break;

                }

                return ((DictionaryEntry)_queue.ToArray()[index]).Value;
            }
            set
            {
                var key = ((DictionaryEntry)_queue.ToArray().ElementAt(index)).Key;
                var arr = _queue.ToArray().ToList();
                arr[index] = new DictionaryEntry(key,value);
            }
        }
       public  object? this[object key]
        {
            get => ((DictionaryEntry)_queue.ToArray().ToList()[IndexOfKey(key)]).Value;
            set => _queue.ToArray().ToList()[IndexOfKey(key)] = new DictionaryEntry(key, value);
        }

       public  bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection Keys {

            get
            {
                var KeyCollection = new Queue(_queue.Count);
                foreach (var t in _queue)
                {
                    KeyCollection.Enqueue(((DictionaryEntry)t).Key);
                }

                return KeyCollection;
            }
        }

        public ICollection Values
        {

            get
            {
                var ValueCollection = new Queue(_queue.Count);
                foreach (var t in _queue)
                {
                    ValueCollection.Enqueue(((DictionaryEntry)t).Value);
                }
                return ValueCollection;
            }

        }

        public int Count => _queue.Count;

        public bool IsSynchronized => _queue.IsSynchronized;

       public object SyncRoot => _queue.SyncRoot;

        public void Add(object key, object? value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            _queue.Enqueue(new DictionaryEntry(key, value));
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public bool Contains(object key)
        {
           return IndexOfKey(key) != -1;  
        }

        public void CopyTo(Array array, int index)
        {
            _queue.CopyTo(array, index);
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return new ServicesEnum(_queue);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ServicesEnum(_queue);
        }

        public void Insert(int index, object key, object? value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            var arr = _queue.ToArray().ToList();
            arr.Insert(index, new DictionaryEntry(key, value));
            Queue _q3 = new Queue(arr);
            _queue = _q3;
        }

        public void Remove(object key)
        {
            var arr = _queue.ToArray().ToList();
            arr.RemoveAt(IndexOfKey(key));
            Queue _q2 = new Queue(arr);
            _queue = _q2;
        }

        public void RemoveAt(int index)
        {
            var arr = _queue.ToArray().ToList();
            arr.RemoveAt(index);
            Queue _q1 = new Queue(arr);
            _queue = _q1;
        }

    }

    public class ServicesEnum : IDictionaryEnumerator
    {
        public Queue _queue;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        private int position = -1;

        public ServicesEnum(Queue queue)
        {
            _queue = queue;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _queue.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _queue.ToArray().ToList().ElementAt(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public DictionaryEntry Entry => (DictionaryEntry)Current;

        public object Key
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_queue.ToArray().ToList().ElementAt(position)).Key;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public object Value
        {
            get
            {
                try
                {
                    return ((DictionaryEntry)_queue.ToArray().ToList().ElementAt(position)).Value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
