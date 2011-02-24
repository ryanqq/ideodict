using System;
using Db4objects.Db4o;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Activation;
namespace IdeoDict
{
	

	public static class ActivatableHelper
	{

		public static T Rd<T> (this T a) where T : IActivatable
		{
			a.Activate (ActivationPurpose.Read);
			return a;
			
		}
		public static T Wr<T> (this T a) where T : IActivatable
		{
			a.Activate (ActivationPurpose.Write);
			return a;
		}
		
	}
}

