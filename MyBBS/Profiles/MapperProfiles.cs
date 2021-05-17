using ApplicationCore.Entity.Cms;
using ApplicationCore.ViewModel;
using ApplicationCore.ViewModel.Manager;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBS.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            #region ManagerRole
            //CreateMap<ManagerRoleAddOrModifyModel, ManagerRole>();
            //CreateMap<ManagerRole, ManagerRoleListModel>();

            #endregion
            #region Manager
            CreateMap<Manager, ManagerListModel>();
            CreateMap<ManagerAddOrModifyModel, Manager>();
            CreateMap<ChangeInfoModel, Manager>();
            #endregion
            #region Menu
            //CreateMap<MenuAddOrModifyModel, Menu>();
            //CreateMap<Menu, MenuNavView>();
            #endregion

            #region TaskInfo
            //CreateMap<TaskInfoAddOrModifyModel, TaskInfo>();
            //CreateMap<TaskInfo, TaskInfoDto>();

            #endregion
        }
    }
}
