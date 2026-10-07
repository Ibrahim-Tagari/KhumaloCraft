using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

public static class OrderActivities
{
    [FunctionName("UpdateInventory")]
    public static async Task UpdateInventory([ActivityTrigger] OrderInfo orderInfo, ILogger log)
    {
        // Logic to update inventory
        log.LogInformation($"Updating inventory for ProductID: {orderInfo.ProductID}");
        await Task.CompletedTask;
    }

    [FunctionName("ProcessPayment")]
    public static async Task ProcessPayment([ActivityTrigger] OrderInfo orderInfo, ILogger log)
    {
        // Logic to process payment
        log.LogInformation($"Processing payment for Order: {orderInfo.ProductID}");
        await Task.CompletedTask;
    }

    [FunctionName("ConfirmOrder")]
    public static async Task ConfirmOrder([ActivityTrigger] OrderInfo orderInfo, ILogger log)
    {
        // Logic to confirm order
        log.LogInformation($"Confirming order for ProductID: {orderInfo.ProductID}");
        await Task.CompletedTask;
    }
}
