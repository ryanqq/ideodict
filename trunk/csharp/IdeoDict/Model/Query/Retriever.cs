using System;
using System.Collections.Generic;
using Db4objects.Db4o;
namespace IdeoDict
{
	public class Retriever
	{
		IObjectContainer _db;

		public Retriever (IObjectContainer db)
		{
			_db = db;
		}
		
//		public IList<TrLeaf> EntriesByIndex(TrNode book, string keyword)
//		{
//			
//		}
//		
//		public IList<IdxEntry> IndicesByEntry()
//		{}
	}
}

