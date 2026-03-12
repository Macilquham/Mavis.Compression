using Xunit;

namespace Mavis.Compression
{
    
    public class CompressionTests
    {
        [Fact]
        public void TestOne() {
            var compression = new Compression();
            var compressed = compression.Compress("foobar");
        }
    }
}
