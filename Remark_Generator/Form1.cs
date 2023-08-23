using Remark_Generator.Types;
using System.Reflection;

namespace Remark_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private Presentation presentation = new();

        // left and right align on the same line : https://stackoverflow.com/questions/12438339/how-may-i-align-text-to-the-left-and-text-to-the-right-in-the-same-line
        // .pull-left and .pull-right are available, built in
        // Themes are discussed here : https://github.com/PierreMarchand20/presac
        // Excellent styling information, as well as a preview of some themes : https://github.com/yihui/xaringan/wiki/Themes
        // Nice themes and layout tips : https://github.com/1-2-3/remark-it/blob/master/README-en_US.md
        // Resources : https://github.com/remarkjs/awesome-remark
        // Configuration : https://github.com/gnab/remark/wiki/Configuration#general

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://remarkjs.com/downloads/remark-latest.min.js").Result;
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string fileContent = await response.Content.ReadAsStringAsync();
                    File.WriteAllText("C:\\Users\\Brad\\Remark\\remark.js", fileContent);
                }
            }

            string p = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            File.Copy(Path.Combine(p, "fonts\\DroidSerif-Regular.ttf"), @"c:\users\brad\remark\DroidSerif-Regular.ttf", true);
            File.Copy(Path.Combine(p, "fonts\\UbuntuMono-Regular.ttf"), @"c:\users\brad\remark\UbuntuMono-Regular.ttf", true);
            File.Copy(Path.Combine(p, "fonts\\YanoneKaffeesatz-Regular.ttf"), @"c:\users\brad\remark\YanoneKaffeesatz-Regular.ttf", true);
            //File.Copy(Path.Combine(p, "boilerplate-local.html"), @"c:\users\brad\remark\output.html", true);

            string top = File.ReadAllText(Path.Combine(p, "top.html")).Replace("%%TITLE%%", "Brad is getting it done");
            string bottom = File.ReadAllText(Path.Combine(p, "bottom.html"));

            //            string middle = @"
            //class: center, middle

            //# My Awesome Presentation

            //???

            //Notes for the _first_ slide!

            //---

            //# Agenda

            //1. Introduction
            //2. Deep-dive
            //3. ...

            //[NOTE]: Note that you need remark.js alongside this html file, but no internet connection.
            //---

            //# Introduction
            //---
            //layout: false
            //.left-column[
            //  ## What is it?
            //]
            //.right-column[
            //  A simple, in-browser, Markdown-driven slideshow tool targeted at people who know their way around HTML and CSS, featuring:

            //- Markdown formatting, with smart extensions

            //....
            //]";

            string middle = File.ReadAllText(Path.Combine(p, "middle-test.html"));

            string result = string.Join(Environment.NewLine, top, middle, bottom);

            File.WriteAllText(@"c:\users\brad\remark\output2.html", result);

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = @"c:\users\brad\remark\output2.html";
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync("https://remarkjs.com/downloads/remark-latest.min.js").Result;
            //if (response != null)
            //{
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string fileContent = await response.Content.ReadAsStringAsync();
            //        File.WriteAllText("C:\\Users\\Brad\\Remark\\remark.js", fileContent);
            //    }
            //}

            string p = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            //File.Copy(Path.Combine(p, "fonts\\DroidSerif-Regular.ttf"), @"c:\users\brad\remark\DroidSerif-Regular.ttf", true);
            //File.Copy(Path.Combine(p, "fonts\\UbuntuMono-Regular.ttf"), @"c:\users\brad\remark\UbuntuMono-Regular.ttf", true);
            //File.Copy(Path.Combine(p, "fonts\\YanoneKaffeesatz-Regular.ttf"), @"c:\users\brad\remark\YanoneKaffeesatz-Regular.ttf", true);

            //            string theme = File.ReadAllText(Path.Combine(p, "default.css"));
            string theme = File.ReadAllText(Path.Combine(p, "blueprint.css"));

            string top = File.ReadAllText(Path.Combine(p, "top.html")).Replace("%%TITLE%%", "Brad is getting it done").Replace("%%THEME%%", theme); ;
            string bottom = File.ReadAllText(Path.Combine(p, "bottom.html"));

            //            string middle = @"
            //class: center, middle

            //# My Awesome Presentation

            //???

            //Notes for the _first_ slide!

            //---

            //# Agenda

            //1. Introduction
            //2. Deep-dive
            //3. ...

            //[NOTE]: Note that you need remark.js alongside this html file, but no internet connection.
            //---

            //# Introduction
            //---
            //layout: false
            //.left-column[
            //  ## What is it?
            //]
            //.right-column[
            //  A simple, in-browser, Markdown-driven slideshow tool targeted at people who know their way around HTML and CSS, featuring:

            //- Markdown formatting, with smart extensions

            //....
            //]";

            //            string middle = File.ReadAllText(Path.Combine(p, "middle-test.html"));
            //string middle = Generate();
            string middle = presentation.ToDocumentString();

            string result = string.Join(Environment.NewLine, top, middle, bottom);

            File.WriteAllText(@"c:\users\brad\remark\output2.html", result);

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = @"c:\users\brad\remark\output2.html";
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        private string Generate()
        {
            string rtnVal = "";

            rtnVal = @"
            class: center, middle

            # My Awesome Presentation

            ???

            Notes for the _first_ slide!

            ---

            # Agenda

            1. Introduction
            2. Deep-dive
            3. ...

            [NOTE]: Note that you need remark.js alongside this html file, but no internet connection.
            ---

            # Introduction
            ---
            layout: false
            .left-column[
                ## What is it?
            ]
            .right-column[
                A simple, in-browser, Markdown-driven slideshow tool targeted at people who know their way around HTML and CSS, featuring:

            - Markdown formatting, with smart extensions

            ....
            ]";


            return rtnVal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            presentation.slides.Add(new IntroSlide() { Title = "Presentation Title", SubTitle1 = "Brad Bruce", SubTitle2 = DateTime.Now.ToString(), Notes = " Notes for the _first_ slide!" });
            presentation.slides.Add(new Slide()
            {
                Content = @"# Agenda

1. Introduction
2. Deep - dive
3. ...

[NOTE]: Note that you need remark.js alongside this html file, but no internet connection.
"
            });

            presentation.slides.Add(new Slide()
            {
                Content = @"
# Introduction

*italic*

"
            });

            presentation.slides.Add(new Slide()
            {
                LayoutSlide = "Clear",
                Content = @"
.left-column[
                ## What is it?
            ]
.right-column[
            A simple, in -browser, Markdown - driven slideshow tool targeted at people who know their way around HTML and CSS, featuring:
            -Markdown formatting, with smart extensions....
        ]"
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //            theme.Fonts.Clear();

            //            FontInformation fi = new();
            //            fi.Name = "Droid Serif";

            //            FontSource fs = new FontSource();
            //            fs.IsLocal = false;
            //            fs.Location = "DroidSerif-Regular.ttf";
            //            fi.Sources.Add(fs);

            //            theme.Fonts.Add(fi);

            //            theme.Styling = @"
            //.remark-code, .remark-inline-code { font-family: 'Ubuntu Mono'; }

            //body {
            //    font-family: 'Droid Serif';
            //}

            //h1, h2, h3 {
            //  font-family: 'Yanone Kaffeesatz';
            //  font-weight: 400;
            //  margin-bottom: 0;
            //}

            //.remark-slide-content h1 {
            //  font-size: 3em;
            //}

            //.remark-slide-content h2 {
            //  font-size: 2em;
            //}

            //.remark-slide-content h3 {
            //  font-size: 1.6em;
            //}

            //.footnote {
            //  position: absolute;
            //  bottom: 3em;
            //}

            //li p {
            //  line-height: 1.25em;
            //}

            //.red {
            //  color: #fa0000;
            //}

            //.large {
            //  font-size: 2em;
            //}

            //a, a > code {
            //  color: rgb(249, 38, 114);
            //  text-decoration: none;
            //}

            //code {
            //  background: #e7e8e2;
            //  border-radius: 5px;
            //}

            //.remark-code, .remark-inline-code {
            //  font-family: 'Ubuntu Mono';
            //}

            //.remark-code-line-highlighted {
            //  background-color: #373832;
            //}

            //.pull-left {
            //  float: left;
            //  width: 47%;
            //}

            //.pull-right {
            //  float: right;
            //  width: 47%;
            //}

            //.pull-right ~ p {
            //  clear: both;
            //}

            //#slideshow .slide .content code {
            //  font-size: 0.8em;
            //}

            //#slideshow .slide .content pre code {
            //  font-size: 0.9em;
            //  padding: 15px;
            //}

            //.inverse {
            //  background: #272822;
            //  color: #777872;
            //  text-shadow: 0 0 20px #333;
            //}

            //.inverse h1, .inverse h2 {
            //  color: #f3f3f3;
            //  line-height: 0.8em;
            //}
            //";
            //            var options = new JsonSerializerOptions { WriteIndented = true };
            //            File.WriteAllText("Sample.theme", System.Text.Json.JsonSerializer.Serialize(theme, options));
        }
    }
}
