

namespace Tools
{
    public enum RegisterType
    {
        Car,
        Character,
        Building
    }
    
    public class Register
    {
        private RegisterType type;
        private string comment;
        private int value;

        public Register(RegisterType registerType, string s, int i)
        {
            type = registerType;
            comment = s;
            value = i;
        }

        public string GetContent()
        {
            string content = type.ToString() + " ["+comment+"] " + value.ToString() + "\n";
            return content;
        }

    }
}
