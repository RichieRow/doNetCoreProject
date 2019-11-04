using LZY.Model.ApplicationManagement;
using LZY.Model.Attachments;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.ViewModel.ApplicationManagementVM
{
    public class SystemWorkPlaceVM : IEntityVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsNew { get; set; }
        public string Url { get; set; }
        public virtual BusinessImage Icon { get; set; }
        public string IconPath { get; set; }
        public bool IsUsed { get; set; }
        public virtual SystemWorkPlace personWorkPlace { get; set; }//上级导航栏
        public WorkPlaceCategory workPlaceCategory { get; set; }
        public string SworkPlaceCategory { get; set; }
        public List<WorkPlaceCategory> workPlaceCategorys { get; set; }

        public SystemWorkPlaceVM()
        { }

        public SystemWorkPlaceVM(SystemWorkPlace bo,List<WorkPlaceCategory> wpc)
        {
            Id = bo.Id;
            Name = bo.Name;
            Description = bo.Description;
            SortCode = bo.SortCode;
            IsNew = false;
            Url = bo.Url;
            IconPath = "http://onedrive.ibibii.com/?/images/2019/11/04/MTEZp9FDh3/index1.png";
            if (Icon != null)
            {
                IconPath = Icon.UploadPath;
            }
            IsUsed = bo.IsUsed;
            if (workPlaceCategory != null)
            {
                workPlaceCategory = bo.workPlaceCategory;
                SworkPlaceCategory = bo.workPlaceCategory.Name;
            }
            workPlaceCategorys = wpc;
        }
        public SystemWorkPlaceVM(SystemWorkPlace bo)
        {
            Id = bo.Id;
            Name = bo.Name;
           
            IsUsed = bo.IsUsed;
            if (workPlaceCategory != null)
            {
                workPlaceCategory = bo.workPlaceCategory;
                SworkPlaceCategory = bo.workPlaceCategory.Name;
            }
        }

    }
}
