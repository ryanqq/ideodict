using System;
namespace IdeoDict
{
	public class TrPara : TrLeaf
	{

		public override string Label {
			get { return Parent.Children.IndexOf (this).ToString (); }
			set { }
		}
		public TrPara ()
		{
		}
		public TrPara (string content)
		{
			Content = content;
		}
		
	}

}

