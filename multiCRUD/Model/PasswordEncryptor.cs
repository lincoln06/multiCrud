﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model
{
    public class PasswordEncryptor
    {
        public static string Encrypt(string password, string email)
        {
            int[] numbersArray = new int[password.Length];
            char[] signsArray = new char[password.Length];
            string[] hexArray = new string[password.Length];
            for (int i = 0; i < password.Length; i++)
            {
                signsArray[i] = password[i];
                numbersArray[i] = (int)signsArray[i] + password.Length + email.Length;
                hexArray[i] = numbersArray[i].ToString("X");
            }
            return string.Join("", hexArray).ToString();
        }
    }
}
