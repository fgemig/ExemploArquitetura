using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FG.MusicStore.Application.Contracts;
using FG.MusicStore.Application.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace FG.MusicStore.Site.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [Route("customers-list")]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerAppService.GetCustomers();
            return View(customers);
        }

        [HttpGet]
        [Route("create-customer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create-customer")]
        public IActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _customerAppService.Add(model);
                ViewBag.Sucesso = "Cliente registrado com sucesso!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Cliente não registrado!");
            }

            return View(model);
        }

        [HttpGet]
        [Route("edit-customer/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var customer =
                await _customerAppService.GetById(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-customer/{id:guid}")]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _customerAppService.Update(model);
                ViewBag.Sucesso = "Cliente atualizado com sucesso!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Cliente não atualizado!");
            }

            return View(model);
        }

        [HttpGet]
        [Route("delete-customer/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var customer =
                await _customerAppService.GetById(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete-customer/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {

            if (!id.HasValue)
                return NotFound();

            var customer =
               await _customerAppService.GetById(id.Value);

            try
            {
                _customerAppService.Remove(id.Value);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Cliente não excluído!");
            }

            return View(nameof(Delete), customer);
        }

    }
}