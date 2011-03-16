using System;

namespace Unihan
{
	public static class Han
	{
		#region boundaries of cjk character blocks 
		public const char CjkGT = '\u4dff', CjkLT = '\u9fa6';
		public const char CjkAGT = '\u33ff', CjkALT = '\u4db6';
			
		//surrogate pairs
		public const char HiSurrogateGT = '\ud7ff', HiSurrogateLT = '\udc00';
		public const char LoSurrogateGT = '\udbff', LoSurrogateLT = '\ue000';
		public const int CjkBGT = 0x1ffff,CjkBLT =0x2a6d7;
		#endregion
		
	
		
	}
}

