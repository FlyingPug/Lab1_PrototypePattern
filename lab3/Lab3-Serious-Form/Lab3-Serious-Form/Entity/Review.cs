namespace Lab3_Serious_Form.Entity
{
    public class Review : PersistableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}