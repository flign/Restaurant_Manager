namespace Restaurant_Manager
{
    public static class Constants
    {
        public static string fileName1= "stock.csv";
        public static string fileName2 = "menu.csv";
        public static string fileName3 = "orders.csv";
        public static string mainMenuMessage = "Welcome to Restaurant Manager!\nWhat would you like to manage?\n[1] Stock\n[2] Restaurant Menu \n[3] Orders \n[4] Exit";
        public static string stockMenuMessage = "\nWhat would you like to do?\n[1] Add new products to stock\n[2] Update stock \n[3] Delete stock \n[4] View all the stock\n[5] Return to main menu";
        public static string stockUpdateMessage = "\nWhich stock (Id) would you like to update?";
        public static string stockChoiceMessage = "\nWhat would you like to update?\n[1] Name\n[2] Portion Count\n[3] Unit\n[4] Portion Size\n[5] Everything\n[6] Return";
        public static string stockDeleteMessage = "\nWhich stock (Id) would you like to delete?";
        public static string menuMessage = "\nWhat would you like to do?\n[1] Add new items to menu\n[2] Update menu \n[3] Delete menu item\n[4] View all menu\n[5] Return to main menu";
        public static string menuUpdateMessage = "\nWhich menu item (Id) would you like to update?";
        public static string menuChoiceMessage = "\nWhat would you like to update?\n[1] Name\n[2] Products\n[3] Everything\n[4] Return";
        public static string menuDeleteMessage = "\nWhich menu item (Id) would you like to delete?";
        public static string ordersMenuMessage = "\nWhat would you like to do?\n[1] Create new order\n[2] View all orders \n[3] Delete order\n[4] Return to main menu";
        public static string orderDeleteMessage = "\nWhich order (Id) would you like to delete?";
        public static string duplicateNameMessage = "\nName already exists.";
        public static string invalidParameterMessage = "Entered parameters are invalid!";
        public static string invalidInputMessage = "Invalid input!";
        public static string idNotFoundMessage = "\nId not found!";
        public static string successMessage = "\nSUCCESS!";
        public static string idMessage = "Id: ";
        public static string nameMessage = "Name: "; 
        public static string portionCountMessage = "Portion Count: ";
        public static string unitMessage = "Unit: ";
        public static string portionSizeMessage = "Portion size: ";
        public static string productsMessage = "Products: ";
        public static string menuItemsMessage = "Menu items: ";
        public static string containsDuplicates = "Contains duplicates";
        public static string notEnoughStockMessage = "Not enough stock, order declined";
    }
}
