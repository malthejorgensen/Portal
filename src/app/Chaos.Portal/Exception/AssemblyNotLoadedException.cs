﻿using System.Runtime.Serialization;

namespace CHAOS.Portal.Exception
{
    public class AssemblyNotLoadedException : System.Exception
    {
        public AssemblyNotLoadedException()
        {
        }

        public AssemblyNotLoadedException(string message)
            : base(message)
        {
        }

        public AssemblyNotLoadedException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

		protected AssemblyNotLoadedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
