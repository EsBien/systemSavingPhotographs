using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DL;

namespace BL
{
    public interface IcollectionBL
    {
        Task<Collection> GetCollectionName(string collectionNumber);
        void SaveCollection(Collection collectionData);
    }
}
