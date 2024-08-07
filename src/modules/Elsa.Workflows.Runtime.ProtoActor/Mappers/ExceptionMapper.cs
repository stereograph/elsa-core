using Elsa.Workflows.State;
using ProtoExceptionState = Elsa.Workflows.Runtime.ProtoActor.ProtoBuf.ExceptionState;

namespace Elsa.Workflows.Runtime.ProtoActor.Mappers;

public class ExceptionMapper
{
    public ExceptionState? Map(ProtoExceptionState? exception)
    {
        if (exception == null)
            return null;

        return new ExceptionState(Type.GetType(exception.Type)!, exception.Message, exception.StackTrace, exception.InnerException != null ? Map(exception.InnerException) : null);
    }

    public ProtoExceptionState? Map(ExceptionState? exception)
    {
        if (exception == null)
            return null;

        return new ProtoExceptionState
        {
            Type = exception.Type.AssemblyQualifiedName,
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            InnerException = exception.InnerException != null ? Map(exception.InnerException) : null
        };
    }
}