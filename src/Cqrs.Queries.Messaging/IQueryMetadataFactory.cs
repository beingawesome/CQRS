using Cqrs.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Queries.Messaging
{
    public interface IQueryMetadataFactory
    {
        IMetadata Create<TQuery, TResult>(TQuery command)
            where TQuery : Query<TResult>;
    }
}
