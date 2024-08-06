namespace Train_Station.Stations
{
    public interface IStation
    {
        Coordinate Coordinate { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}