using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR_8001
{
    public class RegistryHelper
    {
        private static string sRegistryPath = @"HKEY_LOCAL_MACHINE\\SOFTWARE\\TR-8001";
        public static string getRegistryKey(string nameKey, string Default)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey(sRegistryPath);
                if (Key != null)
                {
                    return Key.GetValue(nameKey).ToString();
                }
                Key.Close();
            }
            catch (Exception) { }
            return Default;
        }

        public static void setRegistryKey(string nameKey, string Value)
        {
            RegistryKey Key = Registry.CurrentUser.CreateSubKey(sRegistryPath);
            try
            {
                if (Key != null)
                {
                    Key.SetValue(nameKey, Value);
                    Key.Close();
                }
            }
            catch (Exception)
            {
                MsgBox.ShowException($@"Can't set the key '{nameKey}' with value '{Value  }'", "Error", "OK", "Cancel");
            }
        }
    }
}
