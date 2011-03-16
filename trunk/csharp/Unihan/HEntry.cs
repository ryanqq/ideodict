using System;
namespace Unihan
{
	public struct HEntry<T> where T : struct,IHanIndex<T>,IEquatable<T>
	{
		public T Index;
		public string Glyphs;
		public static bool operator true(HEntry<T> ent)
		{
			return !ent.Index.Equals(default(T)) && ent.Glyphs != null;
		}
		
		public static bool operator false(HEntry<T> ent)
		{
			return ent.Index.Equals(default(T)) && ent.Glyphs == null;
		}
		
		public static bool operator !(HEntry<T> ent)
		{
			return ent? false: true;
		}
		
	}
	
	public static class HEntry
	{
		public static HEntry<T> New<T>(T idx, string glyphs) 
			where T:struct,IHanIndex<T>,IEquatable<T>
		{
			return	new HEntry<T>{ Index = idx,Glyphs = glyphs};
		}
	}
}

