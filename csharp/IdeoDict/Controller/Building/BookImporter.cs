using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Db4objects.Db4o;
namespace IdeoDict.Controller.Building
{
	/// <summary>
	/// Book buiding director, which build a book from a book medium: csv html etc
	/// the metafile(json/yaml) in which the book medium type is declared will be read first, 
	/// the importer will choose the appropriate importing method accordingly
	/// </summary>
	static public class BookImporter
	{
		public static TrRoot ImportLocal(string metafile,IObjectContainer db )
		{
			BookMeta meta = MetaFactory.Load(metafile);
			IBookBuilder bb = meta.BookBuilder;
			bb.Build();
			return bb.Book;
			
		}
	}
}

