using JEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDBService
{
    interface IDBService
    {
        List<T> GetData<T>() where T : EntityBase, new();
        bool Update<T>(T t) where T : EntityBase, new();
        bool Update<T>(List<string> pKey, T value) where T : EntityBase, new();
        object Insert<T>(T t) where T : EntityBase, new();
        object Insert<T>(List<T> list) where T : EntityBase, new();
        bool Delete<T>(T t) where T : EntityBase, new();
        bool Delete<T>(List<string> pKey) where T : EntityBase, new();
    }
}
