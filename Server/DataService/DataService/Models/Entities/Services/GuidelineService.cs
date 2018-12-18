using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IGuidelineService
    {

        ResponseObject<List<GuidelineAPIViewModel>> GetAllGuidelineByServiceItemId(int serviceItemId);

        ResponseObject<GuidelineAPIViewModel> ViewDetail(int guidelineId);

        ResponseObject<bool> UpdateGuideline(GuidelineUpdateAPIViewModel model);

        ResponseObject<bool> RemoveGuideline(int guidelineId);

        ResponseObject<bool> CreateGuideline(GuidelineAPIViewModel model);
    }
    public partial class GuidelineService
    {

        public ResponseObject<List<GuidelineAPIViewModel>> GetAllGuidelineByServiceItemId(int serviceItemId)
        {
            List<GuidelineAPIViewModel> rsList = new List<GuidelineAPIViewModel>();
            var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
            var guideline = guidelineRepo.GetActive(p => p.ServiceItemId == serviceItemId).ToList();
            if (guideline.Count <= 0)
            {
                return new ResponseObject<List<GuidelineAPIViewModel>> { IsError = true, WarningMessage = "Không có hướng dẫn nào" };
            }
            int count = 1;
            foreach (var item in guideline)
            {
                rsList.Add(new GuidelineAPIViewModel
                {
                    NumericalOrder = count,
                    ServiceItemId = item.ServiceItemId,
                    GuidelineName = item.GuidelineName,
                    GuidelineId = item.GuidelineId,
                    CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                });

                count++;
            }

            return new ResponseObject<List<GuidelineAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị danh sách dịch vụ" };
        }

        public ResponseObject<GuidelineAPIViewModel> ViewDetail(int guidelineId)
        {
            try
            {
                var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
                var guideline = guidelineRepo.GetActive().SingleOrDefault(a => a.GuidelineId == guidelineId);
                if (guideline != null)
                {
                    var GuidelineAPIViewModel = new GuidelineAPIViewModel
                    {
                        GuidelineName = guideline.GuidelineName,
                        GuidelineId = guideline.GuidelineId,
                        CreateDate = guideline.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = guideline.UpdateDate != null ? guideline.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty
                    };
                    return new ResponseObject<GuidelineAPIViewModel> { IsError = false, ObjReturn = GuidelineAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<GuidelineAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hướng dẫn này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<GuidelineAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hướng dẫn này", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> UpdateGuideline(GuidelineUpdateAPIViewModel model)
        {
            try
            {
                var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
                var updateGuideline = guidelineRepo.GetActive().SingleOrDefault(a => a.GuidelineId == model.GuidelineId);

                if (updateGuideline != null)
                {
                    updateGuideline.GuidelineName = model.GuidelineName;
                    updateGuideline.UpdateDate = DateTime.UtcNow.AddHours(7);

                    guidelineRepo.Edit(updateGuideline);
                    guidelineRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa hướng dẫn thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa hướng dẫn thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa hướng dẫn thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> RemoveGuideline(int guidelineId)
        {
            var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
            var guideline = guidelineRepo.GetActive().SingleOrDefault(a => a.GuidelineId == guidelineId);
            try
            {
                Deactivate(guideline);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa hướng dẫn thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa hướng dẫn thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }
        }

        public ResponseObject<bool> CreateGuideline(GuidelineAPIViewModel model)
        {
            try
            {
                var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
                var guideline = new Guideline();

                guideline.ServiceItemId = model.ServiceItemId;
                guideline.GuidelineName = model.GuidelineName;
                guideline.CreateDate = DateTime.UtcNow.AddHours(7);
                guideline.UpdateDate = DateTime.UtcNow.AddHours(7);
                guidelineRepo.Add(guideline);
                guidelineRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Tạo hướng dẫn thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa hướng dẫn thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }
    }
}
