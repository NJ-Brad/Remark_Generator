using System.Text;

namespace Remark_Generator.Types
{
    internal class Slide
    {
        // https://github.com/gnab/remark/wiki/Markdown#slide-properties
        // name: page_1
        public string Name { get; set; }
        // class: center, middle
        public string HorizontalAlignment { get; set; } = "left"; // left, center, right
        public string VerticalAlignment { get; set; } = "top"; // top, middle, bottom
        public string ExtraClasses { get; set; } = "";
        // background-image: url(image.jpg)
        public string BackgroundImage { get; set; } = "";
        // count: false
        public bool IncludeInSlideCount { get; set; } = false;
        // template: other-slide
        public string Template { get; set; } = "";
        // layout: true
        public string LayoutSlide { get; set; } = "Existing";   // "New" = This is a new layout | "Existing" = don't include this attribute, uses existing layout | "Clear" = cluar defined layout (layout: false)
        public bool IsContinuation { get; set; } = false;
        public string Content { get; set; } = "";
        public string Notes { get; set; } = "";

        public string ToDocumentString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Name))
            {
                sb.AppendLine($"name: {Name}");
            }

            if (!string.IsNullOrEmpty(Template))
            {
                sb.AppendLine($"Template: {Template}");
            }

            if (!string.IsNullOrEmpty(ExtraClasses))
            {
                sb.AppendLine($"class: {HorizontalAlignment}, {VerticalAlignment}, {ExtraClasses}");
            }
            else
            {
                sb.AppendLine($"class: {HorizontalAlignment}, {VerticalAlignment}");
            }

            switch (LayoutSlide)
            {
                case "New":
                    sb.AppendLine("layout: true");
                    break;
                case "Clear":
                    sb.AppendLine("layout: false");
                    break;
            }

            sb.AppendLine($"count: {IncludeInSlideCount}");

            if (!string.IsNullOrEmpty(BackgroundImage))
            {
                sb.AppendLine($"background-image: url({BackgroundImage})");
            }

            sb.AppendLine(AddContent());

            if (!string.IsNullOrEmpty(Notes))
            {
                sb.AppendLine(@$"
???

{Notes}
");
            }

            return sb.ToString();
        }

        public virtual string AddContent()
        {
            return Content;
        }
    }
}
