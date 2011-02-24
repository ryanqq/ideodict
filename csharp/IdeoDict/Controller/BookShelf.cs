using System;
using System.Collections.Generic;
namespace IdeoDict
{
	public class BookShelf:List<TrRoot>
	{
		public BookShelf ()
		{
		}
		
		public TrRoot this[string bookname]
		{
			get{ return this.Find(b=>b.Label == bookname);}
			
		}
		public void Remove(string bookname)
		{
			TrRoot book = this[bookname];
			if(book != null)Remove(book);
		}
		
		public  new  void Add(TrRoot book)
		{
			if(!this.Contains(book))base.Add(book);
		}
	}
}

