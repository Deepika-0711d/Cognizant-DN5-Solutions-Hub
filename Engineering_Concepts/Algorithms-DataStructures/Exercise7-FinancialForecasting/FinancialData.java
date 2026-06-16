public class FinancialData {
    private int monthNumber;
    private double monthlyRevenue;
    private double monthlyExpenses;
    private double netProfit;

    public FinancialData(int monthNumber, double monthlyRevenue, double monthlyExpenses) {
        this.monthNumber = monthNumber;
        this.monthlyRevenue = monthlyRevenue;
        this.monthlyExpenses = monthlyExpenses;
        this.netProfit = monthlyRevenue - monthlyExpenses;
    }

    public int getMonth() {
        return monthNumber;
    }

    public double getRevenue() {
        return monthlyRevenue;
    }

    public double getExpenses() {
        return monthlyExpenses;
    }

    public double getNetProfit() {
        return netProfit;
    }

    public double getProfitMargin() {
        return monthlyRevenue > 0 ? (netProfit / monthlyRevenue) * 100 : 0;
    }

    @Override
    public String toString() {
        return String.format("Month %d: Revenue=$%.2f, Expenses=$%.2f, Profit=$%.2f, Margin=%.2f%%",
            monthNumber, monthlyRevenue, monthlyExpenses, netProfit, getProfitMargin());
    }
}
