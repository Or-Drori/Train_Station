namespace Train_Station.Users
{
    public interface IUser
    {
        Gender Gender { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        double Wallet { get; set; }
    }
}