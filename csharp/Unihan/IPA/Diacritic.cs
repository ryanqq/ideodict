using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Unihan;
namespace IPA
{
	public class Diacritic: Ipa, IEnumerable<char>,IEnumerable
	{
		#region lookup data
		
		static Diacritic(){
			
			
		}
		#endregion
		
		#region parser
		static public  Diacritic ParseDiacritics(string str, int at)
		{
			Diacritic res = null;
			
			IpaDiacritic dia = 0;			
			
			if(dia != 0)
				res = new Diacritic(dia);
			return res;	
			
		}
		#endregion
		
		#region ctor
		public Diacritic (IpaDiacritic diacritic)
		{
			_glyph = (ulong)diacritic;			
		}
		#endregion

		public override bool IsGrapheme {
			get {
				return false;
			}
		}
		public override Diacritic Diacritics {
			get {
				return this;
			}
			set {
				
			}
		}
		
		public override Ipa Attached{
			get{return null;}
			set{}
		}
		#region IEnumerable[System.Char] implementation
		public IEnumerator<char> GetEnumerator ()
		{
			ulong udia = _glyph;				
			for (int i = 0; i < 32; i++) {
				ulong bit = ((ulong)1<<i);
				if(Diacritic & bit > 0)
					yield return diacriticMapper[(IpaDiacritic)bit];					
			}
			if(IpaMask.Length & udia > 0)
				yield return diacriticMapper[(IpaDiacritic)(IpaMask.Length & udia)];
			if(IpaMask.ToneSign & udia > 0)
				yield return diacriticMapper[(IpaDiacritic)(IpaMask.ToneSign & udia)];
		}
		#endregion
		
		#region toString
		public override string ToString ()
		{
			var sb = new StringBuilder();
			foreach(char c in this)sb.Append(c);
			return sb.ToString();
		}
		#endregion
}
}

