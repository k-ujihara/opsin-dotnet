using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// Instantiate via <see cref="NameToStructure.OpsinParser"/>
    /// </summary>
    /// <remarks>
    /// Performs finite-state allocation of roles("annotations") to tokens:
    /// The chemical name is broken down into tokens e.g.ethyl --&gt;eth yl by applying the chemical grammar in regexes.xml
    /// The tokens eth and yl are associated with a letter which is referred to here as an annotation which is the role of the token.
    /// These letters are defined in regexes.xml and would in this case have the meaning alkaneStem and inlineSuffix
    /// 
    /// The chemical grammar employs the annotations associated with the tokens when deciding what may follow what has already been seen
    /// e.g.you cannot start a chemical name with yl and an optional e is valid after an arylGroup
    /// </remarks>
    public class ParseRules
    {
        private readonly JavaOpsin::ParseRules _o;

        internal ParseRules(JavaOpsin::ParseRules o)
        {
            _o = o;
        }

        /// <summary>
        /// Determines the possible annotations for a chemical word
        /// </summary>
        /// <remarks>
        /// Returns a list of parses and how much of the word could not be interpreted
        /// e.g.usually the list will have only one parse and the string will equal ""
        /// For something like ethyloxime. The list will contain the parse for ethyl and the string will equal "oxime" as it was unparsable
        /// For something like eth no parses would be found and the string will equal "eth"
        /// </remarks>
        /// <param name="chemicalWord"></param>
        /// <returns>Results of parsing</returns>
        /// <exception cref="ParsingException">Thrown during finite-state parsing.</exception>
        public virtual ParseRulesResults GetParses(string chemicalWord)
        {
            try
            {
                return new ParseRulesResults(_o.getParses(chemicalWord));
            }
            catch (JavaOpsin::ParsingException e)
            {
                throw new ParsingException(e);
            }
        }
    }
}
