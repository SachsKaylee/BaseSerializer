using System.Globalization;

namespace PatrickSachs.Serializer.Implementations
{
    public class UnsignedIntegerSerializer : IBaseSerializer
    {
        public static readonly UnsignedIntegerSerializer Instance = new UnsignedIntegerSerializer();

        public int Order => int.MaxValue - 1;

        public bool IsHandled(SerializationContext.Ref reference)
        {
            return reference.Type == typeof(uint);
        }

        public void Serialize(SerializationContext.Ref target, SerializationContext context)
        {
            uint integer = (uint) target.Object;
            target.Element.Value = integer.ToString(CultureInfo.InvariantCulture);
        }

        public object CreateInstance(SerializationContext.Ref source)
        {
            uint value = uint.Parse(source.Element.Value, CultureInfo.InvariantCulture);
            return value;
        }

        public void Deserialize(SerializationContext.Ref source, SerializationContext context)
        {
        }
    }
}
