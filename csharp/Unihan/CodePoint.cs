using System;
using System.Text;
using System.Runtime.InteropServices;
namespace Unihan
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CodePoint
	{
		#region constants


		const char HiSurrGE = '\uD800', HiSurrLE = '\uDBFF', LoSurrGE = '\uDC00', LoSurrLE = '\uDFFF';

		//const uint HiMask = 0xFFFF0000u, LoMask = 0x0000FFFFu;

		#endregion

		#region fields

		char _hi;
		char _lo;

		#endregion

		#region ctor
		public CodePoint (char hi, char lo)
		{
			_hi = hi;
			_lo = lo;
		}

		public CodePoint (char ch) : this('\0', ch)
		{
			
		}

		#endregion


		public bool IsSurrogatePair
		{
			get { return _hi != 0; }
		}

		/// <summary>
		/// unicode scalar value
		/// </summary>
		public int Scalar
		{
			get { return IsSurrogatePair ? 0x10000 + ((_hi - HiSurrGE) << 10) + (_lo - LoSurrGE) : (int)_lo; }
		}


		public static CodePoint FromScalar (int scalar)
		{
			if(scalar < 0 || Uni.BlockOf(scalar) == UniBlock.Undefined)
				throw new ArgumentOutOfRangeException("Invalid Unicode scalar value");
			if (scalar < 0x10000)
				return new CodePoint ((char)scalar);
			
			scalar -= 0x10000;
			CodePoint codePoint = new CodePoint ();
			codePoint._hi = (char)((scalar >> 10) + HiSurrGE);
			codePoint._lo = (char)((scalar & 0x00003ff) + LoSurrGE);
			return codePoint;
		}

		#region conversion
		public static implicit operator string (CodePoint c)
		{
			return new string (c.ToCharArray ());
		}
		
		public char ToChar()
		{
			if(IsSurrogatePair)
				throw new NotSupportedException("Can't convert a surrogate pair to char, use ToCharArray instead!");
			return _lo;
				
		}

		public char[] ToCharArray ()
		{
			return IsSurrogatePair ? new char[] { _hi, _lo } : new char[] { _lo };
			
		}

		public static CodePoint Parse (string scalar)
		{
			if (scalar == null)
				throw new ArgumentNullException (scalar);
			
			scalar = scalar.Trim ().ToUpper ().Replace ("U+", "");
			
			if (scalar == string.Empty)
				throw new FormatException ("invalid scalar format");
			
			return FromScalar (Convert.ToInt32 (scalar, 16));
		}
//		
//		public static bool TryParse(string scalar, out CodePoint c)
//		{
//			
//			try{
//				c = Parse(scalar);
//				return true;
//			}
//			catch(Exception e){
//				c = 
//				return false;
//			}
//		}

		#endregion

		public int CharCount
		{
			get { return IsSurrogatePair ? 2 : 1; }
		}


		public override string ToString ()
		{
			return IsSurrogatePair ? new string (new char[] { _hi, _lo }) : _lo.ToString ();
		}
	}
}

