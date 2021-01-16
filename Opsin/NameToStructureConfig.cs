using System;
using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// Allows OPSIN to be configured e.g. enable processing of radicals
    /// </summary>
    /// <example>
    /// var n2sConfig = new NameToStructureConfig();
    /// n2sconfig.AllowRadicals = true;
    /// nts.ParseChemicalName(chemicalName, n2sConfig)
    /// //where nts is an instance of NameToStructure
    /// </example>
    public class NameToStructureConfig : ICloneable
    {
        internal readonly JavaOpsin::NameToStructureConfig _o;

        internal NameToStructureConfig(JavaOpsin::NameToStructureConfig o)
        {
            _o = o;
        }

        /// <summary>
        /// Constructs a NameToStructureConfig with default settings
        /// </summary>
        public NameToStructureConfig()
            : this(new JavaOpsin::NameToStructureConfig())
        {
        }

        /// <summary>
        /// Whether radicals allowed? e.g. should fragments such as phenyl be interpretable.
        /// </summary>
        public virtual bool AllowRadicals
        {
            get => _o.isAllowRadicals();
            set => _o.setAllowRadicals(value);
        }

        /// <summary>
        /// Should radicals be output as wildcard atoms e.g. [*]CC for ethyl (as opposed to [CH2]C).
        /// Note that if this is set to true InChIs cannot be generated.
        /// </summary>
        public virtual bool OutputRadicalsAsWildCardAtoms
        {
            get => _o.isOutputRadicalsAsWildCardAtoms();
            set => _o.setOutputRadicalsAsWildCardAtoms(value);
        }

        /// <summary>
        /// Whether OPSIN should attempt reverse parsing to more accurately determine why parsing failed.
        /// </summary>
        public virtual bool DetailedFailureAnalysis
        {
            get => _o.isDetailedFailureAnalysis();
            set => _o.setDetailedFailureAnalysis(value);
        }

        /// <summary>
        /// Whether acids without the word "acid" interpretable e.g. should "acetic" be interpretable.
        /// </summary>

        public virtual bool InterpretAcidsWithoutTheWordAcid
        {
            get => _o.allowInterpretationOfAcidsWithoutTheWordAcid();
            set => _o.setInterpretAcidsWithoutTheWordAcid(value);
        }


        /// <summary>
        /// Whether if OPSIN cannot understand the stereochemistry in a name whether OPSIN's result should be a warning
        /// and structure with incomplete stereochemistry, or should failure be returned (Default).
        /// </summary>
        public virtual bool WarnRatherThanFailOnUninterpretableStereochemistry
        {
            get => _o.warnRatherThanFailOnUninterpretableStereochemistry();
            set => _o.setWarnRatherThanFailOnUninterpretableStereochemistry(value);
        }

        /// <summary>
        /// <see cref="NameToStructureConfig"/> with default settings.
        /// </summary>
        public static NameToStructureConfig DefaultConfigInstance { get; }
            = new NameToStructureConfig(JavaOpsin::NameToStructureConfig.getDefaultConfigInstance());

        object ICloneable.Clone()
            => Clone();

       /// <summary>
       /// Clone this object.
       /// </summary>
       /// <returns>Cloned object.</returns>
       public virtual NameToStructureConfig Clone()
            => new NameToStructureConfig(_o.clone());

    }
}
