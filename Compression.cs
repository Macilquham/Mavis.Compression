using System.Text;

namespace Mavis.Compression
{
    public record HuffmanNode
    {
       public char Character {  get; set; }
        
       public int Count {get; set; }

       public HuffmanNode Left {get;set;}

       public HuffmanNode Right {get;set;}
        
       public bool IsLeafNode { get{ return Right == null && Left == null } }

    }

    public class Compression
    {
        public byte[] Compress(string input)
        {
            var chars = input.AsSpan();
            Dictionary<char, int> characterCount = BuildCharacterCount(input);
            
            var pq = new PriorityQueue<HuffmanNode, int>();
            foreach(var item in characterCount)
            {
                pq.Enqueue(new HuffmanNode{ Character = item.Key, Count = item.Value }, item.Value);
            }

            while(pq.Count > 1)
            {
                var dequeuedItemOne = pq.Dequeue();
                var dequeuedItemTwo = pq.Dequeue();
                var parentNode = new HuffmanNode{Count = dequeuedItemOne.Count + dequeuedItemTwo.Count, Left = dequeuedItemOne, Right = dequeuedItemTwo };
                pq.Enqueue(parentNode, parentNode.Count);
                
            }
            var huffmanTree = pq.Dequeue();
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
           // IEnumerable<IDD> dd = [new LCIDD(), new BPIDD()];
            
            //IPagedResultDto<IDD> d = new PagedResultDto<LCIDD>();
            return ASCIIEncoding.UTF8.GetString(input);
        }
    }
}

public class Node
{
    public Node Left {get;set;}

    public Node Right {get;set;}

    public int Frequency {get;set;}

    public char Character {get;set;}

    
}

//public interface IDD{}
//public class LCIDD : IDD
//{

//}

//public class BPIDD :IDD{}


//public class PagedResultDto<T> : IPagedResultDto<T>
//{
//    public IEnumerable<T> Result {get;}
//}


//public interface IPagedResultDto<out T>
//{
//    public IEnumerable<T> Result {get;}
//}