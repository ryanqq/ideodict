using System;
using System.Collections.Generic;
namespace IdeoDict
{
	public class TrRoot : TrSect
	{
		public override TrNode Parent {
			get { return null; }
			set { }
		}
		public BookType Type { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public Dictionary<string,IdxTable> Indices { get; set; }
		public Dictionary<string,LuTable> LuTables{get;set;}
		
		
		
	}
}

