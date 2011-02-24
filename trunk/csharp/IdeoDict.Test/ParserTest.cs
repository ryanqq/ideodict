using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using IdeoDict.Controller.Building;
namespace IdeoDict.Test
{
	[TestFixture]
	public class ParserTest
	{
		string csv1 = "one ,two , three \n"+
                      "1 , 2 ,		3\n"+
                      "blue, 藍 , 紅\n";
		string csv2 =	"one	|	two|three\n"+
	                    "1|2|	3\n"+
	                    "	blue|藍	|紅\n";
		string[] numbers = {"one","two","three"};
		string[] arabics = {"1","2","3"};
		string[] colors ={"blue","藍","紅"};
		[SetUp]
		public void Init(){
			
		}
		[Test]
		public void TestColumns()
		{
			StringReader sr1 = new StringReader(csv1);
			StringReader sr2 = new StringReader(csv2);
			var parser1 = new CsvParser(sr1,',');
			var parser2 = new CsvParser(sr2);
			Assert.AreEqual(numbers,parser1.Columns);
			Assert.AreEqual(numbers,parser2.Columns);
		}
		[Test]
		public void TestIEnumCount ()
		{
			
			StringReader sr1 = new StringReader(csv1);
			StringReader sr2 = new StringReader(csv2);
			var parser1 = new CsvParser(sr1,',');
			var parser2 = new CsvParser(sr2);

			
			IEnumerable<List<string>> en1 = parser1;
			IEnumerable<List<string>> en2 = parser2;
			
			Assert.IsTrue(en1.GetEnumerator().MoveNext());
			Assert.AreEqual(2, en2.Count());
			Assert.AreEqual(1,en1.Count());
			
		}
	}
}

