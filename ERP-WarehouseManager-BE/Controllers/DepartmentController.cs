using Dapper;
using ERP_WarehouseManager_BE.Model.Requests.MAT.Department;
using ERP_WarehouseManager_BE.Model.Responses.MAT.Department;
using ERP_WarehouseManager_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ERP_WarehouseManager_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Department_GetAllRes>>> GetAll()
        {
            var result = await _departmentService.ReadAll();
            return Ok(result);
        }

        [HttpGet("GetDropdown")]
        public async Task<ActionResult<IEnumerable<Department_GetDropdownRes>>> GetDropdown()
        {
            var result = await _departmentService.ReadDropdown();
            return Ok(result);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Department_GetByIDRes>> GetByID(int id)
        {
            var result = await _departmentService.ReadByID(id);
            if (result == null) {
                return NotFound("Không tìm thấy dữ liệu");
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _departmentService.Delete(id);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(Department_CreateReq request)
        {
            var result = await _departmentService.Create(request, 0);
            if(result > 0 && result != -1)
            {
                return Ok(result);
            }else
            {
                return BadRequest("Thêm mới thất bại");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(Department_UpdateReq request)
        {
            var result = await _departmentService.Update(request, 0);
            if (result)
            {
                return Ok(result);
            }else
            {
                return BadRequest("Cập nhật thất bại");
            }
        }
    }
}
