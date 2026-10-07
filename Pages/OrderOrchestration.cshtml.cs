using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

public static class OrderOrchestration
{
    [FunctionName("OrderOrchestration")]
    public static async Task RunOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var orderInfo = context.GetInput<OrderInfo>();

        // Step 1: Update Inventory
        await context.CallActivityAsync("UpdateInventory", orderInfo);

        // Step 2: Process Payment
        await context.CallActivityAsync("ProcessPayment", orderInfo);

        // Step 3: Confirm Order
        await context.CallActivityAsync("ConfirmOrder", orderInfo);
    }
}
