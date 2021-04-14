using Library.Services.Members;
using Library.Services.Members.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.RestApi.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : Controller
    {
        private MemberService _service;
        public MembersController(MemberService service)
        {
            _service = service;
        }

        [HttpPost]
        public int Add([Required][FromBody] AddMemberDto dto)
        {
            return _service.Add(dto);
        }
    }
}
