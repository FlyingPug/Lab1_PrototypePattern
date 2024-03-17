using System.Runtime.Serialization;

namespace Lab3_Serious_Form.Exceptions
{
    [Serializable]
    internal class IncorrectEmail : Exception
    {
        public IncorrectEmail(string name) : base($"{name}")
        { }
    }
}