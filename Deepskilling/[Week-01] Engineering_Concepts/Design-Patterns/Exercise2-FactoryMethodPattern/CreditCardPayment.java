public class CreditCardPayment implements PaymentProcessor {
    private String cardNumber;
    private String holderName;

    public CreditCardPayment(String cardNumber, String holderName) {
        this.cardNumber = cardNumber;
        this.holderName = holderName;
    }

    @Override
    public void processPayment(double transactionAmount) {
        System.out.println("Processing Credit Card Payment: $" + transactionAmount);
        System.out.println("Card Holder: " + holderName);
        System.out.println("Card: ****" + cardNumber.substring(cardNumber.length() - 4));
    }

    @Override
    public String getPaymentType() {
        return "Credit Card";
    }

    @Override
    public boolean validatePayment() {
        return cardNumber.length() == 16;
    }
}
