using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// The "master" class, to turn a name into a structure.
    /// </summary>
    public class NameToStructure
    {
        /// <summary>
        /// Instance of this class.
        /// </summary>
        public static NameToStructure Instance { get; } = new NameToStructure();

        internal readonly JavaOpsin::NameToStructure _o;

        private NameToStructure()
        {
            _o = JavaOpsin::NameToStructure.getInstance();
        }

        /// <summary>
        /// The version of the OPSIN library
        /// </summary>
        public static string Version
            => JavaOpsin::NameToStructure.getVersion();

        /// <summary>
        /// Convenience method for converting a name to CML with OPSIN's default options
        /// </summary>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>A CML element, containing the parsed molecule, or null if the name was uninterpretable.</returns>
        public virtual string ParseToCML(string name)
            => _o.parseToCML(name);

        /// <summary>
        /// Convenience method for converting a name to SMILES with OPSIN's default options
        /// </summary>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>A SMILES string describing the parsed molecule, or null if the name was uninterpretable.</returns>
        public virtual string ParseToSmiles(string name)
            => _o.parseToSmiles(name);

        /// <summary>
        /// Parses a chemical name, returning an OpsinResult which represents the molecule.
        /// </summary>
        /// <remarks>
        /// This object contains in the status whether the name was parsed successfully
        /// A message which may contain additional information if the status was warning/failure
        /// The OpsinResult has methods to generate a SMILES or CML representation
        /// For InChI, the OpsinResult should be given to the NameToInchi class
        /// </remarks>
        /// <param name="name">The chemical name to parse.</param>
        /// <returns>OpsinResult</returns>
        public virtual OpsinResult ParseChemicalName(string name)
            => new OpsinResult(_o.parseChemicalName(name));

        /// <summary>
        /// Parses a chemical name, returning an OpsinResult which represents the molecule.
        /// </summary>
        /// <remarks>
        /// This object contains in the status whether the name was parsed successfully
        /// A message which may contain additional information if the status was warning/failure
        /// CML and SMILES representations may be retrieved directly from the object
        /// InChI may be generate using NameToInchi
        /// </remarks>
        /// <param name="name">The chemical name to parse.</param>
        /// <param name="n2sConfig">Options to control how OPSIN interprets the name.</param>
        /// <returns>OpsinResult</returns>
        public virtual OpsinResult ParseChemicalName(string name, NameToStructureConfig n2sConfig)
            => new OpsinResult(_o.parseChemicalName(name, n2sConfig._o));

        /// <summary>
        /// Opsin parser for recognition/parsing of a chemical word
        /// </summary>
        /// <remarks>
        /// This can be used to determine whether a word can be interpreted as being part of a chemical name.
        /// Just because a word can be split into tokens does not mean the word constitutes a valid chemical name
        /// e.g.ester is interpretable but is not in itself a chemical name
        /// </remarks>
        public static ParseRules OpsinParser 
            => new ParseRules(JavaOpsin::NameToStructure.getOpsinParser());
    }
}
