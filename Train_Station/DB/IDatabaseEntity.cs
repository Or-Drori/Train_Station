using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station.DB
{
    public interface IDatabaseEntity
    {
        int Id { get; }
        string Name { get; }
    }
}
