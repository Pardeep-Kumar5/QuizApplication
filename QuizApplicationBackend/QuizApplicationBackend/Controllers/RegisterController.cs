using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuizApplicationBackend.MappingProfile.DTOs;
using QuizApplicationBackend.Repository.IRepository;
using QuizApplicationBackend.Utility;

namespace QuizApplicationBackend.Controllers
{
    [Route("Register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        private readonly IMapper _mapper;
        public RegisterController(IRegisterRepository registerRepository,
            IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }
        [HttpGet("GetRegister")]
        public IActionResult GetRegister()
        {
            var data=_registerRepository.GetRegister();
            return Ok(data);
        }
        [HttpGet("GetRegisterById")]
        public IActionResult GetStatusByUserID(int userID)
        {
            var status = _registerRepository.GetStatusByUserID(userID);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }
        [HttpPost("Student")]
        public IActionResult StudentRegister(RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                _registerRepository.StudentRegister(register);
            }
            return Ok();
        }
        [HttpPut("ApproveStatus")]
        public IActionResult ApproveStatus(int registerId)
        {
            if (ModelState.IsValid)
            {
                _registerRepository.ApproveStatus(registerId);
            }
            return Ok(ModelState);
        }
        [HttpPut("UnApproveStatus")]
        public IActionResult UnApproveStatus (int registerId)
        {
            if(ModelState.IsValid)
            {
                _registerRepository.UnApproveStatus(registerId);
            }
            return Ok(ModelState);
        }
        [HttpPost("Teacher")]
        public IActionResult TeacherRegister([FromBody]RegisterDto teacher)
        {
              _registerRepository.TeacherRegister(teacher);
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if(loginDto==null)
            {
                return BadRequest();
            }
            var login = _mapper.Map<LoginDto, LoginVM>(loginDto);
            var user = _registerRepository.Login(login.Name, login.Password);
            if (user == null)
                return BadRequest("Wrong UserName and Password");
            return Ok(user);
        }
    }
}
