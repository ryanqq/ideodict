using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Unihan
{
	public enum MandarinTranscriptionForm{
		Pinyin,Zhuyin,Yale, WadeGiles, TongyongPinyin,GwoyeuRomatzyh
	}
	
	//[StructLayout(LayoutKind.Sequential,Pack=1)]
	public struct Mandarin: IHanIndex<Mandarin>,IEquatable<Mandarin>
	{
		static readonly char[] zyInitials = "ㄅㄆㄇㄈㄪㄉㄊㄋㄌㄍㄎㄫㄏㄐㄑㄬㄒㄓㄔㄕㄖㄗㄘㄙ".ToCharArray();
		static readonly char[] zyMedials ={'ㄧ','ㄨ','ㄩ'};
		static readonly char[] zyFinals = "ㄚㄛㄜㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦ".ToCharArray();		
		static readonly char[] zyTones = {'ˊ','ˇ','ˋ','·','˙'};
		static readonly string[] pyInitials ="b,p,m,f,v,d,t,n,l,g,k,ng,h,j,q,gn,x,zh,ch,sh,r,z,c,s".Split(',');
		static readonly string[] pyMedials ={"i","u","ü"};
		static readonly string[] pyFinals = "a,o,e,ê,ai,ei,ao,ou,an,en,ang,eng,er".Split(',');
		static readonly string[] pyTones ={"ˉ","ˊ","ˇ","ˋ","·","˙"};
		
		ushort _value;
		
		#region IHanIndex[Mandarin] implementation
		public HEntryList<Mandarin> Table
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		#endregion

		#region IEquatable[Mandarin] implementation
		public bool Equals (Mandarin other)
		{
			throw new NotImplementedException ();
		}
		#endregion
		

		#region IEquatable[Unihan.IHanIndex[Mandarin]] implementation
		public bool Equals (IHanIndex<Mandarin> other)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
//		public string PinyinMarked {
//			get{}
//		}
//		
//		public string Zhuyin{
//			get{}
//		}
//		
//		public string PinyinInitial{
//			get{}
//		}
//		
//		public string ZhuyinInitial{
//			get{}
//		}
//		
//		public string PinyinMedial{
//			get{}
//		}
//		public string ZhuyinMedial{
//			get{}
//		}
//		public string PinyinFinal{
//			get{}
//		}
//		
//		public string ZhuyinFinal{
//			get{}
//		}
//		
//		public Tone Tone{
//			get{}
//		}
//		
//		public int ToneNumber{
//			get{}
//		}
	}
}

