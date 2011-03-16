using System;
using System.Text;
using System.Collections.Generic;
using Unihan;
namespace IPA
{
	public class Grapheme : IEnumerable<char>
	{
		//static IpaParser diacriticParser;

		#region static data initialization
		public const string TONEBARS = "˩˨˧˦˥";
		const string GRAPHEMES = "bɖɟgɢʡmɱnɳɲŋɴʙrʀяɾɽβvðzʒʐʑʝɣʁʕʢɦwʋɹɻjɰʣʤʥɮlɭʎʟɺɓɗʄɠʛpʈckqʔɸfθsʃʂɕçxχħʜhʦʧʨɬʘǀǁǂiɪeɛæaɨɘəɜɐɯɤʌɑyʏøœɶʉɵɞuʊoɔɒ";
		const string DIACRITICS = "\u0325\u032c\u02b0\u0339\u031c\u031f\u0320\u0308\u033d\u0329" + "\u032f\u02de\u0324\u0330\u033c\u02b7\u02b2\u02e0\u02e4\u0334" + "\u031d\u031e\u0318\u0319\u032a\u033a\u033b\u02dc\u207f\u02e1\u031a";
		const int NONLETTERMASK = 4096 << 15;
		static readonly BiDictionary<Grapheme, char> graphemeMapper;
		static readonly BiDictionary<IpaDiacritic, char> diacriticMapper;

		static BiDictionary<T, char> MapperInsert<T> (BiDictionary<T, char> mapper, string chars, int shift)
		{
			for (int i = 0; i < chars.Length; i++)
			{
				mapper[(T)(object)(i << shift)] = chars[i];
			}
			return mapper;
		}

		static Grapheme ()
		{
			//populate the grapheme mapper
			graphemeMapper = new BiDictionary<IpaGrapheme, char> ();
			foreach (char c in GRAPHEMES)
			{
				graphemeMapper[c] = (IpaGrapheme)Enum.Parse (typeof(IpaGrapheme), c.ToString ());
			}
			MapperInsert<Grapheme> (graphemeMapper, "ˈˌ.|‖‿", 15);
			MapperInsert<Grapheme> (graphemeMapper, TONEBARS, 18);
			MapperInsert<Grapheme> (graphemeMapper, "₁₂₃₄₅₆", 21);
			MapperInsert<Grapheme> (graphemeMapper, "↓↑↗↘", 24);
			graphemeMapper['!'] = new Grapheme (IpaGrapheme.Click | IpaGrapheme.Alveolar);
			
			//Special chars which merged with a diacritic
			graphemeMapper = new BiDictionary<Grapheme, char> ();
			graphemeMapper['ʍ'] = new Grapheme (IpaGrapheme.Fricative | IpaGrapheme.Velar | IpaGrapheme.MergedWithDiacritic | IpaGrapheme.Voiceless, IpaDiacritic.Labalized);
			
			graphemeMapper['ɥ'] = new Grapheme (IpaGrapheme.Approximant | IpaGrapheme.Palatal | IpaGrapheme.MergedWithDiacritic, IpaDiacritic.Labalized);
			
			
			graphemeMapper['ɫ'] = new Grapheme (IpaGrapheme.LateralApproximant | IpaGrapheme.Alveolar | IpaGrapheme.MergedWithDiacritic, IpaDiacritic.Velarized);
			
			//populate the diacritic mapper
			diacriticMapper = new BiDictionary<IpaDiacritic, char> ();
			for (int i = 0; i < DIACRITICS.Length; i++)
			{
				diacriticMapper[(IpaDiacritic)(1 << i)] = DIACRITICS[i];
			}
			diacriticMapper[IpaDiacritic.Ejective] = 'ʼ';
			MapperInsert<IpaDiacritic> (diacriticMapper, "\u030B\u0301\u0304\u0300\u030F\u030C\u0302", 32);
			MapperInsert<IpaDiacritic> (diacriticMapper, "ːˑ\u02D8", 35);
			diacriticParser = Diacritic.ParseDiacritics;
		}
		#endregion

		public IpaGrapheme FreePart
		{
			get;
			set;
		}

		public IpaDiacritic Diacritic
		{
			get;
			set;
		}
		#region ctor

		static bool IsValid (IpaGrapheme grapheme)
		{
			ulong dummy;
			return !ulong.TryParse (grapheme.ToString (), dummy);
		}
		static bool IsValid (IpaDiacritic diacritic)
		{
			ulong dummy;
			return !ulong.TryParse (diacritic.ToString (), dummy);
		}

		public Grapheme (IpaGrapheme grapheme, IpaDiacritic diacritic)
		{
			if (!IsValid (grapheme) || !IsValid (diacritic))
				throw new ArgumentException ("invalid");
			FreePart = grapheme;
			Diacritics = diacritic;
		}


		public Grapheme (IpaGrapheme grapheme) : this(grapheme, IpaDiacritic.None)
		{
			
		}

		//public WholeGrapheme(int grapheme):this((IpaGrapheme)grapheme,IpaDiacritic.None){}
		#endregion

		#region parser
		public static Grapheme Parse(string str)
		{
			return Parse(str,0);	
		}
		public static Grapheme Parse(string str ,int at)
		{
			return Parse(str, ref at);
		}
		public static Grapheme Parse (string str, ref int at)
		{
			
			Grapheme grapheme = null;
			
			char ch = str[at];
			bool found = graphemeMapper.TryGetValue (ch, out grapheme);
			
			if (found && ++at < str.Length && (grapheme.FreePart & NONLETTERMASK == 0))
			{
				//try to parse diacritics
				do
				{
					// combine all diacritics to single enum
					IpaDiacritic part;
					bool foundDia = diacriticMapper.TryGetValue (str[at], out part);
					if (!foundDia)
						break;
					grapheme.Diacritic |= part;
					
				}
				while (++at < str.Length);
			}
			
			return grapheme;
		}
		#endregion



		#region toString
		string GraphemeToString ()
		{
			var grapheme = (IpaGrapheme)_glyph;
			string s = grapheme.ToString ();
			if (char.IsDigit (s[0]) || char.IsUpper (s[0]))
			{
				//non-enum-field char
				s = graphemeMapper[grapheme].ToString ();
			}
			return s;
		}
		public override string ToString ()
		{
			var sb = new StringBuilder (GraphemeToString ());
			if (HasDiacritics)
				sb.Append (Diacritic.ToString ());
			if (HasAttached)
				sb.Append (Attached.ToString ());
			return sb.ToString ();
		}
		#endregion

		#region IEnumerable[System.Char] implementation
		IEnumerator<char> IEnumerable<char>.GetEnumerator ()
		{
			yield return GraphemeToString ()[0];
			if (Diacritics != null)
				foreach (char ch in Diacritics)
					yield return ch;
			if (Attached != null)
				foreach (char ch in Attached)
					yield return ch;
			
		}
		#endregion
		public static explicit operator Grapheme (int grapheme)
		{
			return new Grapheme ((IpaDiacritic)grapheme);
		}
	}
}

