using AccountingManagementSystem.Application.Services.AccountTransactions.Implementation;
using AccountingManagementSystem.Application.Services.AccountTransactions.Interface;
using AccountingManagementSystem.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AccountingManagementSystem.Mvc.Controllers
{
    public class AccountTransactionController : Controller
    {
        private readonly IAccountTransactionService _service;
        public AccountTransactionController(IAccountTransactionService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list.Data);
        }

        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(AccountTransactionViewModel viewModel)
        {
            await _service.CreateAsync(viewModel);

            return RedirectToAction("Index");
        }
    }
}
