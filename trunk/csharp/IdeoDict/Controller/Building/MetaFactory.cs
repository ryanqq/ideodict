using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using IdeoDict.Util;
using System.IO;
using System.Reflection;
namespace IdeoDict.Controller.Building
{
	public static class MetaFactory
	{
		public static BookMeta Load(string fname)
		{
			JObject json = JObject.Parse(File.ReadAllText(fname));
			string medium = (string)json["Medium"];
			Type tmeta = Assembly.GetExecutingAssembly().GetTypes()
				.Where(t=>t.BaseType == typeof(BookMeta))
				.First(t=>t.HasAttr<MediumAttribute>(a=>a.Medium == medium));
			JsonSerializer js = new JsonSerializer();
			BookMeta bm =  (BookMeta)js.Deserialize(new JsonTokenReader(json),tmeta);
			return bm;
			
		}
	}
}

