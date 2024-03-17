namespace Lab3_Serious_Form.Models
{
    public sealed record ReviewModel(
        string Name,
        string Email, 
        string Message, 
        string PhoneNumber);
}