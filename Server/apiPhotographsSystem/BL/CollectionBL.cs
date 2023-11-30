using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{
    public class CollectionBL : IcollectionBL
    {
        IcollectionDL _icollectionDL;
        public CollectionBL(IcollectionDL icllectionDL)
        {
            _icollectionDL = icllectionDL;
        }
        public Task<Collection> GetCollectionName(string collectionNumber)
        {
            return _icollectionDL.GetCollectionName(collectionNumber);
        }

        public void SaveCollection(Collection collectionData)
        {
           _icollectionDL.SaveCollection(collectionData);
        }
    }
}
