using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstellaAppCRUD.Repository;

namespace EstellaAppCRUD.Controllers
{
    public class BaseController : Controller
    {
        public IMDBsys32Entities _db;
        public BaseRepository<User> _userRepo;

        public BaseController()
        {
            _db = new IMDBsys32Entities();
            _userRepo = new BaseRepository<User>();
        }
    }
}