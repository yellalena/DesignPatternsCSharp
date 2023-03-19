using System.Xml.Serialization;

namespace PrototypePattern
{
    interface IDeepCopyable<T>
    {
        T DeepCopy();
    }

    public class BaseDeepCopyable<T> : IDeepCopyable<T>
    {
        public T DeepCopy()
        {
            XmlSerializer ser = new(typeof(T));
            MemoryStream ms = new();
            ser.Serialize(ms, this);
            ms.Flush();
            ms.Position = 0;
            return (T)ser.Deserialize(ms);
        }
    }
}
