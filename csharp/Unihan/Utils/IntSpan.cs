using System;
namespace Unihan
{
	public struct IntSpan
	{
		
		public int From, ToInclusive;		
		public IntSpan(int from, int toInclusive)
		{
			From = from; ToInclusive = toInclusive;
		}
		public bool Covered(int i)
		{
			return From <= i && ToInclusive >= i;
		}
		
	}
}

