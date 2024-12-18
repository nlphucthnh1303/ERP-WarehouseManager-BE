namespace ERP_WarehouseManager_BE.Model.Requests.MAT.Department
{
    public class Department_CreateReq
    {
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? Description { get; set; }
        public int? StatusID { get; set; }
    }
}
