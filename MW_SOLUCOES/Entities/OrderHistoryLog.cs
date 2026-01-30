namespace MW_SOLUCOES.Entities;

public class OrderHistorylog
{
    public List<string> History { get; private set; } = new List<string>();
    private DateTime? LastUpdatedAt { get; set; }
    
    public void RegisterLog(string fieldModified)
    {
        History.Add($"Campo modificado: {fieldModified} - {DateTime.Now}");
        LastUpdatedAt = DateTime.Now;
    }
    
    public DateTime? GetDate() { return LastUpdatedAt; }
}
