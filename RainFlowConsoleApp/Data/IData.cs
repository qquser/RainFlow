
namespace RainFlowConsoleApp.Data
{
    public interface IData
    {
        int Id { get; set; }
        decimal StartPointValue { get; set; }
        decimal? EndPointValue { get; set; }
        EnumPointType PointType { get; set; }
        int StartId { get; set; }
        int EndId { get; set; }
    }
}
