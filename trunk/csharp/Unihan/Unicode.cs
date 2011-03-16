#if COMPILE
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
namespace Unihan
{
	[StructLayout(LayoutKind.Explicit,Pack = 2)]
	public struct Unicode: 
		IEnumerable<CodePoint>,IEnumerable<char>,IEnumerable
	{
		[FieldOffset(0)]string _str;
		[FieldOffset(0)]char[] _chs;
		[FieldOffset(4)]bool _isStr;
		public Unicode(string str)
		{
			_isStr = true;
			_chs = null;
			_str = str;
		}
		public Unicode(char[] chs)
		{
			_isStr = false;
			_str = null;
			_chs = chs;
		}
		
		public static implicit operator Unicode(string str)
		{
			return new Unicode(str);
		}
		
		public static implicit operator string(Unicode uni)
		{
			return uni._isStr? uni._str: new string( uni._chs);
		}

		public static implicit operator Unicode(char[] chs)
		{
			return new Unicode(chs);
		}
		
		public static implicit operator char[](Unicode uni)
		{
			return uni._isStr? uni._str.ToCharArray(): uni._chs;
			
		}
		
		

		#region IEnumerable[CodePoint] implementation
		public IEnumerator<CodePoint> GetEnumerator ()
		{
			
		}
		#endregion


		#region IEnumerable[System.Char] implementation
		IEnumerator<char> IEnumerable<char>.GetEnumerator ()
		{
			IEnumerable<char> e = _isStr? _str: _chs;
			return e.GetEnumerator();
		}
		#endregion


		#region IEnumerable implementation
		IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}
		#endregion

}
}

#endif