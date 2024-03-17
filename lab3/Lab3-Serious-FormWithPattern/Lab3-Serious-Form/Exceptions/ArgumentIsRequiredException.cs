namespace Lab3_Serious_Form.Exceptions
{
    public class ArgumentIsRequiredException : Exception
    {
        public ArgumentIsRequiredException(string name) : base($"{name} is required")
        {}
    }
}
