using System;
namespace Unihan
{
	[Flags]
	public enum IpaVowel:byte
	{
		Height = 7,//0b00000111
		Close=0, NearClose, CloseMid, Mid, OpenMid, NearOpen, Open,	
		Backness =56,//0b00111000
		Front=8, Central, Back,	
		Roundedness = 192, //0b11000000
		Rounded = 128,
		i = Close|Front, 
		y = Close|Front|Rounded,
		ɨ = Close|Central, 
		ʉ = Close|Central| Rounded,
		ɯ = Close|Back, 
		u = Close|Back|Rounded,
		ɪ = NearClose|Front, 
		ʏ = NearClose|Front|Rounded,
		ʊ = NearClose|Back|Rounded,
		e = CloseMid|Front, 
		ø = CloseMid|Front|Rounded,
		ɘ = CloseMid|Central,
		ɵ = CloseMid|Central|Rounded,
		ɤ = CloseMid|Back,
		o = CloseMid|Back|Rounded,
		ə = Mid|Central,
		ɛ = OpenMid|Front,
		œ = OpenMid|Front|Rounded,
		ɜ = OpenMid|Central,
		ɞ = OpenMid|Central|Rounded,
		ʌ = OpenMid|Back,
		ɔ = OpenMid|Back|Rounded,
		æ = NearOpen|Front,
		ɐ = NearOpen|Central,
		a = Open|Front,
		ɶ = Open|Front|Rounded,
		ɑ = Open|Back,
		ɒ = Open|Back|Rounded,
		
	}
}

