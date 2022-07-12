using admin_master_pro__mvc_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
namespace admin_master_pro__mvc_.Controllers
{
    public class HomeController : Controller
    {
        private adminproDBEntities1 db = new adminproDBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Modal()
        {
            return View();
        }
     
        public ActionResult About()
        {
            var test = db.employees.OrderBy(a => a.rcm).Where(x=>x.sts==0).ToList();
            ViewBag.data = test;
            return View();
        }

        public ActionResult Services()
        {
            var test = db.employees.OrderBy(a => a.rcm).Where(x => x.sts == 0).ToList();
            ViewBag.data = test;
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            db.Configuration.ProxyCreationEnabled = false;
            var test = db.employees.OrderBy(a => a.rcm).Where(a => a.sts == 0).Select(a => new { a.ID, a.firstname, a.lastname, a.email, a.contactnumber, a.companyname, a.dateofjoining }).ToList();
            return Json(new { data = test }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEmployeeList()
        {
            
            var test = db.edu_details.OrderBy(a => a.qualification).Where(a=>a.employee.sts==0).Select(a => new { a.employee.ID, a.employee.firstname, a.employee.lastname, a.employee.email, a.employee.contactnumber, a.employee.companyname, a.employee.dateofjoining }).ToList();
            return Json(test, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeById(string  id)
        {
            Guid ID = Guid.Parse(id);
            var data = db.employees.Where(x => x.ID == ID).FirstOrDefault();
            EmployeeViewModel model = new EmployeeViewModel();
                model.ID = data.ID;
                model.firstname = data.firstname;
                model.lastname = data.lastname;
                model.email = data.email;
                model.contactnumber = data.contactnumber;
                model.companyname = data.companyname;
                model.dateofjoining = Convert.ToDateTime(data.dateofjoining);
           
            List<string> qualification = new List<string>();
            List<Int32> marks = new List<Int32>();
         
            foreach (edu_details edu in db.edu_details.Where(x => x.userID == ID).OrderBy(x => x.qualification).ToList())
            {
                qualification.Add(edu.qualification);
                marks.Add(Convert.ToInt32(edu.marks));
            }
            model.qualification = qualification;
            model.marks = marks;          
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDataInDatabase(EmployeeViewModel model)
        {
            
            var result = false;
            try
            {
                if (model.ID == default(Guid))
                {
                    employee Emp = new employee(); 
                    Emp.ID = Guid.NewGuid();
                    Emp.firstname = model.firstname;
                    Emp.lastname = model.lastname;
                    Emp.email = model.email;
                    Emp.contactnumber = model.contactnumber;
                    Emp.companyname = model.companyname;
                    Emp.dateofjoining = model.dateofjoining;
                    Emp.rco = "Applicant";
                    Emp.sts = 0;
                    Emp.rcm = DateTime.Now;
                    db.employees.Add(Emp);
                    for (int i = 0; i < model.qualification.Count; i++)
                    {
                        if (model.qualification[i] != string.Empty)
                        {
                            edu_details Edu = new edu_details();
                            Edu.ID = Guid.NewGuid();
                            Edu.userID = Emp.ID;
                            Edu.qualification = model.qualification[i];
                            Edu.marks = model.marks[i];
                            Edu.rco = "Applicant";
                            Edu.sts = 0;
                            Edu.rcm = DateTime.Now;
                            db.edu_details.Add(Edu);
                        }
                    }
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    employee Emp = db.employees.SingleOrDefault(x => x.ID == model.ID);
                    List<edu_details> Edu1 = db.edu_details.OrderBy(a => a.qualification).Where(x => x.userID == model.ID).ToList();                  
                        Emp.firstname = model.firstname;
                        Emp.lastname = model.lastname;
                        Emp.email = model.email;
                        Emp.contactnumber = model.contactnumber;
                        Emp.companyname = model.companyname;
                        Emp.dateofjoining = model.dateofjoining;
                        Emp.luo = "Applicant";
                        Emp.lum = DateTime.Now;
                        db.Entry(Emp).State = EntityState.Modified;
                        db.edu_details.RemoveRange(Edu1);

                    for (int i = 0; i < model.qualification.Count; i++)
                    {
                        if (model.qualification[i] != string.Empty)
                        {
                            edu_details Edu = new edu_details();
                            Edu.ID = Guid.NewGuid();
                            Edu.userID = Emp.ID;
                            Edu.qualification = model.qualification[i];
                            Edu.marks = model.marks[i];
                            Edu.rco = "Applicant";
                            Edu.sts = 0;
                            Edu.rcm = DateTime.Now;
                            db.edu_details.Add(Edu);
                        }
                    }
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
            //    throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DeleteEmployeeRecord(Guid id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
           model.ID = id;
            return View(model);
        }
        public ActionResult AddNewEmployee()
        {
            return View();
        }
        public ActionResult EditEmployeeRecord(Guid id)
        {
            var test = db.employees.SingleOrDefault((a=>a.ID==id));
            EmployeeViewModel editmodel = new EmployeeViewModel();
            editmodel.ID = test.ID;
            editmodel.firstname = test.firstname;
            editmodel.lastname = test.lastname;
            editmodel.email = test.email;
            editmodel.contactnumber = test.contactnumber;
            editmodel.companyname = test.companyname;
            editmodel.dateofjoining = Convert.ToDateTime(test.dateofjoining);
            editmodel.qualification = new List<string>();
            editmodel.marks = new List<int>();
            foreach (var qualification in test.edu_details.ToList())
            {
                editmodel.qualification.Add(qualification.qualification);
                editmodel.marks.Add(Convert.ToInt32(qualification.marks));
            }
            ViewBag.data = test;
            return View(editmodel);
        }

        public JsonResult DeleteEmployee(Guid ID)
        {
            bool result = false;
            employee Emp = db.employees.SingleOrDefault(x => x.ID == ID);
            List<edu_details> Edu = db.edu_details.OrderBy(a => a.qualification).Where(x => x.userID == ID).ToList();
            foreach (edu_details item in Edu)
            {
                Emp.sts = 1;
                Emp.luo = "Applicant";
                Emp.lum = DateTime.Now;
                db.Entry(Emp).State = EntityState.Modified;

                item.sts = 1;
                item.luo = "Applicant";
                item.lum = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
