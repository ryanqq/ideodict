using System;
using NUnit.Framework;
using IdeoDict.Controller.Building;
namespace IdeoDict.Test
{
	[TestFixture()]
	public class BuilderTest
	{
		const string json = "test.json";
		
		[Test()]
		public void TestBuilderChooser ()
		{
			var bm = MetaFactory.Load(json);
			Assert.AreEqual(BookType.Dictionary, bm.Type);
			Assert.AreEqual("csv",bm.Medium);
			Assert.AreEqual("some book",bm.Title);
			var bb = bm.BookBuilder;
			Assert.IsTrue(bb is CsvDictBuilder);
			
		}
	}
}

