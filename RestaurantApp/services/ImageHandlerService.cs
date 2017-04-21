using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.services
{
    class ImageHandlerService
    {
        public Image convertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                MemoryStream memstr = new MemoryStream(byteArray);
                Image img = Image.FromStream(memstr);
                return img;
            }
            return null;
        }

        public byte[] convertImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }   
    }
}
