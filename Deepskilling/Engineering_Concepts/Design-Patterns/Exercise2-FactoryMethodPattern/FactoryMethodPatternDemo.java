public class FactoryMethodPatternDemo {
    public static void main(String[] args) {
        System.out.println("=== Factory Method Pattern Demo ===\n");

        System.out.println("1. Creating Credit Card Payment:");
        PaymentProcessor cardProcessor = PaymentFactory.createPaymentProcessor(
            "CREDIT_CARD",
            "1234567890123456",
            "John Doe"
        );
        if (cardProcessor != null && cardProcessor.validatePayment()) {
            cardProcessor.processPayment(99.99);
            System.out.println("Payment Type: " + cardProcessor.getPaymentType());
        }

        System.out.println("\n2. Creating PayPal Payment:");
        PaymentProcessor paypalProcessor = PaymentFactory.createPaymentProcessor(
            "PAYPAL",
            "john.doe@example.com",
            "ACC123456789"
        );
        if (paypalProcessor != null && paypalProcessor.validatePayment()) {
            paypalProcessor.processPayment(149.99);
            System.out.println("Payment Type: " + paypalProcessor.getPaymentType());
        }

        System.out.println("\n3. Creating Google Pay Payment:");
        PaymentProcessor googlePayProcessor = PaymentFactory.createPaymentProcessor(
            "GOOGLE_PAY",
            "9876543210",
            "google_acc_id_123"
        );
        if (googlePayProcessor != null && googlePayProcessor.validatePayment()) {
            googlePayProcessor.processPayment(49.99);
            System.out.println("Payment Type: " + googlePayProcessor.getPaymentType());
        }

        System.out.println("\n✓ Factory Pattern allows creating different payment types without client knowing implementation!");
    }
}
