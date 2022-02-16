using MVCFiltersTekrar_2.DesignPatterns.SingletonPattern;
using MVCFiltersTekrar_2.Models.Context;
using MVCFiltersTekrar_2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFiltersTekrar_2.Filters
{

    //Eğer bir sınıfı General Purpose bir Attribute class'ı haline getirmek istiyorsanız FilterAttribute isimli class'tan miras almanız gerekiyor...

    public class ActFilter : FilterAttribute, IActionFilter
    {

        MyContext _db;

        public ActFilter()
        {
            _db = DBTool.DBInstance;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Bu metot Action tetiklenmeden önce devreye giren bir metottur...

            Log logger = new Log();
            if (filterContext.HttpContext.Session["oturum"] == null) logger.UserName = "Anonim kullanıcı";
            else logger.UserName = (filterContext.HttpContext.Session["oturum"] as AppUser).UserName;
            logger.ActionName = filterContext.ActionDescriptor.ActionName;
            logger.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            logger.Information = "Action tetikleme aşamasında";
            logger.Description = Keyword.Entry;

            _db.Logs.Add(logger);
            _db.SaveChanges();
            
        }

        //Todo: Burada yapılan tekrarlayan işlemleri öyle bir metotta yazın ki ister metodu OnActionExecuting ister OnActionExecuted metotlarında çağırayım ve ben ilgili durumlarda ne yapmak istiyorsam parametrik olarak bana cevap verilsin...

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Bu metot Action tetiklendikten sonra devreye giren metottur...

            Log logger = new Log();
            if (filterContext.HttpContext.Session["oturum"] == null) logger.UserName = "Anonim kullanıcı";
            else logger.UserName = (filterContext.HttpContext.Session["oturum"] as AppUser).UserName;
            logger.ActionName = filterContext.ActionDescriptor.ActionName;
            logger.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            logger.Information = "Action geriye değer döndürmüş durumdadır";
            logger.Description = Keyword.Exit;

            _db.Logs.Add(logger);
            _db.SaveChanges();
            
        }

    }
   
}