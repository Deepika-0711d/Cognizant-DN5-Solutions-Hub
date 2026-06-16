import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class EcommerceSearchEngine {
    private List<Product> allProducts;

    public EcommerceSearchEngine() {
        this.allProducts = new ArrayList<>();
    }

    public void addProduct(Product item) {
        allProducts.add(item);
    }

    public List<Product> searchByName(String searchName) {
        return allProducts.stream()
            .filter(item -> item.getName().toLowerCase().contains(searchName.toLowerCase()))
            .collect(Collectors.toList());
    }

    public List<Product> searchByCategory(String categoryName) {
        return allProducts.stream()
            .filter(item -> item.getCategory().equalsIgnoreCase(categoryName))
            .collect(Collectors.toList());
    }

    public List<Product> searchByPriceRange(double minPrice, double maxPrice) {
        return allProducts.stream()
            .filter(item -> item.getPrice() >= minPrice && item.getPrice() <= maxPrice)
            .collect(Collectors.toList());
    }

    public List<Product> searchByTag(String searchTag) {
        return allProducts.stream()
            .filter(item -> {
                for (String tag : item.getTags()) {
                    if (tag.equalsIgnoreCase(searchTag)) {
                        return true;
                    }
                }
                return false;
            })
            .collect(Collectors.toList());
    }

    public List<Product> advancedSearch(String searchName, String categoryName, double minPrice, double maxPrice) {
        return allProducts.stream()
            .filter(item -> item.getName().toLowerCase().contains(searchName.toLowerCase()))
            .filter(item -> item.getCategory().equalsIgnoreCase(categoryName))
            .filter(item -> item.getPrice() >= minPrice && item.getPrice() <= maxPrice)
            .filter(item -> item.getQuantity() > 0)
            .collect(Collectors.toList());
    }

    public List<Product> getAllProducts() {
        return new ArrayList<>(allProducts);
    }
}
