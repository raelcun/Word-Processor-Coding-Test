using System.Collections.Generic;
using US.WordProcessor.Internal;

namespace US.WordProcessor
{
   public interface ICorrectionFinder
   {
      IEnumerable<Correction> Find(Paragraph paragraph);
   }
}