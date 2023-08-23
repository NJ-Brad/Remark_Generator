using System.Text;

namespace Remark_Generator.Types
{
    internal class IntroSlide : Slide
    {
        public IntroSlide()
        {
            Name = "Intro";
            HorizontalAlignment = "center";
            VerticalAlignment = "middle";
            ExtraClasses = "inverse";
        }

        public string Title { get; set; } = "Title";
        public string SubTitle1 { get; set; } = "Sub-Title 1";
        public string SubTitle2 { get; set; } = "Sub-Title 2";

        public override string AddContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"# {Title}");
            sb.AppendLine($"## {SubTitle1}");
            sb.AppendLine($"### {SubTitle2}");

            return sb.ToString();
        }
    }
}
