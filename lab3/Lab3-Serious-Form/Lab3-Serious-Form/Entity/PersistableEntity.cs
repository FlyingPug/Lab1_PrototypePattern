namespace Lab3_Serious_Form.Entity
{
    public abstract class PersistableEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
