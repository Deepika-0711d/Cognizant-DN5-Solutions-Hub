public interface PaymentProcessor {
    void processPayment(double transactionAmount);
    String getPaymentType();
    boolean validatePayment();
}
