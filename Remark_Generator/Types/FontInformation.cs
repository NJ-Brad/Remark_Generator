namespace Remark_Generator.Types
{
    internal class FontInformation
    {
        public string Name { get; set; } = "";
        public string Style { get; set; } = "normal";   // (normal|italic)
        public string Weight { get; set; } = "normal";  // (normal|bold|100|200|300|400|500|600|700|800|900
        public List<FontSource> Sources { get; set; } = new List<FontSource>();
    }
}
