using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IImageCollectionService
    {
        ///// <summary>
        ///// Get all image of an active image collection
        ///// </summary>
        ///// <param name="imageCollectionID">Image collection ID</param>
        ///// <param name="storeID">Store ID</param>
        ///// <returns></returns>
        //List<ImageCollectionItem> GetImageByCollectionId(int imageCollectionID, int storeID);
    }

    public partial class ImageCollectionService : IImageCollectionService
    {
        //public List<ImageCollectionItem> GetImageByCollectionId(int imageCollectionID, int storeID)
        //{
        //    List<ImageCollectionItem> result = new List<ImageCollectionItem>();
        //    ImageCollection imageCollection = this.Get(q => q.StoreId == storeID && q.Active == true && q.Id == imageCollectionID).FirstOrDefault();
        //    if (imageCollection != null)
        //    {
        //        result = imageCollection.ImageCollectionItems.ToList();
        //    }
        //    return result;
        //}
    }
}
