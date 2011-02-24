using System;
using Db4objects.Db4o.Collections;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Activation;
using Db4objects.Db4o;

namespace IdeoDict
{
	public abstract class TrNode : Activatable	
	{
		#region props
		//TrNode might not have label, such as a paragraph node
		public abstract string Label { get; set; }

		//TrNode's Parent might be a calculated one
		public abstract TrNode Parent { get; set; }

		//Leafnodes have node children (null)
		public abstract ArrayList4<TrNode> Children { get; }
		
		public virtual TrRoot Root {
			get { 
				return this is TrRoot ?
					(TrRoot)this : Parent == null ?
						null :
							Parent is TrRoot ?
								(TrRoot)Parent : Parent.Root; }
		}
		
		#endregion
		
		public virtual void Append (TrNode node)
		{
			//activation is delegated to Children
			if (node != null && Children != null) {
				node.Parent = this;
				Children.Add (node);
			}
			
		}
		public bool HasChild (TrNode child)
		{
			//activation is delegated to Children
			return Children == null ? false : Children.Contains (child);
		}
		
		public TrNode GetNodeByChild (TrNode child)
		{
			TrNode found = null;
			if (HasChild (child))
				found = this; else if (Children != null)
				foreach (TrNode c in Children) {
					found = c.GetNodeByChild (child);
					if (found != null)
						break;
				}
			return found;
		}
		
//		public TrNode SearchPath(){}
//		public IList<TrNode> Ancestors{
//			get{
//				
//			}
//		}

		public virtual TrNode Find (string label)
		{
			return (Children != null && label != null && label != string.Empty) ? 
				Children.Find (n => n.Label == label) : 
					null;
		}



	}


}

