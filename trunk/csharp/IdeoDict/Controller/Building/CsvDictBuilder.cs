using System;
using System.Collections.Generic;
using Db4objects.Db4o;
namespace IdeoDict.Controller.Building{
	
	
	
	[Medium("csv")]
	[TypeOfBook(BookType.Dictionary)]
	public class CsvDictBuilder:IBookBuilder
	{
		List<string> _cols;
		TrRoot _dict;
		TrNode _node;
		List<string> _segment;
		CsvBookMeta _meta;
		#region IBookBuilder implementation
		public void Build ()
		{
//			
//			_dict = new TrRoot();
//			Db.Store(_dict);
//			_dict.Label = _meta.Title;
//			_dict.Type = _meta.Type;
//			CsvParser parser = new CsvParser(_meta.File);
//			_cols = parser.Columns;
//			
//			Action<int,int> job = delegate{};
//			if(_meta.TocCols != null)jobs+=MakeTocPath;
//			if(_meta.BodyCols != null)job+= MakeEntry;
//			//TODO
//			foreach(var line in parser){
//				
//				MakeTocPath(line.GetRange(_meta.TocCols.Start,_meta.TocCols.Count));
//				MakeEntry(line.GetRange(_meta.BodyCols.Start,_meta.BodyCols.Count));
//				
//			}
		}
		void MakeTocPath(List<string> sect)
		{
			_node = _dict;
			foreach(string l in sect){
				if(l != null && l != string.Empty){
					TrNode targ =_node.Children.Find(child=>child.Label == l);
					if(targ==null){
						targ = new TrSect(l);
						_node.Append(targ);
						
					}
					_node = targ;
				}
				
			}
			
		}
		void MakeEntry(List<string> sect)
		{
			TrEntry ent = new TrEntry(sect[0],sect[1]);
			_node.Append(ent);
		}
		public IObjectContainer Db{set;private get;}
		public TrRoot Book {get;set;}

		public BookMeta BookMeta {
			set {
				_meta = (CsvBookMeta)value;
			}
		}
		#endregion		
	}
	
}
