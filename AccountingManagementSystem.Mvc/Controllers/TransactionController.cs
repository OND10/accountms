using AccountingManagementSystem.Application.Services.Transactions.Implementation;
using AccountingManagementSystem.Application.Services.Transactions.Interface;
using AccountingManagementSystem.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingManagementSystem.Mvc.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [Authorize(Roles = "Admin")]
        // GET: /Transaction
        public async Task<IActionResult> Index()
        {
            var transactions = await _transactionService.GetAllAsync();
            return View(transactions.Data);
        }

        // GET: /Transaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionType,ReferenceNumber,TransactionAccounts")] TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _transactionService.CreateAsync(transaction);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(transaction);
        }
    }
}
