using System;
namespace Unihan
{
	[Flags]
	public enum Tone
	{
		Level=1, Rising=2, Departing=4, Entering=8,Yin=16,Yang=32,Upper=64,Lower=128,Middle=256
	}
}

