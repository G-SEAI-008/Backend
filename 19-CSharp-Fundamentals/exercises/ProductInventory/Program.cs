using Controllers;
using Service;
using Services;
using UI;


ProductInventoryService service = new();
// ProductDB db = new();
ProductController controller = new(service);
Menu menu = new(controller);

menu.Run();