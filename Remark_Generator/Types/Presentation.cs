using System.Text;

namespace Remark_Generator.Types
{
    internal class Presentation
    {
        public Presentation() { }

        public string Title { get; set; } = "Sample Presentation";
        public string Author { get; set; } = "Brad Bruce";
        public string Created { get; set; } = DateTime.Now.ToString();

        public List<Slide> slides { get; set; } = new List<Slide>();

        public string ToDocumentString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Slide slide in slides)
            {
                if (sb.Length > 0)
                {
                    if (slide.IsContinuation)
                        sb.AppendLine("--");
                    else
                        sb.AppendLine("---");
                }

                sb.AppendLine(slide.ToDocumentString());
            }

            return sb.ToString();
        }
    }
}
