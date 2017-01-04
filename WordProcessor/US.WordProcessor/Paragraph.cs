using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace US.WordProcessor
{
   public class Paragraph
      : IEnumerable<Sentence>
   {
      private readonly List<Sentence> _sentences;

      public Paragraph(string source)
      {
         _sentences = source.Split('.')
            .Where(IsNotEmpty)
            .Select(ToSentence)
            .ToList();
      }
      
      public IEnumerator<Sentence> GetEnumerator()
      {
         return _sentences.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      private static Sentence ToSentence(string source)
      {
         return new Sentence(source);
      }

      private static bool IsNotEmpty(string value)
      {
         return !string.IsNullOrWhiteSpace(value);
      }
   }
}