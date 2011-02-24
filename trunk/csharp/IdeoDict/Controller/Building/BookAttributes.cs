using System;
namespace IdeoDict.Controller.Building
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class MediumAttribute:Attribute
	{
		public string Medium;
		public MediumAttribute(string medium){Medium = medium;}
		public override string ToString ()
		{
			return  Medium;
		}
	}
	
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TypeOfBookAttribute:Attribute
	{
		public BookType BookType;
		public TypeOfBookAttribute(BookType bookType){BookType = bookType;}
		public override string ToString ()
		{
			return BookType.ToString();
		}
	}
}

