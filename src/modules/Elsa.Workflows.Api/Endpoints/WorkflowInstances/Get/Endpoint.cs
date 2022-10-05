using System.Threading;
using System.Threading.Tasks;
using Elsa.Abstractions;
using Elsa.Workflows.Management.Services;

namespace Elsa.Workflows.Api.Endpoints.WorkflowInstances.Get;

public class Get : ElsaEndpoint<Request, Response, WorkflowInstanceMapper>
{
    private readonly IWorkflowInstanceStore _store;

    public Get(IWorkflowInstanceStore store)
    {
        _store = store;
    }

    public override void Configure()
    {
        Get("/workflow-instances/{id}");
        ConfigurePermissions("read:workflow-instances");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var workflowInstance = await _store.FindByIdAsync(request.Id, cancellationToken);

        if (workflowInstance == null)
            await SendNotFoundAsync(cancellationToken);
        else
            await SendOkAsync(Map.FromEntity(workflowInstance), cancellationToken);
    }
}