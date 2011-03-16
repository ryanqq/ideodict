using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
namespace Unihan
{
	/// <summary>
	/// 214 radicals of Kangxi dictionary
	/// </summary>
	
	
	
	public struct Radical: IHanIndex<Radical>,IEquatable<Radical>
	{
		//TODO: How to deal with multiple variants and grouping and total strokes counting?
		
		
		#region lookupTable
		public static readonly HEntryList<Radical>  Lookup = HData.LoadIndexTable<Radical>(ParseTuple);			
		
		static Radical ParseTuple(string[] tuple)
		{
			return new Radical(int.Parse(tuple[0]), tuple[1]=="1"?true:false, int.Parse(tuple[2]));			
		}
		#endregion
		
		#region static data
		const string RADICALS =
			"一丨丶丿乙亅二亠人儿入八冂冖冫几凵刀力勹"+ 
			"匕匚匸十卜卩厂厶又口囗土士夂夊夕大女子宀"+
			"寸小尢尸屮山巛工己巾干幺广廴廾弋弓彐彡彳"+
			"心戈戶手支攴文斗斤方无日曰月木欠止歹殳毋"+
			"比毛氏气水火爪父爻爿片牙牛犬玄玉瓜瓦甘生"+
			"用田疋疒癶白皮皿目矛矢石示禸禾穴立竹米糸"+
			"缶网羊羽老而耒耳聿肉臣自至臼舌舛舟艮色艸"+
			"虍虫血行衣襾見角言谷豆豕豸貝赤走足身車辛"+
			"辰辵邑酉釆里金長門阜隶隹雨靑非面革韋韭音"+
			"頁風飛食首香馬骨高髟鬥鬯鬲鬼魚鳥鹵鹿麥麻"+
			"黃黍黑黹黽鼎鼓鼠鼻齊齒龍龜龠";
		
		const string VAR_RADICALS = "纟见讠贝车钅长门韦页风飞饣马鱼鸟卤麦黾齐齿龙龟";		
		static readonly byte[] varRadicalIndices = {120,147,149,154,159,167,168,169,178,181,182,183,184,187,195,196,197,199,205,210,211,212,213};		
		static readonly byte[] groups = {1,30,39,61,72,85,95,118,140,147,167,187};		
		static readonly byte[] radStrokes = {0,1,7,30,61,95,118,147,167,176,187,195,201,205,209,211,212,214};
		const int STROKESMASK = 127;
		const int ORTHOMASK = 128;
		#endregion
		
		//[xxxxxxxx][yzzzzzzz]
		//    |      |    +--rest strokes
		//    |      +-----if it's traditional		
		//    +---radical order (1-214)
		readonly ushort _radInfo;
		
		#region ctors

		
		static ushort CreateRadical(int radOrd, bool isOrtho, int? strokes)
		{
			if(radOrd <= 0 || radOrd > 214)
					throw new ArgumentOutOfRangeException("invalid radical");
			int rad = 0;
			rad += radOrd << 8;
			if(!isOrtho)rad |= ORTHOMASK;		//0b1000,0000	
			rad |= strokes.HasValue ? strokes.Value: STROKESMASK;
			return (ushort)rad;
		}
		
		public Radical(char name):this(name,null){}
		
		public Radical(int radOrd):this(radOrd,true,null){}
		
		public Radical(char name, int? strokes)
		{			
			int rIdx = RADICALS.IndexOf(name);			
			//orthodox radical
			if(rIdx >= 0 )
			{
				_radInfo = CreateRadical(rIdx + 1,true,strokes);
			}
			else
			{
				rIdx = VAR_RADICALS.IndexOf(name);
				if(rIdx < 0)
					throw new ArgumentOutOfRangeException("invalid radical");
				_radInfo = CreateRadical(varRadicalIndices[rIdx],false,strokes);
			}
			
		}
		
		public Radical(int radOrd, bool isOrtho, int? strokes)
		{		
			_radInfo = CreateRadical(radOrd,isOrtho,strokes);
		}
		
		#endregion
		
		#region props
		//If the lower byte equals to 0xFF, that means no strokes-field is provided
		public bool HasStrokesField{
			get{return (_radInfo & STROKESMASK)!=STROKESMASK; }
		}
		
		public bool IsOrthodox{
			get{ return (_radInfo & ORTHOMASK) == 0; }
			
		}
		
		public char Name
		{
			get
			{ 
				if(IsOrthodox)return KangxiName;
				return VAR_RADICALS[Array.BinarySearch(varRadicalIndices,(byte)KangxiOrder)];
				
				
			}
		}
		
		public char KangxiName{
			get{
				return RADICALS[KangxiOrder - 1];
			}
		}
		
		public int KangxiOrder{
			get{ return _radInfo >> 8;}
		}
		
		public int RadicalStrokes{
			get{
				int idx = Array.BinarySearch(radStrokes,(byte)KangxiOrder);
				return idx < 0 ? ~idx : idx;
			}
		}
		
		public int? RestStrokes{
			get{ return HasStrokesField? (_radInfo & STROKESMASK):(int?)null;}
		}
		
		public KangxiGroup Group{
			get{
				int idx = Array.BinarySearch(groups,(byte)KangxiOrder);
				if(idx < 0)idx = ~idx;
				return (KangxiGroup)idx;
			}
		}
		
		#endregion
		
		
		
		public static Radical Of(char c)
		{
			return Lookup.First(re=>re.Glyphs.Contains(c)).Index;			
		}
		
		public static Radical Of(CodePoint cp)
		{
			return Lookup.First(re=>re.Glyphs.Contains(cp)).Index;
		}
	

		#region IHanIndex[Radical] implementation
		public HEntryList<Radical> Table
		{
			get
			{
				return Lookup;
			}
		}
		#endregion

		#region IEquatable[Radical] implementation
		public bool Equals(Radical other)
		{
			return this._radInfo == other._radInfo;
		}
		public bool Equals (IHanIndex<Radical> other)
		{
			return other.Equals(this);
		}
		public override bool Equals (object obj)
		{
			if(obj==null)
				return base.Equals (obj);
			return Equals((Radical)obj);
		}
		#endregion
		public override string ToString ()
		{
			return string.Format ("{0}集{1}部{2}畫", Group, Name, RestStrokes);
		}
}
}

