using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Activation;
using Db4objects.Db4o.Collections;

namespace IdeoDict
{

	public class TrSect : TrNode
	{
		string _label;
		TrNode _parent;
		public override string Label {
			get {
				Activate (ActivationPurpose.Read);
				return _label;
			}
			set {
				Activate (ActivationPurpose.Write);
				_label = value;
			}
		}

		public override TrNode Parent {
			get {
				Activate (ActivationPurpose.Read);
				return _parent;
			}
			set {
				Activate (ActivationPurpose.Write);
				_parent = value;
			}
		}

		ArrayList4<TrNode> _children = new ArrayList4<TrNode> ();
		public override ArrayList4<TrNode> Children {

			get { return this.Rd ()._children; }
		}

		public TrSect ()
		{
		}
		public TrSect (string label)
		{
			Label = label;
			
		}
		
		
		
		
	}
	
	
	
	
}

