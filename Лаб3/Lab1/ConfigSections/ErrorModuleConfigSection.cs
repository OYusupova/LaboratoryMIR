using System.Configuration;

namespace Lab.ConfigSections
{

    public class ErrorModuleConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Ключевые слова
        /// </summary>
        [ConfigurationProperty("Keys")]
        public KeysCollection Keys
        {
            get
            {
                return this["Keys"] as KeysCollection;
            }
        }
        /// <summary>
        /// Сообщение отображаемоемое при нахождении ключевых слов
        /// </summary>
        [ConfigurationProperty("Message")]
        public Message Message
        {
            get { return this["Message"] as Message; }
        }
    }

    public class KeysCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Key();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Key)element).Value;
        }
    }

    /// <summary>
    /// Элемент секции конфига содержащий ключ
    /// </summary>
    public class Key : ConfigurationElement
    {
        /// <summary>
        /// Значение ключа
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true, IsKey = true)]
        public string Value
        {
            get
            {
                return this["value"] as string;
            }
        }
    }

    /// <summary>
    /// Элемент секции конфига содержащий сообщение отображаемое при нахождении ключа
    /// </summary>
    public class Message : ConfigurationElement
    {
        /// <summary>
        /// Сообщение
        /// </summary>
        [ConfigurationProperty("value", IsRequired = true, IsKey = true)]
        public string Value
        {
            get
            {
                return this["value"] as string;
            }
        }
    }
}