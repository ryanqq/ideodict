using System;
using System.Collections.Generic;
using System.Linq;
namespace Unihan
{
	public interface IHanIndex<T>  where T : struct, IHanIndex<T> ,IEquatable<T>
	{
		HEntryList<T> Table{get;}
	}
	
	static public class HanIndexExtension
	{
		static public List<CodePoint> GetHanziList<T>(this T idx) 
			where T:struct,IHanIndex<T>,IEquatable<T>
		{
			return idx.Table[idx];
		}
	}
}

