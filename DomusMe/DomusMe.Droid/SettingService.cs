using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DomusMe.Interfaces;
using DomusMe.Droid;
using System.Security.Cryptography;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SettingService))]
namespace DomusMe.Droid
{
    public class SettingService : ISettingService
    {
        ISharedPreferences prefs;
        private const string initVector = "random_code_here";
        private const string passPhrase = "long_random_code_here_like_guid_for_eg";
        private const int keysize = 256;
        public SettingService()
        {
            prefs = Xamarin.Forms.Forms.Context.GetSharedPreferences("myapp.settings", FileCreationMode.Private);
        }


        public void AddOrUpdateSetting<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            var editor = prefs.Edit();

            var encryptedValue = EncryptString(value.ToString());
            editor.PutString(key, encryptedValue);

            editor.Apply();
        }

        private string EncryptString(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public T GetSetting<T>(string key, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            if (!prefs.Contains(key))
            {
                if (defaultValue != null)
                    AddOrUpdateSetting<T>(key, defaultValue);

                return defaultValue;
            }

            return (T)Convert.ChangeType(DecryptString(prefs.GetString(key, string.Empty)), typeof(T));
        }

        private string DecryptString(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

    }
}