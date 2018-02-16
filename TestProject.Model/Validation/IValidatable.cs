namespace TestProject.Model
{
    public interface IValidatable
    {
        bool IsValid { get; }
        ValidationErrors ValidationErrors { get; }
    }
}