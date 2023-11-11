using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice1.Model;

namespace Practice1.Model
{
    internal class LabaConverter
    {
        public static T DeserializeObject<T>()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T obj = JsonConverter.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }

    }
}
