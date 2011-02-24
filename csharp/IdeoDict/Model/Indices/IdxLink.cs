using System;
namespace IdeoDict
{
	/// <summary>
	/// The idx to entry mapping may be in many to many style, therefore we need links to cope
	/// with rmdb's association mechanism
	/// </summary>
	public class IdxLink:Activatable
	{
		TrLeaf _target;
		IdxEntry _index;
		
		public TrLeaf Target{
			get{ return this.Rd()._target;}
			set{ this.Wr()._target = value;}
		}
		
		public IdxEntry Index{
			get{ return this.Rd()._index;}
			set{ this.Wr()._index= value;}
		}
		
		public IdxLink(IdxEntry idx, TrLeaf targ)
		{
			Index = idx;
			Target = targ;
		}
		
		public IdxLink ()
		{
		}
	}
}

