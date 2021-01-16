using System;
using JavaOpsin = uk.ac.cam.ch.wwmm.opsin;

namespace Opsin
{
    /// <summary>
    /// Thrown during finite-state parsing.
    /// </summary>
#pragma warning disable CA1032 // Implement standard exception constructors
#pragma warning disable CA2237 // Mark ISerializable types with serializable
    public class ParsingException : Exception
#pragma warning restore CA2237 // Mark ISerializable types with serializable
#pragma warning restore CA1032 // Implement standard exception constructors
    {
        internal readonly JavaOpsin::ParsingException _o;

        internal ParsingException(JavaOpsin::ParsingException o)
        {
            _o = o;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string StackTrace => _o.StackTrace;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Message => _o.Message;
    }
}
