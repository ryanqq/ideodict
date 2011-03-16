using System;
using System.Collections.Generic;
namespace IdeoDict
{
	//lookup table
	public class LuTable: Activatable
	{
		List<string> _colNames = new List<string>();
		public string Name{get;set;}
		
		public List<string> ColNames{get{return _colNames;}}
		
		public TrRoot Book {get;set;}
		
		public LuTable ()
		{
		}
		
		public LuTable(TrRoot book, string name)
		{
			Book = book;
			Name = name;
		}
	}
}

