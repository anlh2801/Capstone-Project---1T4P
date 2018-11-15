using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IGuidelineDomain
    {
        ResponseObject<List<GuidelineAPIViewModel>> GetAllGuidelineByServiceItemId(int serviceItemId);

        ResponseObject<GuidelineAPIViewModel> ViewDetail(int guidelineId);

        ResponseObject<bool> UpdateGuideline(GuidelineUpdateAPIViewModel model);

        ResponseObject<bool> RemoveGuideline(int guidelineId);

        ResponseObject<bool> CreateGuideline(GuidelineAPIViewModel model);
    }

    public class GuidelineDomain : BaseDomain, IGuidelineDomain
    {
        public ResponseObject<List<GuidelineAPIViewModel>> GetAllGuidelineByServiceItemId(int serviceItemId)
        {
            var guidelineService = this.Service<IGuidelineService>();

            var guideline = guidelineService.GetAllGuidelineByServiceItemId(serviceItemId);

            return guideline;
        }

        public ResponseObject<GuidelineAPIViewModel> ViewDetail(int guidelineId)
        {
            var guidelineService = this.Service<IGuidelineService>();

            var guideline = guidelineService.ViewDetail(guidelineId);

            return guideline;
        }

        public ResponseObject<bool> UpdateGuideline(GuidelineUpdateAPIViewModel model)
        {
            var guidelineService = this.Service<IGuidelineService>();

            var result = guidelineService.UpdateGuideline(model);

            return result;
        }

        public ResponseObject<bool> RemoveGuideline(int guidelineId)
        {

            var guidelineService = this.Service<IGuidelineService>();
            var rs = guidelineService.RemoveGuideline(guidelineId);
            return rs;
        }

        public ResponseObject<bool> CreateGuideline(GuidelineAPIViewModel model)
        {
            var guidelineService = this.Service<IGuidelineService>();
            var rs = guidelineService.CreateGuideline(model);
            return rs;
        }
    }
}

