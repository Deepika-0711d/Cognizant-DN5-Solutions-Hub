public class GooglePayPayment implements PaymentProcessor {
    private String registeredPhone;
    private String googleId;

    public GooglePayPayment(String registeredPhone, String googleId) {
        this.registeredPhone = registeredPhone;
        this.googleId = googleId;
    }

    @Override
    public void processPayment(double transactionAmount) {
        System.out.println("Processing Google Pay Payment: $" + transactionAmount);
        System.out.println("Phone Number: " + registeredPhone);
        System.out.println("Google Account ID: " + googleId);
    }

    @Override
    public String getPaymentType() {
        return "Google Pay";
    }

    @Override
    public boolean validatePayment() {
        return registeredPhone.length() >= 10 && !googleId.isEmpty();
    }
}
