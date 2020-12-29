namespace Restaurant_Manager
{
    public static class Constants
    {
        public static string fileName1= "stock.txt";
        public static string fileName2 = "menu.txt";
        public static string fileName3 = "orders.txt";
        public static string menuMessage = "Welcome to Contact Manager! \nWhat would you like to do? \n[1] Add new products to stock \n[2] Update stock \n[3] Delete stock \n[4] View all the stock";
        public static string stockUpdateMessage = "\nWhich stock (Id) would you like to update?";
        public static string stockChoiceMessage = "\nWhat would you like to update?\n[1] Name\n[2] Portion Count\n[3] Unit\n[4] Portion Size\n[5] Everything";
        public static string stockDeleteMessage = "\nWhich stock (Id) would you like to delete?";
        public static string duplicateNameMessage = "\nStock name already exists.";
        public static string invalidParameterMessage = "\nEntered parameters are invalid!";
        public static string idNotFoundMessage = "\nStock Id not found!";
        public static string idMessage = "Id: ";
        public static string nameMessage = "Name: ";    
        public static string portionCountMessage = "Portion Count: ";
        public static string unitMessage = "Unit: ";
        public static string portionSizeMessage = "Portion size: ";
    }
}
