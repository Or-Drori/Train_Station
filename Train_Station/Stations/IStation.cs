namespace Train_Station.Station
{
    public interface IStation
    {
        string Name { get; set; }
        Coordinate coordinate { get; set; }
        int Id { get; set; }
    }
}