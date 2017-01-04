using System.Diagnostics;

namespace US.WordProcessor.Internal
{
   [DebuggerDisplay("{Type} : {Word} : {Suffix}")]
   internal class Definition
   {
      public Definition(WordType type, string word, string suffix)
      {
         Type = type;
         Word = word;
         Suffix = suffix;
      }

      public readonly WordType Type;
      public readonly string Word;
      public readonly string Suffix;
   }
}