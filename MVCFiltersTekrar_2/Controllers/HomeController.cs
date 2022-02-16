using MVCFiltersTekrar_2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFiltersTekrar_2.Controllers
{
    [ActFilter]
    [ResFilter]
    public class HomeController : Controller
    {
        #region Filters

        //Filter'ların görevi kontrol ettikleri Action'lar veya Controller'lar çalışmadan önce veya çalıştıktan sonra devreye girip içlerinde yazdığınız görevleri yapmaktır...

        //Action Filter => Kullanıcı bir Action'a girmeden önce veya Action'ı çalıştırdıktan sonraki durumlarda devreye giren bir yapıdır...

        //Result Filter => Kullanıcı bir View'a giriş yapmadan önce veya View render edildikten sonra devreye giren metotları barındıran bir yapıdır...

        //Authentication Filter => Tamamen yetkilendirme ile ilgilenen bir filter yapısıdır...

        //Exception Filter => Bir Action'da hata oluştuğunda çalışan bir filter yapısıdır...

        //Bir Filter belirleyebilmek için yarattığınız sınıfın bir attribute olarak yazılabilecek bir sınıfa dönüşmesi gerekir...

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}