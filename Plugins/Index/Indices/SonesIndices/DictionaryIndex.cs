﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace sones.Plugins.Index
{
    public sealed class DictionaryIndex<TKey, TValue> : IIndex<TKey, TValue>
        where TKey : IComparable
    {
        #region IIndex Members

        public bool IsPersistent
        {
            get { return false; }
        }

        public string Name
        {
            get { return "Dictionary"; }
        }

        #region Add

        public void Add(TKey myKey, TValue myValue, IndexAddStrategy myIndexAddStrategy = IndexAddStrategy.UNIQUE)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> myKeyValuePair, IndexAddStrategy myIndexAddStrategy = IndexAddStrategy.UNIQUE)
        {
            throw new NotImplementedException();
        }

        public void Add(Dictionary<TKey, TValue> myDictionary, IndexAddStrategy myIndexAddStrategy = IndexAddStrategy.UNIQUE)
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey myKey]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Contains

        public bool ContainsKey(TKey myKey)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(TValue myValue)
        {
            throw new NotImplementedException();
        }

        public bool Contains(TKey myKey, TValue myValue)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Remove

        public bool Remove(TKey myKey)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Clear

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Keys

        public IEnumerable<TKey> Keys
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region Values

        public IEnumerable<TValue> GetValues()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Counts

        public long KeyCount
        {
            get { throw new NotImplementedException(); }
        }

        public long GetValueCount()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region IEnumerable<TValue> Members

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}