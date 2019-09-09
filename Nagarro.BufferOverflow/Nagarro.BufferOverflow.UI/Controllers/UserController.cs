using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Nagarro.BufferOverflow.Shared;
using Nagarro.BufferOverflow.DTOModel;
using System.Web.Http.Cors;

namespace Nagarro.BufferOverflow.UI
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get action to get user details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/user/profile/{id}")]
        public IHttpActionResult GetProfile(int id)
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.Id = id;
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> result = userFacade.GetProfile(userDTO);

            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                User user = new User();
                EntityConverter.FillEntityFromDTO(result.Data, user);
                string success = JsonConvert.SerializeObject(new { success = true, data = user });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        /// <summary>
        /// Post action to register user
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("api/user/register")]
        public IHttpActionResult Register([FromBody]User user)
        {
            user.Created = DateTime.Now;

            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            EntityConverter.FillDTOFromEntity(user, userDTO);

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> result = userFacade.Register(userDTO);

            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                EntityConverter.FillEntityFromDTO(result.Data, user);
                string success = JsonConvert.SerializeObject(new { success = true, data = user });
                return Ok(success);
            }
           
            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        /// <summary>
        /// Post action to login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //[HttpPost]
        //[Route("api/user/login")]
        public User Login([FromBody]User user)
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            EntityConverter.FillDTOFromEntity(user, userDTO);

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> result = userFacade.Login(userDTO);

            if (result.ResultType == OperationResultType.Failure)
            {
                //string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                //return BadRequest(failed);
                return null;
            }

            if (result.IsValid())
            {
                EntityConverter.FillEntityFromDTO(result.Data, user);
                ////var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                ////var manager = new UserManager<ApplicationUser>(userStore);
                ////var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email }
                //string success = JsonConvert.SerializeObject(new { success = true, data = user});
                //return Ok(success);

                return user;
            }
            //string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            //return BadRequest(jsonObj);
            return null;
        }
    }
}