using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace US.WordProcessor
{
   public class Sentence   
      : IEnumerable<string>
   {
      private readonly string _source;
      
      public Sentence(string source)
      {
         _source = source.Trim();         
      }

      public IEnumerator<string> GetEnumerator()
      {
         return _source.Split(' ')
            .ToList()
            .GetEnumerator();
      }

      public override string ToString()
      {
         return _source;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}