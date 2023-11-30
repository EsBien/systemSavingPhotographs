using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public interface IcollectionDL
    {
         Task<Collection> GetCollectionName(string collectionNumber);
         void SaveCollection(Collection collectionData);
    }
}
