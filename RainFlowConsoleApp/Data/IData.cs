
namespace RainFlowConsoleApp.Data
{
    public interface IData
    {
        int Id { get; set; }
        decimal StartPointValue { get; set; }
        decimal? EndPointValue { get; set; }
        EnumPointType PointType { get; set; }
    }
}
