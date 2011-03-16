using System;
namespace IPA
{
	
	[Flags]
	public enum IpaGrapheme
	{
		#region Consonant
		//0b1111 mask
		

		Bilabial = 1,
		Labiodental,
		Dental,
		Alveolar,
		Postalveolar,
		Retroflex,
		AlveoloPalatal,
		Palatal,
		Palatalalveolar,
		PalatalVelar,
		Velar,
		Uvular,
		Pharyn,
		Epiglottal,
		Glottal,
		
		//0b11110000 mask
		
		Plosive = 1 << 4,
		Nasal = 2 << 4,
		Trill= 3 << 4,
		TapFlap = 4 << 4,		
		Fricative = 5 << 4,
		Approximant = 6 << 4,
		Affricate = 7 << 4,
		LateralFricative = 8 << 4,
		LateralApproximant = 9 << 4,
		LateralFlap = 10 << 4,
		Click = 11 << 4,
		Implosive = 12 << 4,
		
		//0b1,0000,0000
		Voiceless = 1 << 8,
		#endregion
		
		#region vowel
		//0b1110,0000,0000
		
		Close = 1<<9,
		NearClose = 2 << 9,
		CloseMid = 3 << 9,
		Mid = 4 << 9,
		OpenMid = 5 << 9,
		NearOpen = 6 << 9,
		Open = 7 << 9,
		
		//0b11,0000,0000,000
		
		Front = 1 << 12,
		Central = 2 << 12,
		Back = 3 << 12,	
		
		Rounded = 1 << 14,
		#endregion
		
		#region non-letter
		//suprasegmental 3 bits
		PrimaryStress = 1 << 15,
		SecondaryStress = 2 << 15,
		SyllableBreak = 3 << 15,
		MinorGroup = 4 << 15,
		MajorGroup = 5<< 15,
		Linking = 6 << 15,
		
		//tone bar 3 bits
		ExtraHighTone = 5 << 18,
		HighTone = 4 << 18,
		MidTone = 3 << 18,
		LowTone = 2 << 18,
		ExtraLowTone = 1 << 18,
		//tone ordinal 3 bits
		FirstTone = 1 << 21,
		SecondTone = 2 << 21,
		ThirdTone = 3 << 21,
		FourthTone = 4 << 21,
		FifthTone = 5 << 21,
		SixthTone = 6 << 21,
		
		//global tone 3 bits
		DownStep = 1 << 24,
		Upstep = 2 << 24,
		GlobalRise = 3 << 24,
		GlobalFall = 4 << 24,
		#endregion
		
		Ligature = 1 << 27,
		MergedWithDiacritic = 1<<28,
		
		
		#region consonant-letters
		ʘ = Click|Bilabial|Voiceless,
		ǀ = Click|Dental|Voiceless,
		ǂ = Click|Palatalalveolar|Voiceless,
		//! ??
		ǁ = Click|Alveolar|Voiceless,
		ɓ = Implosive|Bilabial,
		ɗ = Implosive|Dental,
		ʄ = Implosive| Palatal,		
		ɠ = Implosive|Velar,
		ʛ = Implosive|Uvular,
		m = Nasal|Bilabial,
		ɱ = Nasal|Labiodental,
		n = Nasal|Alveolar,
		ɳ = Nasal|Retroflex,
		ɲ = Nasal|Palatal,
		ŋ = Nasal|Velar,
		ɴ = Nasal|Uvular,
//		t̪ = Plosive|Dental|Voiceless,
//		d̪ = Plosive|Dental,
		p = Plosive|Bilabial|Voiceless,
		b = Plosive|Bilabial,
		ʈ = Plosive|Retroflex|Voiceless,
		ɖ = Plosive|Retroflex,
		c = Plosive|Palatal|Voiceless,
		ɟ = Plosive|Palatal,
		k = Plosive|Velar|Voiceless,
		g = Plosive|Velar,
		q = Plosive|Uvular|Voiceless,
		ɢ = Plosive|Uvular,
		ʡ = Plosive|Epiglottal,
		ʔ = Plosive|Glottal|Voiceless,
		ɸ = Fricative|Bilabial|Voiceless,
		β = Fricative|Bilabial,
		f = Fricative|Labiodental|Voiceless,
		v = Fricative|Labiodental,		
		θ = Fricative|Dental|Voiceless,
		ð = Fricative|Dental,
		s = Fricative|Alveolar|Voiceless,
		z = Fricative|Alveolar,
		ʃ = Fricative|Postalveolar|Voiceless,
		ʒ = Fricative|Postalveolar,
		ʂ = Fricative|Retroflex|Voiceless,
		ʐ = Fricative|Retroflex,
		ɕ = Fricative|AlveoloPalatal|Voiceless,
		ʑ = Fricative|AlveoloPalatal,
		ç = Fricative|Palatal|Voiceless,
		ʝ = Fricative|Palatal,
		x = Fricative|Velar|Voiceless,
		ɣ = Fricative|Velar,
		χ = Fricative|Uvular|Voiceless, 
		ʁ = Fricative|Uvular,
		\u0127 = Fricative|Pharyn|Voiceless,//ħ
		ʕ = Fricative|Pharyn,
		ʜ = Fricative|Epiglottal|Voiceless,
		ʢ = Fricative|Epiglottal,
		h = Fricative|Glottal|Voiceless,
		ɦ = Fricative|Glottal,
		ɧ = Fricative|PalatalVelar|Voiceless,
		ʦ = Affricate|Alveolar|Voiceless|Ligature,
		ʣ = Affricate|Alveolar|Ligature,
		ʧ = Affricate|Postalveolar|Voiceless|Ligature,
		ʤ = Affricate|Postalveolar|Ligature,
		ʨ = Affricate|AlveoloPalatal|Voiceless|Ligature,
		ʥ = Affricate|AlveoloPalatal|Ligature,
//		ʈ‍͡ʂ = Affricate|Retroflex|Voiceless,
//		ɖ‍͡ʐ = Affricate|Retroflex,
		ɬ = LateralFricative|Voiceless|Alveolar,
		\u026E = LateralFricative|Alveolar, //ɮ
		l = LateralApproximant|Alveolar,
		ɭ = LateralApproximant | Retroflex,  
		\u028E = LateralApproximant|Palatal,  //ʎ
		ʟ = LateralApproximant|Velar,
		w = Approximant|Bilabial,
		ʋ = Approximant|Labiodental,
		ɹ = Approximant|Alveolar,
		ɻ = Approximant|Retroflex,
		j = Approximant|Palatal,		
		ɰ = Approximant|Velar,
		ɺ = LateralFlap|Alveolar,
		ʙ = Trill|Bilabial,
		r = Trill|Alveolar,
		ʀ = Trill|Uvular,
		я = Trill|Epiglottal,
		ɾ = TapFlap|Alveolar,//
		ɽ = TapFlap|Retroflex,
		#endregion
		
		#region vowel-letters
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
		#endregion
	}
}


























