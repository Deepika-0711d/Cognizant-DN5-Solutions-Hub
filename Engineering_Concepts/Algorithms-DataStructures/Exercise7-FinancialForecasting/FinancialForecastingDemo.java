public class FinancialForecastingDemo {
    public static void main(String[] args) {
        System.out.println("=== Financial Forecasting Engine Demo ===\n");

        FinancialForecaster analyzer = new FinancialForecaster();

        analyzer.addHistoricalData(new FinancialData(1, 100000, 60000));
        analyzer.addHistoricalData(new FinancialData(2, 105000, 62000));
        analyzer.addHistoricalData(new FinancialData(3, 112000, 65000));
        analyzer.addHistoricalData(new FinancialData(4, 118000, 68000));
        analyzer.addHistoricalData(new FinancialData(5, 125000, 70000));
        analyzer.addHistoricalData(new FinancialData(6, 130000, 72000));
        analyzer.addHistoricalData(new FinancialData(7, 140000, 75000));
        analyzer.addHistoricalData(new FinancialData(8, 145000, 78000));
        analyzer.addHistoricalData(new FinancialData(9, 152000, 80000));
        analyzer.addHistoricalData(new FinancialData(10, 160000, 82000));
        analyzer.addHistoricalData(new FinancialData(11, 168000, 85000));
        analyzer.addHistoricalData(new FinancialData(12, 175000, 88000));

        System.out.println("Historical Financial Data:");
        analyzer.getHistoricalData().forEach(data -> System.out.println("  " + data));

        System.out.println("\n3-Month Moving Average: $" + String.format("%.2f", analyzer.calculateMovingAverage(3)));
        System.out.println("6-Month Moving Average: $" + String.format("%.2f", analyzer.calculateMovingAverage(6)));

        System.out.println("\nGrowth Rate (Month 1 to Month 12): " + 
            String.format("%.2f%%", analyzer.calculateGrowthRate(0, 11)));

        System.out.println("\nTrend Analysis: " + analyzer.getTrendAnalysis());

        System.out.println("Average Profit Margin: " + 
            String.format("%.2f%%", analyzer.getAverageProfitMargin()));

        System.out.println("\n--- Forecast for Month 13 ---");
        System.out.println("Forecasted Revenue: $" + 
            String.format("%.2f", analyzer.forecastNextMonthRevenue()));
        System.out.println("Forecasted Expenses: $" + 
            String.format("%.2f", analyzer.forecastNextMonthExpenses()));
        System.out.println("Forecasted Profit: $" + 
            String.format("%.2f", analyzer.forecastNextMonthProfit()));

        System.out.println("\n✓ Financial forecasting supports trend analysis and predictions!");
    }
}
