using System;
using Db4objects.Db4o;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Activation;
namespace IdeoDict
{
	public class Activatable :IActivatable
	{
		public Activatable ()
		{
		}
		
		
		#region IActivatable implementation
		[Transient]
		IActivator _activator;

		public void Bind (Db4objects.Db4o.Activation.IActivator activator)
		{
			if (_activator == activator)
				return;
			if (activator != null && null != _activator)
				throw new System.InvalidOperationException ();
			_activator = activator;
			
		}

		public void Activate (Db4objects.Db4o.Activation.ActivationPurpose purpose)
		{
			if (_activator != null)
				_activator.Activate (purpose);
		}
		#endregion
	}
}

