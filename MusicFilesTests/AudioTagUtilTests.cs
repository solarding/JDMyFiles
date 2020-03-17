using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JD.MF.Tests
{
    [TestClass()]
    public class AudioTagUtilTests
    {
        [TestMethod()]
        public void ParseFilenameTest()
        {
            string input = "【抖音歌曲】要不要買菜 - 下山 [動態歌詞x高音質] ";
            var tag = AudioTagUtil.ParseFilename(input);
            Assert.AreEqual(tag.Title, "下山");
            Assert.AreEqual(tag.Artist, "要不要买菜");

        }
    }
}