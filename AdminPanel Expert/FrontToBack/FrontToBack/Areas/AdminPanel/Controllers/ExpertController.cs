using FrontToBack.Areas.AdminPanel.ViewModels;
using FrontToBack.DataAccessLayer;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ExpertController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _enviroment;

        public ExpertController(AppDbContext dbContext, IWebHostEnvironment enviroment)
        {
            _dbContext = dbContext;
            _enviroment = enviroment;
        }

        public async Task<IActionResult> Index()
        {
            var experts = await _dbContext.Experts.ToListAsync();
            var expertText = await _dbContext.ExpertTexts.SingleOrDefaultAsync();

            return View(new ExpertViewModel
            {
                Experts = experts,
                ExpertText = expertText
            });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expertText = await _dbContext.ExpertTexts.FindAsync(id);

            if (expertText == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(expertText);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ExpertText experText)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != experText.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var dbExpertTexts = await _dbContext.ExpertTexts.FindAsync(id);

            if (dbExpertTexts == null)
            {
                return NotFound();
            }

            dbExpertTexts.Title = experText.Title;
            dbExpertTexts.Subtitle = experText.Subtitle;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expert expert)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!expert.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Image", "Yalniz shekil elave ede bilersiz!");
                return View();
            }

            if(expert.Image.Length > 1000 * 1024)
            {
                ModelState.AddModelError("Image", "1 Mb dan chox ola bilmez!");
                return View();
            }

            if (await _dbContext.Experts.CountAsync() == 8)
            {
                ModelState.AddModelError("Image", "12-den chox Expert elave etmek olmaz!");
                return View();
            }

            var webRootPath = _enviroment.WebRootPath;
            var fileName = Guid.NewGuid().ToString() + "-" + expert.Image.FileName;
            var path = Path.Combine(webRootPath, "img", fileName);

            var fileStream = new FileStream(path, FileMode.CreateNew);
            await expert.Image.CopyToAsync(fileStream);

            expert.ImageName = fileName;

            await _dbContext.Experts.AddAsync(expert);
            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _dbContext.Experts.FindAsync(id);

            if (expert == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            return View(expert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Expert expert)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != expert.Id)
            {
                return BadRequest();
            }

            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid 
                && ModelState["Surname"].ValidationState == ModelValidationState.Invalid 
                && ModelState["Field"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            var dbExpert = await _dbContext.Experts.FindAsync(id);
            if (dbExpert == null)
            {
                return NotFound();
            }

            if (expert.Image != null)
            {
                if (!expert.Image.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Image", "Yalniz shekil elave ede bilersiz!");
                    return View();
                }

                if (expert.Image.Length > 1000 * 1024)
                {
                    ModelState.AddModelError("Image", "1 Mb dan chox ola bilmez!");
                    return View();
                }
                var webRootPath = _enviroment.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + "-" + expert.Image.FileName;
                var path = Path.Combine(webRootPath, "img", fileName);

                var fileStream = new FileStream(path, FileMode.CreateNew);
                await expert.Image.CopyToAsync(fileStream);

                dbExpert.ImageName = fileName;

            }

            dbExpert.Name = expert.Name;
            dbExpert.Surname = expert.Surname;
            dbExpert.Field = expert.Field;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _dbContext.Experts.FindAsync(id);

            if (expert == null)
            {
                return NotFound();
            }

            return View(expert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _dbContext.Experts.FindAsync(id);

            if (expert == null)
            {
                return NotFound();
            }

            _dbContext.Experts.Remove(expert);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
