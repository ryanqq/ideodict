using System;
using System.Collections.Generic;
using System.Linq;
namespace Unihan
{
	public class HEntryList<T> : List<HEntry<T>> where T : struct, IHanIndex<T>, IEquatable<T>
	{
		public HEntryList () : base()
		{
		}

		public List<CodePoint> this[T idx]
		{
			get
			{
				var found = base.Find (ent => ent.Index.Equals (idx));
				if (!found)
					throw new IndexOutOfRangeException ();
				return found.Glyphs.IterCodePoints ().ToList ();
			}
		}

		public List<T> this[CodePoint code]
		{
						
			get 
			{
				Predicate<T> pred;
				if(code.IsSurrogatePair)
					pred = ent=> ent.Glyphs.Contains(code.ToString());
				else
					pred=ent=>ent.Glyphs.Contains(code.ToChar());
				var found = FindAll(pred);
				return found.Select(ent=>ent.Index).ToList();
			}
		}
		public List<T> this[char ch]
		{
			get{ return FindAll(ent=>ent.Glyphs.Contains(ch)).Select(ent=>ent.Index).ToList();}
		}
	}
}

