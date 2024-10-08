using FirstCoreApp.Data;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstCoreApp.Controllers
{
    public class ManagementController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ManagementController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: ManagementController
        public ActionResult Index()
        {
            try
            {
                var data = _dbContext.Management.ToList();
                if (ModelState.IsValid)
                {
                    return View(data);
                } 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);  
            }
            
            return NotFound();
        }

        // GET: ManagementController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var Data = _dbContext.Management.FirstOrDefault(x => x.ID == id);
                if (Data == null)
                {
                    return NotFound();
                }
                return View(Data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
           
        }

        // GET: ManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagementModel model)
        {
            try
            {
                _dbContext.Management.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
            
        }

        // GET: ManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var Data = _dbContext.Management.ToList().Where(x => x.ID == id).First();
                if (Data == null)
                {
                    return NotFound();
                }
                return View(Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
                
            }
            
          
        }

        // POST: ManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ManagementModel model)
        {
            try
            {
                 _dbContext.Management.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var Data = _dbContext.Management.FirstOrDefault(x => x.ID == id);
                _dbContext.Remove(Data);
                _dbContext.SaveChanges(true);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
           
        }

       
    }
}
