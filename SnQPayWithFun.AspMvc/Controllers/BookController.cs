using Microsoft.AspNetCore.Mvc;
using SnQPayWithFun.AspMvc.Models.Book;
using SnQPayWithFun.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQPayWithFun.AspMvc.Controllers
{
    
    public class BookController : GenericModelController<IBook, Book>
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using var ctrl = Logic.Factory.Create<IBook>();
            var entity = await ctrl.CreateAsync().ConfigureAwait(false);

            return View(ToModel(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Book model)
        {
            using var ctrl = Logic.Factory.Create<IBook>();

            await ctrl.InsertAsync(model).ConfigureAwait(false);
            await ctrl.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var ctrl = Logic.Factory.Create<IBook>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

            return View(ToModel(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Book model)
        {
            using var ctrl = Logic.Factory.Create<IBook>();
            var entity = await ctrl.GetByIdAsync(model.Id).ConfigureAwait(false);

            if(entity != null)
            {
                entity.CopyProperties(model);
                await ctrl.UpdateAsync(entity).ConfigureAwait(false);
                await ctrl.SaveChangesAsync().ConfigureAwait(false);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using var ctrl = Logic.Factory.Create<IBook>();
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

            return View(ToModel(entity));
        }

        public async Task<IActionResult> DeleteEntity(int id)
        {
            using var ctrl = Logic.Factory.Create<IBook>();
            await ctrl.DeleteAsync(id).ConfigureAwait(false);
            await ctrl.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction("Index");
        }
    }
}
