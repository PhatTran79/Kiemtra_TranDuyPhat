using Kiemtra_TranDuyPhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kiemtra_TranDuyPhat.Controllers
{
    public class SinhvienController : Controller
    {
        // GET: Sinhvien
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SinhVien masv = new SinhVien();
            masv.MaSV = collection["MaSV"];
            masv.HoTen = collection["HoTen"];
            masv.GioiTinh = collection["GioiTinh"];
            masv.NgaySinh = DateTime.Parse(collection["NgaySinh"]);
            masv.Hinh = collection["Hinh"];
            masv.MaNganh = collection["MaNganh"];
            data.SinhViens.Add(masv);
            return RedirectToAction("Index");
        }
        //------------------Detail----------------------
        public ActionResult Detail(string id)
        {
            SinhVien D_sv = data.SinhViens.FirstOrDefault(p => p.MaSV == id);
            return View(D_sv);
        }
        //------------------Delete----------------------
        public ActionResult Delete(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.Remove(D_sinhvien);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        //-------------------Edit-----------------------
        public ActionResult Edit(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sv = data.SinhViens.First(m => m.MaSV == id);
            var E_tensv = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_man = collection["MaNganh"];
            E_sv.MaSV = id;
            if (string.IsNullOrEmpty(E_tensv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sv.HoTen = E_tensv;
                E_sv.GioiTinh = E_gioitinh;
                E_sv.NgaySinh = E_ngaysinh;
                E_sv.Hinh = E_hinh;
                E_sv.MaNganh = E_man;
                UpdateModel(E_sv);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
    }
}