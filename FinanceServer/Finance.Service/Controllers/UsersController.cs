namespace Finance.Service.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Finance.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : FinanceBaseController
    {
        public UsersController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var allUsers = this.Data.Users.GetAll();
            return Ok(allUsers);
        }

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var userToShow = this.Data.Users.Get(id);
            return Ok(userToShow);
        }

        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (user == null)
            {
                return BadRequest("You must provide an entry of type 'User', 'NULL' provided.");
            }

            this.Data.Users.Add(user);
            this.Data.SaveChanges();
            var addedUserId = this.Data.Users.GetAll().FirstOrDefault(u => u.Login == user.Login);
            return Ok(addedUserId);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(int id, User user)
        {
            var userToUpdate = this.Data.Users.Get(id);
            if (userToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update user. No user with id {0} found.", id));
            }

            userToUpdate.Login = user.Login;
            this.Data.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userToDelete = this.Data.Users.Get(id);
            if (userToDelete == null)
            {
                return BadRequest(string.Format("No user with id {0} found to be deleted", id));
            }

            this.Data.Users.Delete(userToDelete);
            this.Data.SaveChanges();

            return Ok(userToDelete);
        }
    }
}