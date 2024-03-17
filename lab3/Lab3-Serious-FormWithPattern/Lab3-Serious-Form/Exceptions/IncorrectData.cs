using System.Runtime.Serialization;

namespace Lab3_Serious_Form.Exceptions
{
    [Serializable]
    internal class IncorrectData : Exception
    {
        public IncorrectData()
        {
        }

        public IncorrectData(string? message) : base(message)
        {
        }

        public IncorrectData(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IncorrectData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}