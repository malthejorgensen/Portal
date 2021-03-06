namespace Chaos.Portal.Core.Bindings.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using CHAOS.Extensions;
    using CHAOS.Serialization.Standard.String;

    using Chaos.Portal.Core.Exceptions;

    public class DateTimeParameterBinding : IParameterBinding
    {
        public object Bind(IDictionary<string, string> parameters, ParameterInfo parameterInfo)
        {
            if( parameters.ContainsKey( parameterInfo.Name ) && !string.IsNullOrEmpty( parameters[ parameterInfo.Name ] ) )
                return new StringSerializer().Deserialize<DateTime>( parameters[ parameterInfo.Name ], true );

            if( parameterInfo.ParameterType.IsNullable() )
                return null;

            throw new ParameterBindingMissingException("The parameter is missing, and the type isnt nullable");
        }
    }
}
