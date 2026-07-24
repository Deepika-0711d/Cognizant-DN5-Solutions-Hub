public class Product {
    private int productId;
    private String productName;
    private String productCategory;
    private double productPrice;
    private int stockQuantity;
    private String[] productTags;

    public Product(int productId, String productName, String productCategory, double productPrice, int stockQuantity, String[] productTags) {
        this.productId = productId;
        this.productName = productName;
        this.productCategory = productCategory;
        this.productPrice = productPrice;
        this.stockQuantity = stockQuantity;
        this.productTags = productTags;
    }

    public int getId() {
        return productId;
    }

    public String getName() {
        return productName;
    }

    public String getCategory() {
        return productCategory;
    }

    public double getPrice() {
        return productPrice;
    }

    public int getQuantity() {
        return stockQuantity;
    }

    public String[] getTags() {
        return productTags;
    }

    @Override
    public String toString() {
        return "Product{" +
                "id=" + productId +
                ", name='" + productName + '\'' +
                ", category='" + productCategory + '\'' +
                ", price=" + productPrice +
                ", quantity=" + stockQuantity +
                '}';
    }
}
