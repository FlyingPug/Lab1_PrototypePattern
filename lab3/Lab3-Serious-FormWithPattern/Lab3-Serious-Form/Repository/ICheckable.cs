namespace Lab3_Serious_Form.Repository
{
    // элемент, который будет смотреть как реализовать тип проверики
    public interface ICheckable
    {
        void Accept(IVisitor visitor);
    }
}
