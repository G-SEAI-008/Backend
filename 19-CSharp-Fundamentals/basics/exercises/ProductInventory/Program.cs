using Controllers;
using Infrastructure;
using Service;
using Services;
using UI;


using var dbContext = new ProductInventoryContext();

dbContext.Database.EnsureCreated();

// in memory
// IProductInventoryService service = new ProductInventoryService();

// db - sqlite
IProductInventoryService service = new ProductDbService(dbContext);

ProductController controller = new(service);
Menu menu = new(controller);

menu.Run();