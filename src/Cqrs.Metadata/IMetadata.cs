namespace Cqrs.Metadata
{
    public interface IMetadata : IReadOnlyMetadata
    {
        void Set<TMetadata>(TMetadata metadata);
    }
}
