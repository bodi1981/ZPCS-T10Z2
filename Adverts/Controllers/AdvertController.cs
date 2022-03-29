using Adverts.Core.Models.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Adverts.Persistence.Repositories;
using Adverts.Persistence;
using Adverts.Core.ViewModels;
using Adverts.Persistence.Extensions;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using Adverts.Core;

namespace Adverts.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IImage _image;
        public AdvertController(IUnitOfWork unitOfWork, IImage image)
        {
            _unitOfWork = unitOfWork;
            _image = image;
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAllAdverts()
        {
            var userId = User.GetUserId();
            var adverts = await _unitOfWork.Advert.GetAdverts();

            var vm = new AdvertsViewModel
            {
                Adverts = adverts,
                UserId = userId,
                Categories = await _unitOfWork.Category.GetCategories(),
                Conditions = await _unitOfWork.Condition.GetConditions()
            };

            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetAllAdverts(AdvertsViewModel vm)
        {
            var userId = User.GetUserId();

            if (!vm.IsMyAdverts)
                userId = null;

            var adverts = await _unitOfWork.Advert.GetAdverts(vm.Title, vm.CategoryId, vm.ProductId, vm.ConditionId, userId);

            vm = new AdvertsViewModel
            {
                Adverts = adverts,
                UserId = User.GetUserId()
            };

            return PartialView("_AdvertCards", vm);
        }

        public IActionResult AddAdvert(int advertId = 0, bool isSuccess = false)
        {
            var userId = User.GetUserId();
            var advert = new Advert { UserId = userId };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.AdvertId = advertId;

            var vm = new AdvertViewModel
            {
                Advert = advert
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdvert(AdvertViewModel vm)
        {
            var userId = User.GetUserId();
            vm.Advert.UserId = userId;

            if (ModelState.IsValid)
            {
                await _image.UploadImages(vm);

                int advertId = await _unitOfWork.Advert.AddAdvert(vm.Advert);
                return RedirectToAction("AddAdvert", new { advertId = advertId, isSuccess = true });
            }

            return View(vm);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAdvert(int advertId)
        {
            var advert = await _unitOfWork.Advert.GetAdvert(advertId);

            return View(advert);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdvert(int advertId)
        {
            try
            {
                var userId = User.GetUserId();
                await _unitOfWork.Advert.RemoveAdvert(advertId, userId);
                await _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetProducts(int categoryId)
        {
            IEnumerable<Product> products = await _unitOfWork.Product.GetProductsByCategory(categoryId);
            var json = Json(products);
            return Json(products);
        }
        
    }
}
