using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace eChobits {
    static class Serialization {
        /*
            **Generic methods Serialize and Deserialize**
            
            An example of setting order for xml element:
            [XmlElement(Order = 2, ElementName = "Tags")]

            [System.Xml.Serialization.XmlIgnoreAttribute]
            1. ignore parameters that are not supposed to be serialized
            2. if a field is uninitialized, it should not be serialized either
        
        */        
        /// <summary>
        /// Serialize with specific type List<T>, return serialized String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public static string Serialize<T>(this List<T> toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            /*
            Alternative:
            using (var streamWriter = File.OpenWrite(path)) {
                xmlSerializer.Serialize(streamWriter, toSerialize);
            }
            */

            return textWriter.ToString();
        }

        /// <summary>
        /// Serialize with specific type T, return serialized String
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);

            return textWriter.ToString();
        }

        /// <summary>
        /// Derialize with specific type List, return object type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toDeserialize"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string toDeserialize) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamReader streamReader = new StreamReader(toDeserialize);

                return (T)xmlSerializer.Deserialize(streamReader);
            }
            catch (InvalidOperationException e) {
                // file does not exist, return default(T) instead of null because some types cannot be null
                return default(T);
            }
        }
    }
}
