using AccountingManagementSystem.Application.Services.Accounts.Implementation;
using AccountingManagementSystem.Application.Services.Accounts.Interface;
using AccountingManagementSystem.Application.ViewModels;
using AccountingManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AccountingManagementSystem.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: /Account
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountService.GetAllAsync();
            return View(accounts.Data);
        }

        // GET: /Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNumber,OpeningBalance,AccountType,IsActive")] AccountViewModel account)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _accountService.CreateAsync(account);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(account);
        }

        // GET: /Account/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle error
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
