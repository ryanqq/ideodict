using System;
using System.Collections.Generic;
using System.Collections;
namespace Unihan
{
	public class BiDictionary<T1,T2>
		:IDictionary<T1,T2>,
		ICollection<KeyValuePair<T1,T2>>,
		IEnumerable<KeyValuePair<T1,T2>> //,IDictionary<T2,T1>
	{
		IDictionary<T1,T2> _leftDict = new Dictionary<T1,T2>();
		IDictionary<T2,T1> _rightDict = new Dictionary<T2,T1>();
		public BiDictionary ()
		{
		}
	

		#region IDictionary[T1,T2] implementation
		public void Add (T1 key, T2 value)
		{
			_leftDict.Add(key,value);
			_rightDict.Add(value,key);
		}

		public bool ContainsKey (T1 key)
		{
			return _leftDict.ContainsKey(key);
		}

		public bool Remove (T1 key)
		{
			T2 value;
			bool hasKey = _leftDict.TryGetValue(key,out value);
			return hasKey
				?_rightDict.Remove(_leftDict[key]) && _leftDict.Remove(key)
				:false;			
		}

		public bool TryGetValue (T1 key, out T2 value)
		{
			return _leftDict.TryGetValue(key,out value);
		}

		public T2 this[T1 key] {
			get {
				return _leftDict[key];
			}
			set {
				_leftDict[key] = value;
				_rightDict[value] = key;
			}
		}

		public ICollection<T1> Keys {
			get {
				return _leftDict.Keys;
			}
		}

		public ICollection<T2> Values {
			get {
				return _leftDict.Values;
			}
		}
		#endregion
		
		#region ICollection[KeyValuePair[T1,T2]] implementation
		public void Add (KeyValuePair<T1, T2> item)
		{
			_leftDict.Add(item);
			_rightDict.Add(new KeyValuePair<T2,T1>(item.Value,item.Key));
		}

		public void Clear ()
		{
			_leftDict.Clear();
			_rightDict.Clear();
		}

		public bool Contains (KeyValuePair<T1, T2> item)
		{
			return _leftDict.Contains(item);
		}

		public void CopyTo (KeyValuePair<T1, T2>[] array, int arrayIndex)
		{
			_leftDict.CopyTo(array,arrayIndex);
		}

		public bool Remove (KeyValuePair<T1, T2> item)
		{
			return	_leftDict.Remove(item);
		}

		public int Count {
			get {
				return _leftDict.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return _leftDict.IsReadOnly;
			}
		}
		#endregion	
		#region IDictionary[T2,T1] implementation
		public void Add (T2 key, T1 value)
		{
			Add(value,key);
			
		}

		public bool ContainsKey (T2 key)
		{
			return _rightDict.ContainsKey(key);
		}

		public bool Remove (T2 key)
		{
			T1 value;
			bool hasKey = _rightDict.TryGetValue(key,out value);
			return hasKey
				?_leftDict.Remove(value) && _rightDict.Remove(key)
				:false;
		}

		public bool TryGetValue (T2 key, out T1 value)
		{
			return _rightDict.TryGetValue(key, out value);
		}

		public T1 this[T2 key] {
			get {
				return _rightDict[key];
			}
			set {
				_rightDict[key] = value;
				_leftDict[value] = key;
			}
		}	
		
		#endregion
		#region IEnumerable implementation
		public  IEnumerator<KeyValuePair<T1,T2>> GetEnumerator(){
			return _leftDict.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator(){
			return GetEnumerator();
		}
		#endregion

}
}

