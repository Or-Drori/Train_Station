using Train_Station.Users;

namespace Train_Station.Wallet
{
    public interface IWalletManager
    {
        void AddMoney(User user, double money);
        void SubtractMoney(User user, double money);
    }
}