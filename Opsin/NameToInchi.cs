using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// Allows the conversion of OPSIN's output into (Std)InChIs or StdInChIKeys
    /// </summary>
    /// <remarks>
    /// Also can be used, as a convenience method, to directly convert chemical names to(Std)InChIs or StdInChIKeys
    /// </remarks>
    public class NameToInchi
    {
        private readonly JavaOpsin::NameToInchi _o;

        /// <summary>
        /// Constructor.
        /// </summary>
        public NameToInchi()
        {
            _o = new JavaOpsin::NameToInchi();
        }

        /// <summary>
        /// Parses a chemical name, returning an InChI representation of the molecule
        /// </summary>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>An InChI string, containing the parsed molecule, or null if the molecule would not parse.</returns>
        public virtual string ParseToInchi(string name) 
            => _o.parseToInchi(name);

        /// <summary>
        /// Parses a chemical name, returning a StdInChI representation of the molecule
        /// </summary>
        /// <remarks>
        /// Note that chemical names typically specify an exact tautomer which is not representable in StdInChI.
        /// Use <see cref="ParseToInchi(string)"/> if you want to represent the exact tautomer using a fixed hydrogen layer.
        /// </remarks>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>A StdInChI string, containing the parsed molecule, or null if the molecule would not parse.</returns>
        public virtual string ParseToStdInchi(string name) 
            => _o.parseToStdInchi(name);

        /// <summary>
        /// Parses a chemical name, returning a StdInChIKey for the molecule
        /// like StdInChI, StdInChIKeys aim to not be tautomer specific
        /// </summary>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>A StdInChIKey string or null if the molecule would not parse.</returns>
        public virtual string ParseToStdInchiKey(string name) 
            => _o.parseToStdInchiKey(name);

        /// <summary>
        /// Converts an OPSIN result to InChI. Null is returned if this conversion fails
        /// </summary>
        /// <param name="result">Result object to convert.</param>
        /// <returns>InChI</returns>
        public static string ConvertResultToInChI(OpsinResult result)
            => JavaOpsin::NameToInchi.convertResultToInChI(result._o);

        /// <summary>
        /// Converts an OPSIN result to StdInChI. Null is returned if this conversion fails.
        /// </summary>
        /// <remarks>
        /// Note that chemical names typically specify an exact tautomer which is not representable in StdInChI
        /// Use <see cref="ConvertResultToInChI(OpsinResult)"/> if you want to represent the exact tautomer using a fixed hydrogen layer
        /// </remarks>
        /// <param name="result">Result object to convert.</param>
        /// <returns>InChI</returns>
        public static string ConvertResultToStdInChI(OpsinResult result)
            => JavaOpsin::NameToInchi.convertResultToStdInChI(result._o);

        /// <summary>
        /// Converts an OPSIN result to a StdInChIKey. Null is returned if this conversion fails
        /// like StdInChI, StdInChIKeys aim to not be tautomer specific
        /// </summary>
        /// <param name="result">Result object to convert.</param>
        /// <returns>InChIKey</returns>
        public static string ConvertResultToStdInChIKey(OpsinResult result)
            => JavaOpsin::NameToInchi.convertResultToStdInChIKey(result._o);
    }
}
