import java.util.List;

public class EcommerceSearchDemo {
    public static void main(String[] args) {
        System.out.println("=== E-Commerce Search Engine Demo ===\n");

        EcommerceSearchEngine store = new EcommerceSearchEngine();

        store.addProduct(new Product(1, "Laptop Pro", "Electronics", 1299.99, 5,
            new String[]{"computer", "portable", "business"}));
        store.addProduct(new Product(2, "Wireless Mouse", "Electronics", 29.99, 50,
            new String[]{"computer", "peripheral", "wireless"}));
        store.addProduct(new Product(3, "USB-C Cable", "Electronics", 15.99, 100,
            new String[]{"cable", "charging", "portable"}));
        store.addProduct(new Product(4, "Office Chair", "Furniture", 199.99, 10,
            new String[]{"office", "comfortable", "ergonomic"}));
        store.addProduct(new Product(5, "Standing Desk", "Furniture", 399.99, 8,
            new String[]{"office", "standing", "adjustable"}));
        store.addProduct(new Product(6, "Monitor Stand", "Furniture", 49.99, 30,
            new String[]{"office", "monitor", "adjustable"}));

        System.out.println("1. Search by Name (containing 'Laptop'):");
        List<Product> foundProducts = store.searchByName("Laptop");
        foundProducts.forEach(item -> System.out.println("   " + item));

        System.out.println("\n2. Search by Category ('Electronics'):");
        foundProducts = store.searchByCategory("Electronics");
        foundProducts.forEach(item -> System.out.println("   " + item));

        System.out.println("\n3. Search by Price Range ($30 - $500):");
        foundProducts = store.searchByPriceRange(30, 500);
        foundProducts.forEach(item -> System.out.println("   " + item));

        System.out.println("\n4. Search by Tag ('office'):");
        foundProducts = store.searchByTag("office");
        foundProducts.forEach(item -> System.out.println("   " + item));

        System.out.println("\n5. Advanced Search (Furniture, $40 - $250):");
        foundProducts = store.advancedSearch("", "Furniture", 40, 250);
        foundProducts.forEach(item -> System.out.println("   " + item));

        System.out.println("\n✓ Search engine supports multiple search criteria!");
    }
}
