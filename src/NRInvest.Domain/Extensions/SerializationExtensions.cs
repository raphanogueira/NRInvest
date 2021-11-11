using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NRInvest.Domain.Extensions
{
    public static class SerializationExtensions
    {
        public static byte[] ToByteArray(this object obj)
        {
            if (obj is null)
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream();

            binaryFormatter.Serialize(memoryStream, obj);

            return memoryStream.ToArray();
        }
        public static T FromByteArray<T>(this byte[] byteArray) where T : class
        {
            if (byteArray is null)
                return default;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream(byteArray);

            return binaryFormatter.Deserialize(memoryStream) as T;
        }

    }
}