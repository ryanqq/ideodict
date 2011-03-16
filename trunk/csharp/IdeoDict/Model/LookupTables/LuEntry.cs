using System;
using System.Collections.Generic;
namespace IdeoDict
{
	public class LuEntry: Activatable
	{
		LuTable _luTable;
		TrNode _link;
		List<string> _cols ;
		
		#region props
		public LuTable LuTable{
			get{ return this.Rd()._luTable;}
			set{ this.Wr()._luTable = value;}
		}
		
		public TrNode Link{
			get{ return this.Rd()._link;}
			set{ this.Wr()._link = value;}
		}
		
		public List<string> Cols{
			get{ return this.Rd()._cols;}
			set{ this.Wr()._cols = value;}
		}
		#endregion
		
		public string this[string colname]{
			get{
				if(Cols == null || LuTable ==null)return null;
				int idx = LuTable.ColNames.IndexOf(colname);
				return idx >= 0 && idx < Cols.Count ? Cols[idx] : null;
			}
		}
		
		public LuEntry ()
		{
		}
		public LuEntry(LuTable lutbl, IEnumerable<string> cols)
		{
			LuTable = lutbl;
			Cols =  new List<string>(cols);
		}
	}
}

