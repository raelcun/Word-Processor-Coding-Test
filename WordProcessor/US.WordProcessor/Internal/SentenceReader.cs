using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace US.WordProcessor.Internal
{
   [DebuggerDisplay("Current: {Current}")]
   internal class SentenceReader     
   {
      private readonly List<string> _source;
      private int _index;
      
      public SentenceReader(Sentence source)
      {
         _source = source.ToList();
         _index = -1;
      }
      
      public bool MoveNext()
      {
         return ++_index < _source.Count;
      }

      public void Reset()
      {
         _index = 0;
      }

      public string Current => _source[_index];

      public bool HasPrevious => _index - 1 > -1;
      
      public bool HasNext => _index + 1 < _source.Count;
      
      public string Previous => HasPrevious
         ? _source[_index - 1]
         : null;

      public string Next => HasNext
         ? _source[_index + 1]
         : null;      
   }
}