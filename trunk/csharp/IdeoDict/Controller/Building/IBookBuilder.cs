using System;
using Db4objects.Db4o;
namespace IdeoDict.Controller.Building
{
	public interface IBookBuilder{
		IObjectContainer Db{set;}
		TrRoot Book{set;get;}
		BookMeta BookMeta{set;}
		void Build();
	}
}

