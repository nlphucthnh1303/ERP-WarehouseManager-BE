﻿namespace ERP_WarehouseManager_BE.Model.Responses.MAT.Department
{
    public class Department_GetAllRes
    {
        public int DepartmentID { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? Description { get; set; }
        public int? StaffCreateID { get; set; }
        public string? StaffCreateName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusID { get; set; }
        public string? StatusName { get; set; }
    }
}
