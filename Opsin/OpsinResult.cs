using System.Collections.Generic;
using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// Whether parsing the chemical name was successful, encountered problems or was unsuccessful.
    /// If the result is not <see cref="OpsinResultStatus.Failure"/> then a structure has been generated.
    /// </summary>
    public enum OpsinResultStatus
    {
        /// <summary>
        /// OPSIN successfully interpreted the name
        /// </summary>
        Success = 0,
        /// <summary>
        /// OPSIN interpreted the name but detected a potential problem e.g. could not interpret stereochemistry.
        /// </summary>
        /// <remarks>
        /// Currently, by default, WARNING is not used as stereochemistry failures are treated as failures.
        /// In the future, ambiguous chemical names may produce WARNING.
        /// </remarks>
        Warning = 1,
        /// <summary>
        /// OPSIN failed to interpret the name
        /// </summary>
        Failure = 2,
    }

    /// <summary>
    /// Holds the structure OPSIN has generated from a name
    /// </summary>
    /// <remarks>
    /// Additionally holds a status code for whether name interpretation was successful.
    /// </remarks>
    public class OpsinResult
    {
        internal readonly JavaOpsin::OpsinResult _o;

        internal OpsinResult(JavaOpsin::OpsinResult o)
        {
            _o = o;
        }

        /// <summary>
        /// An enum indicating whether interpreting the chemical name was successful
        /// </summary>
        /// <remarks>
        /// If an issue was identified but a chemical structure could be still be deduced the status is <see cref="OpsinResultStatus.Warning"/>
        /// </remarks>
        public virtual OpsinResultStatus Status
            => (OpsinResultStatus)_o.getStatus().ordinal();

        /// <summary>
        /// A message explaining why generation of a molecule from the name failed
        /// </summary>
        /// <remarks>
        /// This string will be blank when no problems were encountered
        /// </remarks>
        public virtual string Message
            => _o.getMessage();

        /// <summary>
        /// The chemical name that this OpsinResult was generated from
        /// </summary>
        public virtual string ChemicalName
            => _o.getChemicalName();

        /// <summary>
        /// Generates the CML corresponding to the molecule described by the name
        /// </summary>
        /// <remarks>
        /// If name generation failed i.e. the OPSIN_RESULT_STATUS is FAILURE then null is returned
        /// </remarks>
        /// <returns>Chemical Markup Language as a <see cref="string"/></returns>
        public virtual string GetCml()
            => _o.getCml();

        /// <summary>
        /// Generates the CML corresponding to the molecule described by the name
        /// </summary>
        /// <remarks>
        /// If name generation failed i.e. the OPSIN_RESULT_STATUS is FAILURE then null is returned
        /// The CML is indented
        /// </remarks>
        /// <returns>Idented Chemical Markup Language as a <see cref="string"/></returns>
        public virtual string GetPrettyPrintedCml()
            => _o.getPrettyPrintedCml();

        /// <summary>
        /// Generates the SMILES corresponding to the molecule described by the name
        /// </summary>
        /// <remarks>
        /// If name generation failed i.e. the OPSIN_RESULT_STATUS is FAILURE then null is returned
        /// </remarks>
        /// <returns>SMILES as a <see cref="string"/></returns>
        public virtual string GetSmiles()
            => _o.getSmiles();

        /// <summary>
        /// Experimental function that generates the extended SMILES corresponding to the molecule described by the name
        /// </summary>
        /// <remarks>
        /// If name generation failed i.e. the OPSIN_RESULT_STATUS is FAILURE then null is returned
        /// If the molecule doesn't utilise any features made possible by extended SMILES this is equivalent to <see cref="GetSmiles"/>
        /// </remarks>
        /// <returns>Extended SMILES as a <see cref="string"/></returns>
        public virtual string GetExtendedSmiles()
            => _o.getExtendedSmiles();

        /// <summary>
        /// A list of warnings encountered when the result was <see cref="OpsinResultStatus.Warning"/>
        /// </summary>
        public virtual IReadOnlyList<OpsinWarning> Warnings 
            => new ReadOnlyListWrapper<OpsinWarning>(_o.getWarnings());

        /// <summary>
        /// Convenience method to check if one of the associated OPSIN warnings was <see cref="OpsinWarningType.AppearsAmbiguous"/>
        /// </summary>
        /// <value>true if name appears to be ambiguous</value>
        public virtual bool NameAppearsToBeAmbiguous 
            => _o.nameAppearsToBeAmbiguous();

        /// <summary>
        /// Convenience method to check if one of the associated OPSIN warnings was <see cref="OpsinWarningType.StereochemistryIgnored"/>
        /// </summary>
        /// <value>true if stereochemistry was ignored to interpret the name</value>
        public virtual bool StereochemistryIgnored 
            => _o.stereochemistryIgnored();
    }
}
