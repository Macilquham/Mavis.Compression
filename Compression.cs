using System.Text;

namespace Mavis.Compression
{
    public class Compression
    {
        public byte[] Compress(string input)
        {

            var chars = input.AsSpan();
            Dictionary<char, int> characterCount = BuildCharacterCount(input);

            return [0b1000111];
        }

        private Dictionary<char, int> BuildCharacterCount(string input)
        {
            var inputAsSpan = input.AsSpan();
            Dictionary<char, int> characterCount = [];

            foreach(var c in inputAsSpan) 
            { 
                characterCount[c] = characterCount.GetValueOrDefault(c, 0) + 1;
            }

            return characterCount;
        }

        public string Decompress(byte[] input)
        {
            return ASCIIEncoding.UTF8.GetString(input);
        }
    }
}
