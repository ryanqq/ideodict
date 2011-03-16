using System;
namespace IPA
{
	[Flags]
	public enum IpaDiacritic:ulong
	{
		None = 0,
		Voiceless = 1,
		Voiced = 1<<1,
		Aspirated = 1<<2,
		MoreRounded = 1<<3,
		LessRounded = 1<<4,
		Advanced = 1<<5,
		Retracted = 1<<6,
		Centralized = 1<<7,
		MidCentralized = 1<<8,
		Syllabic = 1<<9,
		NonSyllabic = 1<<10,
		Rhoticity = 1<<11,
		Breathy = 1<<12,
		Creaky = 1<<13,
		Linguolabial = 1<<14,
		Labalized = 1<<15,
		Palatalized = 1<<16,
		Velarized= 1<<17,
		Pharyngealized = 1<<18,
		VelarizedOrPharyngealized = 1<<19,
		Raised = 1<<20,
		Lowerd =1<<21,
		AdvancedTongueRoot = 1<<22,
		RetractedTongueRoot = 1<<23,		
		Dental = 1<<24,
		Apical = 1<<25,
		Laminal = 1<<26,
		Nasalized = 1<<27,
		NasalRelease = 1<<28,
		LateralRelease = 1<<29,
		NoAudibleRelease =1<<30,		
		Ejective = (ulong)1<<31,
		ExtraHighTone = (ulong)5<<32,
		HighTone = (ulong)4<<32,
		MidTone = (ulong)3<<32,
		LowTone = (ulong)2<<32,
		ExtraLowTone = (ulong)1<<32,
		RiseTone = (ulong)6<<32,
		FallTon = (ulong)7<<32,
		Long = (ulong)1 <<35,
		HalfLong = (ulong)2 <<35,
		ExtraShort = (ulong)3 << 36,
		Merged = (ulong)1 << 38,
		
	}
}





















