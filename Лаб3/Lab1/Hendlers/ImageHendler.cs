using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab.Hendlers
{
    public class ImageHendler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var imagesDir = HttpContext.Current.Server.MapPath("~/Images");
                var images = Directory.GetFiles(imagesDir).Select(x=>new {Name = Path.GetFileNameWithoutExtension(x),Path = x});
                var fileName = Path.GetFileNameWithoutExtension(context.Request.FilePath);
                var filePath = images.FirstOrDefault(x => x.Name == fileName).Path;
                var img = Image.FromFile(filePath);
                
                OverlayText(img, "Lab 3", Color.Red, new Font("Arial", 8), new Point(0, 0));

                var stream = new MemoryStream();
                img.Save(stream, ImageFormat.Png);
                stream.Flush();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(stream.ToArray());
                context.ApplicationInstance.CompleteRequest();
                context.Response.End();
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 404;
            }

        }

        /// <summary>
        /// Наложить тект на изображение
        /// </summary>
        /// <param name="img">Изображение</param>
        /// <param name="text">Текст</param>
        /// <param name="color">Цвет текста</param>
        /// <param name="font">Шрифт</param>
        /// <param name="point">Координаты текста на изображении</param>
        private static void OverlayText(Image img, string text, Color color, Font font, Point point)
        {
            using (var g = Graphics.FromImage(img))
            {
                g.DrawString(text, font, new SolidBrush(color), point);
            }
        }

        public bool IsReusable { get; private set; }
    }
}