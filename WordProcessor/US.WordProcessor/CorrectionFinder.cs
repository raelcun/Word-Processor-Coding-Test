using System;
using System.Collections.Generic;
using System.Linq;
using US.WordProcessor.Internal;

namespace US.WordProcessor
{
    internal class CorrectionFinder
        : ICorrectionFinder
    {
        private static readonly List<Func<Sentence, IEnumerable<Correction>>> CorrectionFuncs =
            new List<Func<Sentence, IEnumerable<Correction>>>
            {
                CorrectProperOwnership,
                CorrectAposMistake,
                CorrectContractionMissingApos
            };

        public static readonly Dictionary Dictionary = new Dictionary();

        public IEnumerable<Correction> Find(Paragraph paragraph)
        {
            /* run each sentence in the paragraph through a list of correction functions
             * and flatten the results into a single list of corrections */
            return paragraph
                .Select(sentence => CorrectionFuncs.Select(correctionFunc => correctionFunc(sentence)))
                .Flatten().Flatten();
        }

        
        // TODO FUTURE: Extract correctable interface from correction functions and test interface implementations in addition to finder
        #region Correction Functions

        public static IEnumerable<Correction> CorrectAposMistake(Sentence sentence) =>
            CorrectSentence(sentence, dr =>
            {
                var curWord = dr.CurrentWord;
                var curDef = dr.CurrentDefinition;

                if (curDef.Type == WordType.Noun && curWord.Contains("'"))
                    return new Correction(CorrectionType.IncorrectNounApostrophe, sentence.ToString(), curWord);
                return null;
            });

        public static IEnumerable<Correction> CorrectProperOwnership(Sentence sentence) =>
            CorrectSentence(sentence, dr =>
            {
                var prevWord = dr.PreviousWord;
                var curWord = dr.CurrentWord;
                var curDef = dr.CurrentDefinition;
                var nextDef = dr.NextDefinition;

                if (curWord == null) return null;

                if (curDef.Type == WordType.ProperNoun && curDef.Suffix == "s" && !curWord.EndsWith("'s") &&
                    nextDef?.Type == WordType.Noun)
                    return new Correction(CorrectionType.OwnershipByAProperNoun, sentence.ToString(), curWord);
                if (prevWord == "is" && curDef.Type == WordType.ProperNoun && curDef.Suffix == "s" &&
                    !curWord.EndsWith("'s"))
                    return new Correction(CorrectionType.OwnershipByAProperNoun, sentence.ToString(), curWord);

                return null;
            });

        public static IEnumerable<Correction> CorrectContractionMissingApos(Sentence sentence) =>
            CorrectSentence(sentence, dr =>
            {
                var curDef = dr.CurrentDefinition;

                if (curDef.Type == WordType.Contraction && !curDef.Word.Contains("'"))
                    return new Correction(CorrectionType.MissingContractionApostrophe, sentence.ToString(), curDef.Word);

                return null;
            });

        private static IEnumerable<Correction> CorrectSentence(Sentence sentence,
            Func<DefinitionReader, Correction> correctionTransform)
        {
            var dr = new DefinitionReader(Dictionary, new SentenceReader(sentence));
            var corrections = new List<Correction>();

            while (dr.MoveNext())
            {
                var correction = correctionTransform(dr);
                if (correction != null) corrections.Add(correction);
            }
            return corrections;
        }

        #endregion Correction Functions
    }
}