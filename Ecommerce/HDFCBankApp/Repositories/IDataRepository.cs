using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDFCBankApp.Repositories
{
    public interface IDataRepository<T>
    {
        bool Serialize(string filename, List<T> entities);
        List<T> Deserialize(string filename);
    }
}