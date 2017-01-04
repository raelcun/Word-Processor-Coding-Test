namespace US.WordProcessor.Internal
{
   internal class DefinitionReader
   {
      private readonly Dictionary _dictionary;
      private readonly SentenceReader _sentence;
      
      public DefinitionReader(Dictionary dictionary, SentenceReader sentence)
      {
         _dictionary = dictionary;
         _sentence = sentence;
      }

      public bool MoveNext()
      {
         return _sentence.MoveNext();
      }

      public void Reset()
      {
         _sentence.Reset();
      }

      public string CurrentWord => _sentence.Current;

      public string PreviousWord => _sentence.Previous;

      public string NextWord => _sentence.Next;
      
      public Definition CurrentDefinition => _dictionary.Define(_sentence.Current);

      public Definition PreviousDefinition => _sentence.HasPrevious
         ? _dictionary.Define(_sentence.Previous)
         : new Definition(WordType.NotAvailable, _sentence.Current, "");


      public Definition NextDefinition => _sentence.HasNext
         ? _dictionary.Define(_sentence.Next)
         : new Definition(WordType.NotAvailable, _sentence.Current, "");      
   }
}
