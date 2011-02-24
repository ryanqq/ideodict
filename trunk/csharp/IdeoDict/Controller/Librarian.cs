using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
namespace IdeoDict
{
	using IdeoDict.Controller.Building;
	public class Librarian
	{
		IObjectContainer _db;
		BookShelf _books = new BookShelf();
		
		public BookShelf Books {get{ return _books;}}
		
		
		public Librarian (IObjectContainer db)
		{
			_db = db;
		}
		
		/// <summary>
		/// import a book
		/// </summary>
		/// <param name="metafile">
		///	name of local metafile
		/// </param>
		public void StoreBook(string metafile)
		{
			Books.Add(BookImporter.ImportLocal(metafile,_db));
		}
		
		public TrRoot LoadBook(string bookname)
		{
			IQuery q = _db.Query();
			q.Constrain(typeof(TrRoot));
			q.Descend("_lable").Constrain(bookname);
			TrRoot book = (TrRoot)q.Execute().Next();
			Books.Add(book);
			return book;
			
		}
		
		public void UnloadBook(string bookname)
		{
			_books.Remove(bookname);
		}
//		
//		public IList<TrLeaf> GetBookEntries(string bookname, string idxkey)
//		{
//			
//		}
		
	}
}

