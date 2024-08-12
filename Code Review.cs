using Jsbeautifier;
using MaterialSkin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace APIBuilderSetup
{
    public partial class Code_Review : MaterialSkin.Controls.MaterialForm
    {
        private static List<ReviewModel> ReviewList = new List<ReviewModel>();
        private static int FlowIndex = 0;
        private static int ActivityIndex = 0;
        public Code_Review()
        {
            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green400, Primary.Green500,
                Primary.Green500, Accent.LightGreen100,
                TextShade.WHITE
            );
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Enter the Email Id", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txtAccessToken.Text))
            {
                MessageBox.Show("Enter the Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ddlProject.SelectedItem == null || string.IsNullOrEmpty(ddlProject.SelectedItem.ToString()))
            {
                MessageBox.Show("Select the Project", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var token = Base64Encode(txtUserName.Text + lblDomain.Text + ":" + txtAccessToken.Text);
                using var clint = new HttpClient();
                clint.DefaultRequestHeaders.Add("Accept", "application/json");
                clint.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

                var apiResult = clint.GetAsync("https://bitbucket.biscrum.com/rest/api/latest/repos?projectkey=" + ddlProject.SelectedItem.ToString() + "&archived=ACTIVE&avatarSize=48&start=0&limit=1000").Result;
                if (apiResult.IsSuccessStatusCode)
                {

                }
                else
                {

                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var exePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ApiBuilderProjects\\omintctms-apibuilder-template-clinical\\trigger\\flows";
            var files = Directory.GetFiles(exePath);
            foreach (var file in files)
            {
                var ResultData = new ReviewModel();
                ResultData.Activities = new();
                var tst = File.ReadAllText(file);
                var json = JObject.Parse(tst);
                var result = json["nodes"].ToList();
                foreach (var ssss in result)
                {
                    var ddd = ssss;
                }

                XmlDocument doc = JsonConvert.DeserializeXmlNode(tst.ToString(), "root");
                var res = doc.SelectNodes("//nodes");

                ResultData.FlowName = (string)json.SelectToken("info.name");
                foreach (var nd in res)
                {
                    var child = ((System.Xml.XmlNode)nd).ChildNodes;
                    foreach (var ch in child)
                    {
                        var type = ((XmlNode)ch);
                        if (type.Name.StartsWith("javascript."))
                        {
                            foreach (var c in type.ChildNodes)
                            {
                                var n = ((XmlNode)c);
                                if (n.Name == "parameters" && n.OuterXml.StartsWith("<parameters><name>code</name><type>string</type><value>"))
                                {
                                    var dd = n.SelectNodes("value");
                                    var activity = new CodeActivity
                                    {
                                        ActivityName = type.ChildNodes[1].InnerXml,
                                        ActivityValue = dd[0].InnerText
                                    };
                                    ResultData.Activities.Add(activity);
                                }
                            }
                        }
                    }
                }
                ReviewList.Add(ResultData);
            }
            Jsbeautifier.Beautifier bea = new Jsbeautifier.Beautifier();
            lblFlowName.Text = ReviewList[0].FlowName;
            lblJSBlockName.Text = ReviewList[0].Activities[0].ActivityName;
            var plainValue = ReviewList[0].Activities[0].ActivityValue.Replace("\n", Environment.NewLine).Replace("\\n", Environment.NewLine).Replace("\"", "").Replace(System.Environment.NewLine, "").Replace("\\", "\"");
            richTextBox1.Text = bea.Beautify(plainValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ReviewList[FlowIndex].Activities.Count == ActivityIndex + 1)
            {
                FlowIndex++;
                ActivityIndex = 0;
            }
            else
            {
                ActivityIndex++;
            }
            Jsbeautifier.Beautifier bea = new Jsbeautifier.Beautifier();
            bea.Opts.IndentSize = 4;
            bea.Opts.IndentChar = ' ';
            bea.Opts.JslintHappy = true;
            bea.Opts.KeepArrayIndentation = false;
            bea.Opts.BraceStyle = BraceStyle.Collapse;
            bea.Flags.IndentationLevel = 0;
            bea.Opts.BreakChainedMethods = false;
            bea.Opts.PreserveNewlines = false;
            bea.Flags.InHtmlComment = true;

            var plainValue = ReviewList[FlowIndex].Activities[ActivityIndex].ActivityValue.Replace("\n", Environment.NewLine).Replace("\\n", Environment.NewLine).Replace("\"", "").Replace(System.Environment.NewLine, "").Replace("\\", "\"");
            lblFlowName.Text = ReviewList[FlowIndex].FlowName;
            lblJSBlockName.Text = ReviewList[FlowIndex].Activities[ActivityIndex].ActivityName;
            richTextBox1.Text = bea.Beautify(plainValue);
        }
    }
}
