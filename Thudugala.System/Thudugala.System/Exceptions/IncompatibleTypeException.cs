using System;

namespace Thudugala.System.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class IncompatibleTypeException : InvalidOperationException
    {
        /// <summary>
        /// 
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// 
        /// </summary>
        public Type DestinationType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        public IncompatibleTypeException(
            Type sourceType,
            Type destinationType)
            : base($"Cannot convert object of type '{sourceType.GetType().FullName}' to '{destinationType.GetType().FullName}'")
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="destinationType"></param>
        /// <exception cref="IncompatibleTypeException"></exception>
        public static void ThrowIfMismatch(Type sourceType,
            Type destinationType)
        {
            if (sourceType != destinationType)
            {
                throw new IncompatibleTypeException(sourceType, destinationType);
            }
        }
    }
}
