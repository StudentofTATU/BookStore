using BookStore.Interfaces;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsersAsync();

            return View(users);
        }

        [HttpGet]
        [Route("user/create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Name = userVM.Name,
                    Password = userVM.Password,
                    UserStatus = Data.Enums.UserStatus.USER
                };

                _userRepository.Add(user);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return View("Error");
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Update(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }


        public IActionResult Delete(int Id)
        {
            _userRepository.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
