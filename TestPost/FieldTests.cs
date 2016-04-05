using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Post.Tests
{
    [TestClass]
    public class FieldTests
    {

        [TestMethod]
        public void Parse_ValidField_Single()
        {
            //arrange
            ParseValidTest("{!ChapterTitle}", new Field("ChapterTitle", Field.Type.SINGLE));
        }

        [TestMethod]
        public void Parse_ValidField_Auto()
        {
            ParseValidTest("{$ChapterNumber}", new Field("ChapterNumber", Field.Type.AUTO));
        }

        [TestMethod]
        public void Parse_ValidField_Area()
        {
            //arrange
            ParseValidTest("{#AuthorNote}", new Field("AuthorNote", Field.Type.AREA));

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidField_Throws()
        {
            string field = "(~~~)";
            Field result = Field.Parse(field);
        }

        private void ParseValidTest(string textField, Field expected)
        {
            //act
            Field result = Field.Parse(textField);

            //assert
            Assert.AreEqual(result, expected);
        }

    }
}
