using System;
using Ionic.Zip;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Unihan
{
	delegate T HanIndexParer<T>(string[] tuple) where T:struct, IHanIndex<T>,IEquatable<T>;
	public class HData
	{
		
		static readonly ZipFile Zip = new ZipFile("Unihan.zip");
		
		internal static HEntryList<T> LoadIndexTable<T>(HanIndexParer<T> parser)
			where T:struct ,IHanIndex<T>,IEquatable<T>
		{
			ZipEntry ent = Zip[typeof(T).Name + ".csv"];
			var table = new HEntryList<T>();
			string line;
			using(TextReader tr = new StreamReader(ent.OpenReader()))
			{				
				while ((line = tr.ReadLine())!= null)
				{
					string[] fields = line.Split(',');
					table.Add(HEntry.New<T>(parser(fields.Skip(1).ToArray()),fields[0]));
				}
			}
			return table;
		}
	}
}

