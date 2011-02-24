using System;
namespace IdeoDict
{
	/// <summary>
	/// dictionary entry
	/// </summary>
	public class TrEntry : TrLeaf
	{
		string _label;

		public override string Label {
			get { return this.Rd ().Label; }
			set { this.Wr ()._label = value; }
		}

		public TrEntry ()
		{
		}
		public TrEntry (string hw, string def)
		{
			Label = hw;
			Content = def;
		}
		
	}
}

