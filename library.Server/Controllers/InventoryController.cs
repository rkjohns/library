using library.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly AppDbContext _appDbContext;

        public InventoryController(ILogger<InventoryController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }


        [HttpPut("EditInventory")]
        public async Task<ActionResult> EditInventory(int id, [FromBody] Inventory updatedInventory)
        {
            try
            {
                var inventory = await _appDbContext.Inventories.FindAsync(id);

                if (inventory == null)
                {
                    return NotFound();
                }

                if (!inventory.IsCheckedOut && inventory.CustomerId != 0)
                {
                    inventory.CustomerId = updatedInventory.CustomerId;
                    inventory.IsCheckedOut = true;
                    inventory.CheckoutDate = updatedInventory.CheckoutDate;
                }

                _appDbContext.Inventories.Update(inventory);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to checkout this book.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
