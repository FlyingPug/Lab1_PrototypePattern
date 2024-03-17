using System.Runtime.Serialization;

namespace Lab3_Serious_Form.Exceptions
{
    [Serializable]
    internal class IncorrectPhoneNumber : Exception
    {
        public IncorrectPhoneNumber(string name) : base($"{name}")
        { }
    }
}