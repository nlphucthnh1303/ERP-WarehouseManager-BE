using Dapper;
using ERP_WarehouseManager_BE.Model.Requests.MAT.Department;
using ERP_WarehouseManager_BE.Model.Responses.MAT.Department;
using ERP_WarehouseManager_BE.Services.Interfaces;
using System.Data.SqlClient;

namespace ERP_WarehouseManager_BE.Services.Implements
{
    public class DepartmentService : IDepartmentService
    {
        public readonly IConfiguration _config;

        public DepartmentService(IConfiguration config) {
            _config = config;
        }

        public async Task<int> Create(Department_CreateReq req, int StaffID)
        {
            try
            {
                var parameters = new DynamicParameters(req);
                parameters.Add("CreateStaffID", StaffID);
                using (var connection = GetConnection()) {
                    var result = await connection.ExecuteScalarAsync<int>("MAT.Department_Create", parameters, commandType: System.Data.CommandType.StoredProcedure);

                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return -1;
                    }
                };
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<bool> Update(Department_UpdateReq req, int StaffID)
        {
            try
            {
                var parameters = new DynamicParameters(req);
                parameters.Add("UpdateStaffID", StaffID);
                using (var connection = GetConnection()) 
                {
                    var result = await connection.ExecuteAsync("MAT.Department_Update", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
               
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int ID)
        {
            try
            {
                using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                string ProcedureName = "EXEC MAT.Department_Delete @Id";
                var result = await connection.QueryFirstAsync<int>(ProcedureName, new { Id = ID });
                return result == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Department_GetAllRes>> ReadAll()
        {
            try
            {
                using var connection = GetConnection();
                string ProcedureName = "EXEC MAT.Department_GetALL";
                var result = await connection.QueryAsync<Department_GetAllRes>(ProcedureName);
                if (result == null)
                {
                    result = new List<Department_GetAllRes>();
                }
                return result;
            }
            catch (Exception)
            {
                return await Task.FromResult(new List<Department_GetAllRes>());
            }
        }

        public async Task<Department_GetByIDRes> ReadByID(int ID)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string ProcedureName = "EXEC MAT.Department_GetByID @Id";
                    var result = await connection.QueryFirstOrDefaultAsync<Department_GetByIDRes>(ProcedureName, new { Id = ID });
                    if (result == null)
                    {
                        result = new Department_GetByIDRes();
                    }
                    return result;
                };
            }
            catch (Exception)
            {
                return await Task.FromResult(new Department_GetByIDRes());
            }
        }

        public async Task<IEnumerable<Department_GetDropdownRes>> ReadDropdown()
        {
            try
            {
                using var connection = GetConnection();
                string ProcedureName = "EXEC MAT.Department_GetDropdown";
                var result = await connection.QueryAsync<Department_GetDropdownRes>(ProcedureName);
                if (result == null)
                {
                    result = new List<Department_GetDropdownRes>();
                }
                return result;
            }
            catch (Exception)
            {
                return await Task.FromResult(new List<Department_GetDropdownRes>());
            }
        }


        public SqlConnection GetConnection() {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }


    }
}
