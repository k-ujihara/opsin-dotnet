using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// A wrapper for the results from parsing a chemical name or part of a chemical name through ParseRule
    /// </summary>
    public class ParseRulesResults
    {
        private readonly JavaOpsin::ParseRulesResults _o;

        internal ParseRulesResults(JavaOpsin::ParseRulesResults o)
        {
            _o = o;
        }

        ///// <summary>
        ///// One ParseTokens object is returned for each possible interpretation of a chemical name
        ///// </summary>
        ///// <remarks>
        ///// If none of the name can be interpreted this list will be empty
        ///// </remarks>
        ///// <param name="parseTokensList"></param>
        ///// <param name="uninterpretableName"></param>
        ///// <param name="unparseableName"></param>
        //public ParseRulesResults(IReadOnlyList<ParseTokens> parseTokensList, string uninterpretableName, string unparseableName);


        ///// <summary>
        ///// One ParseTokens object is returned for each possible interpretation of a chemical name
        ///// </summary>
        ///// <remarks>
        ///// If none of the name can be interpreted this list will be empty
        ///// </remarks>
        //public virtual IReadOnlyList<ParseTokens> ParseTokensList;

        /// <summary>
        /// The substring of the name that could not be classified into a substituent/full/functionalTerm
        /// e.g. in ethyl-2H-fooarene  "2H-fooarene" will be returned
        /// </summary>
        public virtual string UninterpretableName 
            => _o.getUninterpretableName();

        /// <summary>
        /// The substring of the name that could not be tokenised at all.
        /// </summary>
        /// <remarks>
        /// This will always be the same or shorter than the uninterpetable substring of name
        /// e.g. in ethyl-2H-fooarene  "fooarene" will be returned
        /// </remarks>
        public virtual string UnparseableName 
            => _o.getUnparseableName();
    }
}
