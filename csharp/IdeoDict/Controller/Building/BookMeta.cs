using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using IdeoDict.Util;
namespace IdeoDict.Controller.Building
{
	
	public abstract class BookMeta
	{
		public BookType Type{get;set;}
		public string Title{get;set;}
		public string Author{get;set;}
		public string Description{get;set;}
		public string Medium{get;set;}
		public string File{get;set;}
		public IBookBuilder BookBuilder{
			get{
				MediumAttribute ma = this.GetType().GetAttr<MediumAttribute>();
				if( ma == null )
					return null;
				else{
					Type tb =	Assembly.GetExecutingAssembly().GetTypes()					
					.Where(t=>t.GetInterface("IBookBuilder")!=null)
					.FirstOrDefault(t=>{
						MediumAttribute a =	t.GetAttr<MediumAttribute>();
						return a != null && a.Medium == ma.Medium &&
									t.HasAttr<TypeOfBookAttribute>(ba=>ba.BookType == Type);
									
						});
					IBookBuilder bb = (IBookBuilder)Activator.CreateInstance(tb);
					bb.BookMeta = this;
					return bb;
					
				}
			}
		}
	}
	
	
}

