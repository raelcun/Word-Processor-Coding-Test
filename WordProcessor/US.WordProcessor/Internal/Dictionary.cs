using System;
using System.Collections.Generic;

namespace US.WordProcessor.Internal
{
   internal class Dictionary
   {
      private static readonly Dictionary<string, Definition> KnownWords
         = new Dictionary<string, Definition>(StringComparer.CurrentCultureIgnoreCase)
            {
               // pronouns

               {"susan", new Definition(WordType.ProperNoun, "Susan", "")},
               {"susans", new Definition(WordType.ProperNoun, "Susan", "s")},
               {"susan's", new Definition(WordType.ProperNoun, "Susan", "s")},
               {"susans'", new Definition(WordType.ProperNoun, "Susan", "s")},

               {"barry", new Definition(WordType.ProperNoun, "Barry", "")},
               {"barrys", new Definition(WordType.ProperNoun, "Barry", "s")},
               {"barry's", new Definition(WordType.ProperNoun, "Barry", "s")},
               {"barrys'", new Definition(WordType.ProperNoun, "Barry", "s")},

               // nouns

               {"hat", new Definition(WordType.Noun, "Hat", "")},
               {"airplane", new Definition(WordType.Noun, "Airplane", "")},
               {"airplanes", new Definition(WordType.Noun, "Airplane", "s")},
               {"airplane's", new Definition(WordType.Noun, "Airplane", "s")},
               {"airplanes'", new Definition(WordType.Noun, "Airplane", "s")},
            };
      
      public Definition Define(string word)
      {
         return KnownWords.ContainsKey(word)
            ? KnownWords[word]
            : new Definition(WordType.NotAvailable, word, "");
      }      
   }
}