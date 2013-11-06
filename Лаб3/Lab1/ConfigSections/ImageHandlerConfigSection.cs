using System.Configuration;

namespace Lab.ConfigSections
{
    public class ImageHandlerConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Путь до дирректории изображений
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get
            {
                return this["path"] as string;
            }
        }
        /// <summary>
        /// Текст размещаемый на изображениях
        /// </summary>
        [ConfigurationProperty("text")]
        public string Text
        {
            get
            {
                return this["text"] as string;
            }
        }
    }
}