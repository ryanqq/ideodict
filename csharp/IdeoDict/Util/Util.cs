using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace IdeoDict.Util
{
	public static class Ext
	{
		public static Attr GetAttr<Attr>(this Type t)where	 Attr:Attribute
		{
			return (Attr)t.GetCustomAttributes(typeof(Attr),false).FirstOrDefault();			
			
		}
		public static bool HasAttr<Attr>(this Type t) where Attr:Attribute
		{
			return GetAttr<Attr>(t)!=null;
		}
		public static bool HasAttr<Attr>(this Type t,Func<Attr,bool> pred) where Attr:Attribute
		{
			var attrs = t.GetCustomAttributes(typeof(Attr),false);			
			foreach(var attr in attrs){
				if(pred((Attr)attr))return true;
			}				
			return  false;
		}
		public static int Len(this string s){return s.Length;}
	}
}

