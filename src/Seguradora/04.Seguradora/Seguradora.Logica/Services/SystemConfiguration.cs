public sealed class SystemConfiguration
{
    public Guid Id { get; private set; } 
    public decimal SeguraVidaTaxa { get; private set; }
    public decimal SeguraAutoTaxa { get; private set; }
    public string ApiKeyServicoExterno { get; private set; }

    // Singleton instance
    private static readonly SystemConfiguration _instance = new SystemConfiguration();

    private SystemConfiguration()
    {
        // Initialize default values
        Id = Guid.NewGuid();
        SeguraVidaTaxa = 0.05m; // 5% for life insurance
        SeguraAutoTaxa = 0.03m; // 3% for auto insurance
        ApiKeyServicoExterno = "default-api-key"; // Placeholder for external service API key
    }

    public static SystemConfiguration Instance => _instance;
}