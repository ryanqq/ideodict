
#if DEBUG
using System;
using NUnit.Framework;
namespace Unihan
{
	[TestFixture()]
	public class UnihanTest
	{
		
		
		[Test]
		public void CodePointTest()
		{
			string extb = "𢐜";
			CodePoint cp =extb.CodePointAt(0);
			string s = cp;
			Assert.AreEqual(extb,s);
			
			Assert.AreEqual(0x2241C,cp.Scalar);
			
			Assert.IsTrue(cp.IsSurrogatePair);
			
			string s1 ="【";
			CodePoint cp1 = s1.CodePointAt(0);
			Assert.AreEqual(s1,(string)cp1);
			Assert.IsFalse(cp1.IsSurrogatePair);
		}
		
		[Test]
		public void UniBlockTest()
		{
			var extb ="𢐜".CodePointAt(0);
			char ipa = 'ɨ';
			Assert.AreEqual(UniBlock.CJKUnifiedIdeographsExtensionB, Uni.BlockOf(extb));
			Assert.AreEqual(UniBlock.IPAExtensions,Uni.BlockOf(ipa));
			Assert.AreEqual(UniBlock.Undefined,Uni.BlockOf(0x10EEE));
			Assert.AreEqual(new IntSpan(0x1D100,0x1D1FF),Uni.SpanOf(UniBlock.MusicalSymbols));
		}
		
		[Test]
		public void RadicalTest()
		{
			var li = "宇".CodePointAt(0);
			var rLi = Radical.Of(li);
			Assert.AreEqual('宀',rLi.KangxiName);
			Assert.AreEqual(3,rLi.RestStrokes);
			Assert.AreEqual('水',Radical.Of('洪').KangxiName);
			Assert.AreEqual('弓',Radical.Of("𢐜".CodePointAt(0)).Name);
			var r2 = new Radical(57,true,9);
			var cp2 = new CodePoint('弻');
			Assert.IsTrue(r2.GetHanziList().Contains(cp2));
		}
	}
}

#endif
