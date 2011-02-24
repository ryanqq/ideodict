using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using Db4objects.Db4o.TA;
using System.Linq;
namespace IdeoDict
{
	/// <summary>
	/// Each TrRoot may have many IdxTables
	/// </summary>
	public class IdxTable : Activatable
	{
		TrRoot _book;
		string _name;

		public TrRoot Book {
			get { return this.Rd ()._book; }
			set { this.Wr ()._book = value; }
		}
		public string Name {
			get { return this.Rd ()._name; }
			set { this.Wr ()._name = value; }
		}
		
		public IdxTable(){}
		
		public IdxTable(TrRoot book, string name)
		{
			Book = book;
			Name = name;
		}
	}


}

