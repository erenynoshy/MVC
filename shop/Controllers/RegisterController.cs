
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.IO;

namespace shop.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        projectDB db;
        private static object DataAccessBlock;

        public RegisterController()
        {
            db = new projectDB();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(User u)
        {
            //check if exist in db 
            var check = db.Users.FirstOrDefault(i => i.UserName == u.UserName);
            if (check==null)
            {
                User saveuser = new User
                {
                    UserName = u.UserName,
                    Password = encrypt(u.Password),
                    Address = u.Address,
                    userType="normal"
                };
                Session["user_name"] = u.UserName;
                db.Users.Add(saveuser);
                db.SaveChanges();
                return RedirectToAction("index", "Product");
            }
            else
            {
                return RedirectToAction("index", "Register");
            }
            
        }
        public string encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
  
    }
}