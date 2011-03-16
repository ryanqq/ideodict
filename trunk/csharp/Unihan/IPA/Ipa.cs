
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using Unihan;
namespace IPA
{
	
	
	public class Ipa: /*IEnumerable<char>, */IEquatable<Ipa>
	{
		readonly string _ipa;
		
		protected struct IpaMask
		{
			public const IpaGrapheme
				Place = (IpaGrapheme)15,
				Manner= (IpaGrapheme)(15 << 4),
				Voice = (IpaGrapheme)(1 << 8),
				Height = (IpaGrapheme)(7 << 9),
				Backness =(IpaGrapheme)(3 <<12),
				Roundedness = (IpaGrapheme)(1<<14),
				Consonant = Place|Manner|Voice,
				Vowel = Height|Backness|Roundedness,
				Suprasegmental = (IpaGrapheme)(7<<15),
				ToneBar = (IpaGrapheme)(7<<18),
				ToneNumber = (IpaGrapheme)(7<<21),
				ToneSign = (IpaGrapheme)(7<<32),
				Length = (IpaGrapheme)(3<<35);
		}
		
		protected const char TIEBAR = '\u0361';
		
		
		
		Ipa(string s)
		{			
			_ipa = s;
		}
		
		
		
		#region traits
		public bool IsToneContour{
			get{
				return Grapheme.TONEBARS.Contains(_ipa[0]);
			}
		}
		public bool IsTied{
			get
			{
				return _ipa.Contains(TIEBAR);
			}
		}
		public Grapheme Grapheme
		{
			get
			{
				return Grapheme.Parse(_ipa);
			}
		}
		public Grapheme SecondGrapheme
		{
			get
			{
				int tiebarAt = _ipa.IndexOf(TIEBAR);
				return tiebarAt > 0? Grapheme.Parse(_ipa,tiebarAt + 1):null;
			}
		}
		bool IfGrapheme(Predicate<IpaGrapheme> pred)
		{
			var grapheme = Grapheme;
			return grapheme != null && pred(grapheme.FreePart) ;
		}
		public bool IsVowel{
			get{				
				return	IfGrapheme(graph=>(IpaMask.Vowel & graph) == graph);
			}
		}
		
		public bool IsConsonant{
			get{
				return IfGrapheme(graph=>(IpaMask.Consonant & graph) == graph);
			}
		}
		
		public bool IsSuprasegmental{
			get{
				return IfGrapheme(graph=>(IpaMask.Suprasegmental & graph) == graph);
			}
		}
		
		
		
		public bool IsToneNumber{
			get{
				return IfGrapheme(graph=>(IpaMask.ToneNumber & graph) == graph);
			}
		}
		
		public IpaCategory Category{
			get{
				
				if(IsConsonant)return IpaCategory.Consonant;
				if(IsVowel)return IpaCategory.Vowel;
				if(IsSuprasegmental)return IpaCategory.Suprasegmental;
				if(IsToneContour)return IpaCategory.ToneBar;
				if(IsToneNumber)return IpaCategory.ToneNumber;					
			
				return 0;
			}
		}
		#endregion

		
		
		
		
		#region template methods
		
		public int CharCount{
			get{
				return _ipa.Length;
			}				
		}
		#endregion
		

		
		#region parser	
		
		
		static public Ipa ParseUnit(string str)
		{
			return ParseUnit(str,0);
		}
		static public Ipa ParseUnit(string str, int at)
		{
			return ParseUnit(str, ref at);
		}
		static Ipa TryParseToneContour(string str, int at)
		{
			Ipa res = null;
			int idx = at;
			while(idx < str.Length && Grapheme.TONEBARS.Contains(str[idx]))
				idx++;
			if(idx > at)
				res = new Ipa(str.Substring(at,idx - at));
			return res;
			
		}
		/// <summary>
		/// Factory method and chain of responsibility pattern using delegates
		/// </summary>		
		static public Ipa ParseUnit(string str, ref int at)
		{
			if(string.IsNullOrEmpty(str)|| at >= str.Length)return null;
			Ipa res= null;			
			int idx = at;
			while(idx < str.Length)
			{
				if((res = TryParseToneContour(str, idx))!= null)
					return res;					
				Grapheme grapheme =  Grapheme.Parse(str,ref idx);
				if(grapheme == null) return null;
				//Try to parse tied double consonants like t‍͡s
				if(idx < str.Length && str[idx]== TIEBAR)
					grapheme = Grapheme.Parse(str,ref idx);
			}
			if(idx > at)
			{
				res = new Ipa(str.Substring(at,idx - at));
				at = idx;					
			}
			return res;		
			
		}
		#endregion
		
		#region IEnumerable implementation
//		IEnumerator IEnumerable.GetEnumerator ()
//		{
//			return GetEnumerator();
//		}
		#endregion
		
		#region equality
		public override int GetHashCode ()
		{
			return _ipa.GetHashCode();
		}
		
		public static bool operator == (Ipa left , Ipa right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(Ipa left,Ipa right)
		{
			return !(left== right);
		}

		#region IEquatable[Ipa] implementation
		public bool Equals (Ipa other)
		{
			return other._ipa == this._ipa;
		}
		#endregion
		#endregion
		
		public static implicit operator Ipa(string s)
		{
			return ParseUnit(s);
		}
		
		public override string ToString ()
		{
			return _ipa;
		}
	}
	
}

