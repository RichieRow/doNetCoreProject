using LZY.Model.ApplicationManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.ViewModel.ApplicationManagementVM
{
    public class WorkPlaceCategoryVM : IEntityVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsNew { get; set; }
        public string WorkArea { get; set; }
        public WorkPlaceCategoryVM()
        { }

        public WorkPlaceCategoryVM(WorkPlaceCategory bo)
        {
            Id = bo.Id;
            Name = bo.Name;
            Description = bo.Description;
            SortCode = bo.SortCode;
            IsNew = false;
            WorkArea = bo.WorkArea;
        }
        public void Maptobo(WorkPlaceCategory bo)
        {
            Id = bo.Id;
            Name = bo.Name;
            Description = bo.Description;
            SortCode = bo.SortCode;
            WorkArea = bo.WorkArea;
        }
    }
}
