using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace IdeoDict.Controller.Building
{
	/// <summary>
	/// parsing a csv file to generate a BDict object
	/// </summary>
	public class CsvParser:IDisposable,IEnumerable<List<string>>//,IEnumerable
	{
		TextReader _sreader;
		Regex _separator;
		bool _started = false;
		List<string> _line;
		public List<string> Columns {
			get;
			protected set;
		}
		
		
		public CsvParser (string fname):this(fname,'|'){}
		public CsvParser (string fname,char separator)
			:this(new StreamReader(fname),separator){}
		
		public CsvParser(TextReader sreader):this(sreader,'|'){}
		public CsvParser(TextReader sreader,char separator)
		{
			_sreader = sreader;
			_separator = new Regex(string.Format(@"\s*[{0}]\s*",separator),RegexOptions.Multiline);
			
			Columns = ParseLine();
		
			
		}
		
		List<string> ParseLine()
		{
			string line = _sreader.ReadLine();
			if(line == null)return null;
			line = line.Trim();
			if(line == string.Empty)return ParseLine();
			return new List<string>(_separator.Split(line));
		}
		
		

		#region IEnumerable[System.String[]] implementation
		public IEnumerator<List<string>> GetEnumerator ()
		{
			while((_line = ParseLine())!=null){				
				
					yield return _line;
				
			}
		}
		#endregion


		#region IEnumerable implementation
		IEnumerator IEnumerable.GetEnumerator ()
		{
		 return	GetEnumerator();
		}
		#endregion

		public void Dispose ()
		{
			_sreader.Dispose();
		}
	

		
	}
}

