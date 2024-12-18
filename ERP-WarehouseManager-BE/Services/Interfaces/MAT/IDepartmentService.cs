using ERP_WarehouseManager_BE.Model.Requests.MAT.Department;
using ERP_WarehouseManager_BE.Model.Responses.MAT.Department;

namespace ERP_WarehouseManager_BE.Services.Interfaces
{
    public interface IDepartmentService
    {

        public Task<bool> Update(Department_UpdateReq req, int StaffID);

        public Task<int> Create(Department_CreateReq req, int StaffID);

        public Task<bool> Delete(int ID);

        public Task<IEnumerable<Department_GetAllRes>> ReadAll();

        public Task<IEnumerable<Department_GetDropdownRes>> ReadDropdown();

        public Task<Department_GetByIDRes> ReadByID(int ID);

    }
}
