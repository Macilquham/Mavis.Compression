using Xunit;

namespace Mavis.Compression
{
    
    public class CompressionTests
    {
        [Fact]
        public void TestOne() {
            var compression = new Compression();
            compression.Decompress([]);
            var compressed = compression.Compress("aaaaaabbbbbbccccccddddddeeeeffffghhhhijjjjjkkkkkkkkkkkkkkkkkkkkklllmmm");
        }
    }
}
