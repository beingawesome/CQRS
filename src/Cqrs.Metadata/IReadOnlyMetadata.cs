namespace Cqrs.Metadata
{
    public interface IReadOnlyMetadata
    {
        TMetadata Get<TMetadata>();
    }
}
