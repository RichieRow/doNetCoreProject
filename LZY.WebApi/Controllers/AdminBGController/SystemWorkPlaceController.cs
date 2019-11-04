using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZY.DataAccess;
using LZY.Model.ApplicationManagement;
using LZY.Model.ApplicationOrganization;
using LZY.ViewModel.ApplicationManagementVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LZY.WebApi.Controllers.AdminBGController
{
    /// <summary>
    /// 这是导航栏的控制器
    /// </summary>
    public class SystemWorkPlaceController : BaseController
    {
        private readonly IEntityRepository<SystemWorkPlace> _bo;
        private readonly IEntityRepository<WorkPlaceCategory> _boWPC;
        public SystemWorkPlaceController(IEntityRepository<SystemWorkPlace> bo, IEntityRepository<WorkPlaceCategory> boWPC)
        {
            _bo = bo;//bo指的是business obje(业务对象)
            _boWPC = boWPC;
        }


        public async Task<List<SystemWorkPlaceVM>> GetSystemWorkPlace()
        {
            var bo = await _bo.GetAllAsyn();
            var boVM = new List<SystemWorkPlaceVM>();
            foreach (var item in bo)
            {
                var bovm = new SystemWorkPlaceVM(item);
                boVM.Add(bovm);
            }
            return boVM;
        }

        /// <summary>
        /// 根据ID查询详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SystemWorkPlaceVM> GetSystemWorkPlaceById([FromBody]string id)
        {
            var bo = await _bo.GetAllIncludingAsyn(x => x.IconPath, x => x.personWorkPlace, x => x.workPlaceCategory);
            var bowpc = await _boWPC.GetAllAsyn();
            var boVM = new SystemWorkPlaceVM(bo.Where(x=>x.Id==Guid.Parse(id)).FirstOrDefault(), bowpc.ToList());
            return boVM;
        }

        public async Task<List<WorkPlaceCategoryVM>> GetWorkPlaceCategory()
        {
            var bowpc = await _boWPC.GetAllAsyn();
            var boVM = new List<WorkPlaceCategoryVM>();
            foreach (var item in bowpc)
            {
                var bovm = new WorkPlaceCategoryVM(item);
            }
            return boVM;
        }

    }
}