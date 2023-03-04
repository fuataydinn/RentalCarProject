using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {// verilen pass'in hash'ini olusturur bu metod
            // out dısa donulecek deger demek 
            //burada biz bir password vericez ve bize 2 adet out donecek 
            //burada .net'in cryptografi sınıflarından  birinden yararlanıcaz.

            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Encoding : bir string'i byte cevir 
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {   // sonradan sisteme girmek isteyen kullanıcının password'unun bizim veritabanındaki passwordHash ile ilgili passwordSalt'a göre eşlesip eslesmedigini verdigimiz yerdir.
            // burada out yok cunku bu degerleri biz vericez ve dogrula diyicez 
            // iki hash birbirine eşit ise T değilse F donecek 

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
              var  computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // iki array olustu bu arraylerin degerleri aynı mı kontrol etmek icin for dongusu 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
           
        }
    }
}
