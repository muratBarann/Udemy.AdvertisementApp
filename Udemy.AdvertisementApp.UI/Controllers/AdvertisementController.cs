using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.Common.Enums;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.UI.Extensions;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        public AdvertisementController(IAdvertisementService advertisementService, IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _advertisementService = advertisementService;
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                });
            }


            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId
            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            AdvertisementAppUserCreateDto dto = new();

            if (model.CvPath != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvPath.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvPath.CopyToAsync(stream);
                dto.CvPath = path;
            }

            dto.AppUserId = model.AppUserId;
            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.EndDate = model.EndDate;
            dto.WorkExperience = model.WorkExperience;
            dto.MilitaryStatusId = model.MilitaryStatusId;

            var response = await _advertisementAppUserService.CreateAsync(dto);

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.ErrorMessage, error.PropertyName);
                }
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));
                var list = new List<MilitaryStatusListDto>();

                foreach (int item in items)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item),
                    });
                }


                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View(model);
            }

            else
            {
                return RedirectToAction("HumanResource", "Home");
            }

        }
    }

}
