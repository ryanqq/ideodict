using System;
namespace IdeoDict
{
	public class IdxEntry:Activatable
	{
		IdxTable _idxTable;
		string _keyword;
		
		public IdxTable IdxTable{
			get{ return this.Rd()._idxTable;}
			set{ this.Wr()._idxTable = value;}
		}
		
		public string Keyword{get;set;}
		
		public IdxEntry ()
		{
		}
		
		public IdxEntry(IdxTable idxTable, string keyword)
		{
			IdxTable = idxTable;
			Keyword = keyword;
		}
	}
}

