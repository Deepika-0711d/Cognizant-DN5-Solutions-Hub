public class SingletonPatternDemo {
    public static void main(String[] args) {
        System.out.println("=== Singleton Pattern Demo ===\n");

        DatabaseConnection primaryDb = DatabaseConnection.getInstance();
        System.out.println("First instance created: " + primaryDb);
        primaryDb.connect();

        DatabaseConnection secondaryDb = DatabaseConnection.getInstance();
        System.out.println("Second instance retrieved: " + secondaryDb);

        if (primaryDb == secondaryDb) {
            System.out.println("\n✓ Both references point to the SAME object (Singleton works!)");
        } else {
            System.out.println("\n✗ Different objects created (Singleton failed!)");
        }

        System.out.println("\nExecuting query through primaryDb: " + primaryDb.executeQuery("SELECT * FROM users"));
        System.out.println("Executing query through secondaryDb: " + secondaryDb.executeQuery("SELECT * FROM products"));

        primaryDb.disconnect();
        System.out.println("\nConnection status: " + secondaryDb.isConnected());
    }
}
