namespace Metis.ItemMenu
{
    public class Modifier
    {
        public ModifierType Type;

        public float Value;

        public Modifier(ModifierType type, float value)
        {
            Type = type;
            Value = value;
        }
    }
}