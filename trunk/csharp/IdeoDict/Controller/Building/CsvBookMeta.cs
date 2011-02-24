using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
namespace IdeoDict.Controller.Building
{
//	/// <summary>
//	/// The format of to be imported file which is used to generate a dict/blook object
//	/// </summary>
//	enum TextType{Csv,Html,Xml}
//TODO: For now only csv file will be supported
	
	
	
	[JsonObject(MemberSerialization.OptOut)]
	class ColRange
	{
		public int Start, Count;
		public override string ToString ()
		{
			return string.Format ("{0}..{1}",Start,Count);
		}
	}
	[JsonObject(MemberSerialization.OptOut)]
	class CsvIndexMeta
	{
		public string Name;
		public bool Many2One;
		public int Col;
		public override string ToString ()
		{
			return string.Format ("[({0}){1} on Column({2})]",Many2One?"m21":"12m",Name,Col);
		}
	}
	
	class CsvLookupTable
	{
		public string Name;
		public ColRange Cols;
		//name of the column that represents the node level to be linked to
		public string LinkTo;
	}
	
	[JsonObject(MemberSerialization.OptOut)]
	[Medium("csv")]
	class CsvBookMeta:BookMeta
	{
		
		public ColRange TocCols;
		public ColRange BodyCols;
		public List<CsvIndexMeta> Indices;
		public List<CsvLookupTable> LookupTables;
		
		public override string ToString ()
		{
			return string.Format ("[{0}]\n"+
			                      "Title: {1}\n"+
			                      "Author: {2}\n"+
			                      "Desc: {3}\n"+
			                      "Toc: {4} Body: {5}\n{6}",
			                      Type,Title,Author,Description,TocCols,BodyCols,
			                      string.Join(",",Indices.Select(x=>x.ToString()).ToArray())
			                      );
		}
	}
}

