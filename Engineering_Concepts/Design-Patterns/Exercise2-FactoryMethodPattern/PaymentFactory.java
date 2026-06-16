public class PaymentFactory {
    
    public static PaymentProcessor createPaymentProcessor(String paymentType, String... credentials) {
        switch (paymentType.toUpperCase()) {
            case "CREDIT_CARD":
                if (credentials.length >= 2) {
                    return new CreditCardPayment(credentials[0], credentials[1]);
                }
                break;
            case "PAYPAL":
                if (credentials.length >= 2) {
                    return new PayPalPayment(credentials[0], credentials[1]);
                }
                break;
            case "GOOGLE_PAY":
                if (credentials.length >= 2) {
                    return new GooglePayPayment(credentials[0], credentials[1]);
                }
                break;
            default:
                System.out.println("Unknown payment type: " + paymentType);
        }
        return null;
    }
}
