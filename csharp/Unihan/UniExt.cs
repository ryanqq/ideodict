using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Unihan
{
	public static class UniExt
	{
		const char HiSurrGE = '\uD800', HiSurrLE = '\uDBFF';
		const char LoSurrGE = '\uDC00', LoSurrLE = '\uDFFF';


		#region code point

		public static CodePoint CodePointAt (this string s, int idx)
		{
			int sLen = s.Length;
			if (idx > sLen)
				throw new ArgumentOutOfRangeException ();
			unsafe
			{
				fixed (char* cp = s)
				{
					
					char c0 = *(cp + idx), c1;						
					if (c0 >= HiSurrGE && c0 <= HiSurrLE && sLen - idx > 1 &&
					    (c1 = *(cp + idx + 1)) >= LoSurrGE && c1 <= LoSurrLE)
					{
						
						
							return *(CodePoint*)(cp + idx);
					}
					return new CodePoint (c0);
					
				}
			}
			
		}
		

		public static IEnumerable<CodePoint> IterCodePoints<T> (this T s)
			where T: IEnumerable<char>
		{
			IEnumerator<char> e = s.GetEnumerator();
			while(e.MoveNext()){
				char c0 = e.Current;
				char c1 = '\0';
				if(c0 >= HiSurrGE && c0 <= HiSurrLE && e.MoveNext() &&
				   (c1 = e.Current) >=LoSurrGE && c1 <= LoSurrLE)
				{
					yield return new CodePoint(c0,c1);
				}
				else
				{
					yield return new CodePoint(c0);
					if(c1 != '\0')
						yield return new CodePoint(c1);
				}
			}
		}
		
		static string AsString(this IEnumerable<CodePoint> unicodes)
		{
			StringBuilder sb = new StringBuilder();
			foreach (CodePoint code in unicodes)
			{
				if(code.IsSurrogatePair)
					sb.Append(code.ToCharArray());
				else
					sb.Append(code.ToChar());
					
			}
			return sb.ToString();
		}
		
		#endregion
		
		#region unicode blocks
		
		public static IntSpan GetSpan(this UniBlock ub)
		{
			return Uni.SpanOf(ub);
		}
		
		#endregion
		
		
	}
}

