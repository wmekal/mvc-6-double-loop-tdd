﻿namespace TestStack.BDDfy.Processors
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnusedExampleException : Exception
    {
        public UnusedExampleException(ExampleValue unusedValue) :
            base(string.Format("Example Column '{0}' is unused, all examples should be consumed by the test (have you misspelt a field or property?)\r\n\r\n"
            + "If this is not the case, raise an issue at https://github.com/TestStack/TestStack.BDDfy/issues.", unusedValue.Header))
        { }

        protected UnusedExampleException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}