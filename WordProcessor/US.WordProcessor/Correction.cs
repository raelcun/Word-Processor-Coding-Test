namespace US.WordProcessor
{
   public class Correction
   {      
      public Correction(CorrectionType type, string sentence, string word)
      {
         Type = type;
         Sentence = sentence;
         Word = word;
      }

      public readonly CorrectionType Type;
      public readonly string Sentence;
      public readonly string Word;
   }
}