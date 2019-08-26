using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CaptchaSolver.Helper
{
    public class StringHelper
    {
        public static string ImageFileToBase64String(string path)
        {
            try
            {
                using (var image = Image.FromFile(path))
                {
                    using (var m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        var imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        var base64String = Convert.ToBase64String(imageBytes);

                        return base64String;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
