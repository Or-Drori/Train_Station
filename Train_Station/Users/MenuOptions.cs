using System.ComponentModel;

namespace Train_Station.Users
{
   
    public enum MenuOptions
    {
        [Description("Adding Money")]
        AddingMoney,
        [Description("Substracting Money")]
        SubtractingMoney,
        [Description("Buying Ticket")]
        BuyingTicket
    
    }
}