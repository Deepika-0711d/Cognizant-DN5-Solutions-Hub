public class PayPalPayment implements PaymentProcessor {
    private String userEmail;
    private String paypalAccountId;

    public PayPalPayment(String userEmail, String paypalAccountId) {
        this.userEmail = userEmail;
        this.paypalAccountId = paypalAccountId;
    }

    @Override
    public void processPayment(double transactionAmount) {
        System.out.println("Processing PayPal Payment: $" + transactionAmount);
        System.out.println("PayPal Email: " + userEmail);
        System.out.println("Account ID: " + paypalAccountId);
    }

    @Override
    public String getPaymentType() {
        return "PayPal";
    }

    @Override
    public boolean validatePayment() {
        return userEmail.contains("@") && !paypalAccountId.isEmpty();
    }
}
