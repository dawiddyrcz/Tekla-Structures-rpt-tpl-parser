using System;

namespace Tekla.Structures.RPT
{
    public class RPTParserException : Exception
    {
        public RPTParserException() : base()
        {

        }

        public RPTParserException(string message) : base(message)
        {

        }

        public RPTParserException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
