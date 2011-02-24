using System;
using NUnit.Framework;
using IdeoDict.Util;
using IdeoDict.Controller.Building;
using System.Linq;
using System.Reflection;
namespace IdeoDict.Test
{
	[TestFixture()]
	public class UtilTest
	{
		Assembly asm;
		[SetUp]
		public void Init()
		{
			asm = Assembly.GetExecutingAssembly();
		}
		
		[Medium("html")]
		[TypeOfBook(BookType.Book)]
		class MyClass{public const string Str = "MyField";}
		
		
		[Test()]
		public void TestCase ()
		{
			Type t1 = asm.GetTypes()
				.First(t=>t.HasAttr<MediumAttribute>());
			Type t2 = asm.GetTypes()
				.First(t=>t.HasAttr<MediumAttribute>(a=>a.Medium == "html"));
			TypeOfBookAttribute att  = typeof(MyClass).GetAttr<TypeOfBookAttribute>();
			
			Assert.IsNotNull(t1);
			Assert.IsNotNull(t2);
			Assert.AreEqual(att.BookType , BookType.Book);
			
		}
	}
}

