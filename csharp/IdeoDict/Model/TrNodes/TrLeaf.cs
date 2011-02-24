using System;
using Db4objects.Db4o;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Collections;
namespace IdeoDict
{

	/// <summary>
	/// base class for both trEntry and trPara
	/// leafnodes have links to their rootnodes (dict or book)
	/// they will be directly stored in db and be querible through their root and label/content
	/// </summary>
	public abstract class TrLeaf : TrNode
	{


		TrRoot _book;
		string _content;

		public TrRoot Book {
			get { return this.Rd ()._book; }
			set { this.Wr()._book = value; }
		}

		public override TrRoot Root {
			get { return Book; }
		}

		public override ArrayList4<TrNode> Children {
			get { return null; }
		}

		//calculate parent to save storage space
		public override TrNode Parent {
			get { return Book.GetNodeByChild (this); }
			set { }
		}

		public string Content {

			get { return this.Rd ()._content; }
			set { this.Wr ()._content = value; }
		}
		
	}
}

