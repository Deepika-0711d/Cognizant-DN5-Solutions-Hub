import java.util.ArrayList;
import java.util.List;

public class FinancialForecaster {
    private List<FinancialData> records;

    public FinancialForecaster() {
        this.records = new ArrayList<>();
    }

    public void addHistoricalData(FinancialData entry) {
        records.add(entry);
    }

    public double calculateMovingAverage(int windowSize) {
        if (records.size() < windowSize) {
            return 0;
        }
        double totalRevenue = 0;
        for (int i = records.size() - windowSize; i < records.size(); i++) {
            totalRevenue += records.get(i).getRevenue();
        }
        return totalRevenue / windowSize;
    }

    public double calculateGrowthRate(int startIndex, int endIndex) {
        if (startIndex < 0 || endIndex >= records.size() || startIndex >= endIndex) {
            return 0;
        }
        double startingRevenue = records.get(startIndex).getRevenue();
        double endingRevenue = records.get(endIndex).getRevenue();
        return ((endingRevenue - startingRevenue) / startingRevenue) * 100;
    }

    public double forecastNextMonthRevenue() {
        if (records.size() < 2) {
            return 0;
        }
        double totalIncrease = 0;
        for (int i = 1; i < records.size(); i++) {
            double monthlyIncrease = records.get(i).getRevenue() - records.get(i - 1).getRevenue();
            totalIncrease += monthlyIncrease;
        }
        double averageIncrease = totalIncrease / (records.size() - 1);
        return records.get(records.size() - 1).getRevenue() + averageIncrease;
    }

    public double forecastNextMonthExpenses() {
        if (records.size() < 2) {
            return 0;
        }
        double sumExpenses = 0;
        for (FinancialData entry : records) {
            sumExpenses += entry.getExpenses();
        }
        return sumExpenses / records.size();
    }

    public double forecastNextMonthProfit() {
        return forecastNextMonthRevenue() - forecastNextMonthExpenses();
    }

    public String getTrendAnalysis() {
        if (records.size() < 2) {
            return "Insufficient data for analysis";
        }

        double latestRevenue = records.get(records.size() - 1).getRevenue();
        double priorRevenue = records.get(records.size() - 2).getRevenue();
        double difference = latestRevenue - priorRevenue;

        if (difference > 0) {
            return "UPTREND: Revenue increasing";
        } else if (difference < 0) {
            return "DOWNTREND: Revenue decreasing";
        } else {
            return "STABLE: No revenue change";
        }
    }

    public double getAverageProfitMargin() {
        if (records.isEmpty()) {
            return 0;
        }
        double totalMargin = 0;
        for (FinancialData entry : records) {
            totalMargin += entry.getProfitMargin();
        }
        return totalMargin / records.size();
    }

    public List<FinancialData> getHistoricalData() {
        return new ArrayList<>(records);
    }
}
