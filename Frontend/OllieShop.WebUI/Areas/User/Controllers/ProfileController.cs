using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.OrderDtos.Address;
using OllieShop.DtoLayer.IdentityDtos;
using OllieShop.WebUI.Services.IUserService;
using OllieShop.WebUI.Services.OrderServices.AddressServices;
using OllieShop.WebUI.Services.ImagesServices;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/Profile")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IImagesService _imagesService;
        public ProfileController(IUserService userService, IAddressService addressService, IImagesService imagesService)
        {
            _userService = userService;
            _addressService = addressService;
            _imagesService = imagesService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Profile";
            var user = await _userService.GetUserInfoAsync();
            var addresses = await _addressService.GetAllAddressAsync();

            // Adres listesi boşsa varsayılan bir adres ekle
            if (addresses == null || addresses.Count == 0)
            {
                addresses = new List<ResultAddressDto>
                {
                    new ResultAddressDto
                    {
                        City = "",
                        Description = "None",
                        Country = "",
                        PhoneNumber = "None",
                        ZipCode = ""
                    }
                };
            }

            ViewData["address"] = addresses;
            return View(user);
        }

        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(model);
                if (result)
                {
                    TempData["SuccessMessage"] = "Profile updated successfully!";
                    return Redirect("/User/Profile/Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to update profile.";
                }
            }
            return View("Index", model);
        }


        [Route("UpdateProfileImage")]
        [HttpPost]
        public async Task<IActionResult> UpdateProfileImage(IFormFile profileImage)
        {
            if (profileImage == null || profileImage.Length == 0)
            {
                TempData["ErrorMessage"] = "No file selected.";
                return RedirectToAction("Index");
            }

            try
            {
                var imageUrl = await _imagesService.UploadImageAsync(profileImage);
                var user = await _userService.GetUserInfoAsync();

                UpdateUserDto updatedUser = new UpdateUserDto
                {
                    DateOfBirth = user.DateOfBirth,
                    Surname = user.Surname,
                    Email = user.Email,
                    Gender = user.Gender,
                    Id = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    ProfilePictureUrl = imageUrl,
                    Username = user.Username
                };
                

                var result = await _userService.UpdateUserAsync(updatedUser);
                if (result)
                {
                    TempData["SuccessMessage"] = "Profile Image Updated Successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to Update Profile Image.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }



    }
}
