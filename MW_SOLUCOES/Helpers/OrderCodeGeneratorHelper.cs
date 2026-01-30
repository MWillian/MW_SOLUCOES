namespace MW_SOLUCOES.Helpers;

public static class OrderCodeGeneratorHelper
{
    private static int _globalCounter = 1;
    private static DateTime _lastGeneratedDate = DateTime.Now;
    public static string GenerateCode()
    {
        var now = DateTime.Now;
        if(now.Date > _lastGeneratedDate)
        {
            _globalCounter = 1;
            _lastGeneratedDate = now.Date;
        }
        string code = $"OS-{now:yyyyMMdd}-{_globalCounter:D3}";
        _globalCounter++;
        return code;
    }
}
