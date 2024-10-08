using FirstCoreApp.Data;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstCoreApp.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationDbContext _Dbcontext;
        public TeacherController(ApplicationDbContext dbContext) 
        {
            _Dbcontext =  dbContext;
        }  
        // GET: TeacherController
        public ActionResult Index()
        {
            try
            {
                var Data = _Dbcontext.Teacher.ToList();
                if (ModelState.IsValid)
                {
                    return View(Data);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
            return View();
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var Data = _Dbcontext.Teacher.FirstOrDefault(x => x.Id == id);
                if (Data == null)
                {
                    return NotFound();
                }
                return View(Data);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);    
            }
            
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherModal modal)
        {
            try
            {
                _Dbcontext.Teacher.Add(modal);
                _Dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var Data = _Dbcontext.Teacher.ToList().Where(x => x.Id == id).First();
                if (Data == null)
                {
                    return NotFound("Id not Found");
                }
                return View(Data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeacherModal modal)
        {
            try
            {
                _Dbcontext.Update(modal);
                _Dbcontext.SaveChanges();
                return RedirectToAction("index");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var Data = _Dbcontext.Teacher.FirstOrDefault(x => x.Id == id);
                _Dbcontext.Teacher.Remove(Data);
                _Dbcontext.SaveChanges(true);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
         
       
    }
}
