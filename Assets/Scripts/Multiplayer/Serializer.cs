using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Multiplayer
{
    public static class Serializer
    {
        private static readonly IFormatter formatter = new BinaryFormatter();
        public const int GuidCode = 213;
        public const int PlayerCode = 214;

        public static byte[] SerializeGuid(object obj)
        {
            var guid = (Guid)obj;

            return guid.ToByteArray();
        }

        public static object DeserializeGuid(byte[] data)
        {
            var guid = new Guid(data);
            return guid;
        }

        public static byte[] SerializePlayer(object obj)
        {
            var player = (Player)obj;

            using var stream = new MemoryStream();
            formatter.Serialize(stream, player);
            var result = stream.ToArray();
            return result;
        }

        public static object DeserializePlayer(byte[] data)
        {
            using var memoryStream = new MemoryStream(data);
            var result = formatter.Deserialize(memoryStream);

            return result;
        }
    }
}
