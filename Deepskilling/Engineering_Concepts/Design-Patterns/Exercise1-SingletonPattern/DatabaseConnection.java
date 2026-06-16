public class DatabaseConnection {
    private static DatabaseConnection dbInstance;
    private String jdbcUrl;
    private boolean activeConnection;

    private DatabaseConnection() {
        this.jdbcUrl = "jdbc:mysql://localhost:3306/mydb";
        this.activeConnection = false;
    }

    public static synchronized DatabaseConnection getInstance() {
        if (dbInstance == null) {
            dbInstance = new DatabaseConnection();
        }
        return dbInstance;
    }

    public void connect() {
        if (!activeConnection) {
            activeConnection = true;
            System.out.println("Connected to: " + jdbcUrl);
        }
    }

    public void disconnect() {
        if (activeConnection) {
            activeConnection = false;
            System.out.println("Disconnected from database");
        }
    }

    public boolean isConnected() {
        return activeConnection;
    }

    public String executeQuery(String sqlQuery) {
        if (activeConnection) {
            return "Executing: " + sqlQuery;
        } else {
            return "Error: Not connected to database";
        }
    }

    @Override
    public String toString() {
        return "DatabaseConnection[url=" + jdbcUrl + ", connected=" + activeConnection + "]";
    }
}
