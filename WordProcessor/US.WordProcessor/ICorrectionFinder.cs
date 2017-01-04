using System.Collections.Generic;

namespace US.WordProcessor
{
    public interface ICorrectionFinder
    {
        IEnumerable<Correction> Find(Paragraph paragraph);
    }
}