using Microsoft.AspNetCore.Mvc;
using RepositoryPatternCRUD.Models;
using RepositoryPatternCRUD.Repository.Interface;
using RepositoryPatternCRUD.Service;

namespace RepositoryPatternCRUD.Controllers
{
    // ctrl + MO -> colaips all method
    // ctrl + KD -> Code Align
    // Controller <--> Services <--> Repository <--> Database 
    public class UserController : Controller
    {
        private readonly IUserService _userRepository;
        public UserController(IUserService userrepository)
        {
               _userRepository = userrepository;
        }
        public async Task<IActionResult> GetUserList()
        {             
            return View(await _userRepository.GetUsers());
        }
        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User mdata)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(mdata);
                }
                else
                {
                    await _userRepository.AddUser(mdata);
                    if (mdata.UserId == 0)
                    {
                        TempData["usererror"] = "Recard not saved";
                    }
                    else
                    {
                        TempData["success"] = "Recard Successfuly Saved";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");
        }
       
        public async Task<IActionResult> Edit(int id)
        {
            User user = new User();
            try
            {
                if (id==0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await _userRepository.UserGetById(id);
                    if (user == null)
                    {
                        return NotFound();  
                    }
                  
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(user);  
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User mdata)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(mdata);
                }
                else
                {
                    bool status = await _userRepository.UpdateRecard(mdata);
                    if (status)
                    {
                        TempData["success"] = "Your Recard has been Successfuly Updated";
                    }
                    else
                    {
                        TempData["usererror"] = "Recard has been not Updated";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList");
        }

        public async Task<IActionResult> Details(int id)
        {
            User user = new User();
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    user = await _userRepository.DetailsById(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(user);
        }
        public async Task<IActionResult> DeleteRecards(int id)
        {
            try
            {
                if (id==0)
                {
                    return BadRequest();
                }
                else
                {
                   bool status = await _userRepository.DeleteRecard(id);
                    if (status)
                    {
                        TempData["success"] = "Your Recard has been Successfuly Deleted";
                    }
                    else
                    {
                        TempData["usererror"] = "Recard has been not Deleted";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetUserList"); 
        }
    }
}
