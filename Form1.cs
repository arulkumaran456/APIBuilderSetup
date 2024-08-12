using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace APIBuilderSetup;

public partial class Form1 : MaterialForm
{
    private const string DEVELOPER_BRANCH_NAME = "dev";
    private readonly Log logger;
    public Form1()
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        InitializeComponent();
        logger = new Log(richTextBox1, ddlProject);
    }

    public void CloneRepo(string repositoryUrl, string localRepoPath, string userName, string password)
    {
        try
        {
            var options = new CloneOptions
            {
                FetchOptions =
                {
                    CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials
                    {
                        Username = userName,
                        Password = password
                    }
                }
            };
            logger.Append("Cloning the repo " + repositoryUrl + "", Log.Type.Info, Color.Black);
            Repository.Clone(repositoryUrl, localRepoPath, options);
            logger.Append("Cloning completed. " + repositoryUrl + "", Log.Type.Info, Color.Green);
        }
        catch (LibGit2SharpException ex)
        {
            logger.Append("Error while Cloning the repo " + repositoryUrl + "", Log.Type.Error, Color.Red);
            logger.Append(ex.Message, Log.Type.Error, Color.Red);
            throw;
        }
    }

    private void Pull(string localRepoPath, string userName, string password)
    {
        try
        {
            logger.Append("Pulling the Latest code from repository " + localRepoPath + "", Log.Type.Info, Color.Black);
            var options = new PullOptions
            {
                FetchOptions = new FetchOptions()
            };
            options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                (url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials()
                    {
                        Username = userName,
                        Password = password
                    });
            options.MergeOptions = new MergeOptions
            {
                FastForwardStrategy = FastForwardStrategy.Default,
                OnCheckoutNotify = new CheckoutNotifyHandler(Showconflict),
                CheckoutNotifyFlags = CheckoutNotifyFlags.Conflict
            };
            using (var repo = new Repository(localRepoPath))
            {
                var signature = repo.Config.BuildSignature(DateTimeOffset.Now);
                var result = Commands.Pull(repo, signature, options);
                if (result.Status == MergeStatus.Conflicts)
                {
                    logger.Append("Conflict detected " + localRepoPath + "", Log.Type.Info, Color.Red);
                    return;
                }
                if (result.Status == MergeStatus.UpToDate)
                {
                    logger.Append("Code is upto date " + localRepoPath + "", Log.Type.Info, Color.Green);
                    return;
                }
            }
            logger.Append("Pull Successfull " + localRepoPath + "", Log.Type.Info, Color.DarkGreen);
        }
        catch (Exception ex)
        {
            logger.Append("Error while Pullinh the repo " + localRepoPath + "", Log.Type.Error, Color.Red);
            logger.Append(ex.Message, Log.Type.Error, Color.Red);
            throw;
        }
    }
    private bool Showconflict(string path, CheckoutNotifyFlags notifyFlags)
    {
        if (notifyFlags is CheckoutNotifyFlags.Conflict)
        {
            logger.Append("Conflict found in file : " + path + ". Please resolve", Log.Type.Error, Color.Red);
        }
        return true;
    }

    private void LoadProjectListIntoDropdown(GitResponseModel? projectList)
    {
        if (projectList is GitResponseModel && projectList.values.Count > 0)
        {
            List<GitCloneModel> cloneList = [];
            foreach (var project in projectList.values)
            {
                cloneList.Add(new()
                {
                    ProjectName = project.name,
                    CloneUrl = project.links.clone.Where(t => t.name == "http").Select(t => t.href).FirstOrDefault()
                });
            }
            ddlTargetRepo.ValueMember = "CloneUrl";
            ddlTargetRepo.DisplayMember = "ProjectName";
            ddlTargetRepo.DataSource = Clone(cloneList);

            ddlTemplateRepo.ValueMember = "CloneUrl";
            ddlTemplateRepo.DisplayMember = "ProjectName";
            ddlTemplateRepo.DataSource = Clone(cloneList);
            logger.Append(cloneList.Count + " repos fetched.", Log.Type.Info, Color.Blue);
        }
    }

    static List<T> Clone<T>(IEnumerable<T> oldList)
    {
        return new List<T>(oldList);
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

    private void CreateIfMissing(string path, string cloneUrl)
    {
        if (!Directory.Exists(path))
        {
            logger.Append("Creating directory -  " + path + "", Log.Type.Info, Color.Black);
            Directory.CreateDirectory(path);
            CreateBranch(DEVELOPER_BRANCH_NAME);
            CloneRepo(cloneUrl, path, txtUserName.Text + lblDomain.Text, txtAccessToken.Text);
            Pull(path, txtUserName.Text + lblDomain.Text, txtAccessToken.Text);
            Checkout(path, DEVELOPER_BRANCH_NAME);
        }
        else
        {
            logger.Append("Selected project already cloned  " + path + "", Log.Type.Info, Color.Black);
            richTextBox1.Refresh();
            Pull(path, txtUserName.Text + lblDomain.Text, txtAccessToken.Text);
            Checkout(path, DEVELOPER_BRANCH_NAME);
        }
    }
    private bool DevBranchExist()
    {
        var token = Base64Encode(txtUserName.Text + lblDomain.Text + ":" + txtAccessToken.Text);
        using var clint = new HttpClient();
        clint.DefaultRequestHeaders.Add("Accept", "application/json");
        clint.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

        var apiResult = clint.GetAsync("https://bitbucket.biscrum.com/rest/api/latest/projects/" + ddlProject.SelectedItem.ToString() + "/repos/" + ddlTargetRepo.Text + "/branches").Result;
        if (apiResult.IsSuccessStatusCode)
        {
            var commitItems = JsonConvert.DeserializeObject<CommitModel>(apiResult.Content.ReadAsStringAsync().Result);
            if (commitItems is not null && commitItems.Values is not null && commitItems.Values.Count > 0)
                return commitItems.Values.FirstOrDefault(t => t.displayId == DEVELOPER_BRANCH_NAME) != null;
            else
                return false;
        }
        return false;
    }
    public void CreateBranch(string branchName)
    {
        try
        {
            if (!DevBranchExist())
            {
                logger.Append(branchName + " branch not found. Creating the branch...", Log.Type.Info, Color.Black);
                var commitId = GetCommitId();
                if (commitId != string.Empty)
                {
                    CreateDevBranch(branchName, commitId);
                }
            }
            else
            {
                logger.Append(branchName + " branch already exist. Skipping the branch creation step", Log.Type.Info, Color.Blue);
            }
        }
        catch (Exception ex)
        {
            logger.Append(branchName + " Branch creation failed." + ex.Message, Log.Type.Error, Color.Red);
            throw;
        }
    }
    private bool CreateDevBranch(string branchName, string latestCommitId)
    {
        var token = Base64Encode(txtUserName.Text + lblDomain.Text + ":" + txtAccessToken.Text);
        using var clint = new HttpClient();
        clint.DefaultRequestHeaders.Add("Accept", "application/json");
        clint.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        var body = new
        {
            message = "created by template system",
            name = branchName,
            startPoint = latestCommitId
        };
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var apiResult = clint.PostAsync("https://bitbucket.biscrum.com/rest/api/latest/projects/" + ddlProject.SelectedItem.ToString() + "/repos/" + ddlTargetRepo.Text + "/branches", httpContent).Result;
        if (apiResult.IsSuccessStatusCode)
        {
            logger.Append(branchName + " branch created", Log.Type.Info, Color.Green);
        }
        else
        {
            logger.Append(apiResult.StatusCode.ToString() + " - " + branchName + " branch creation failed", Log.Type.Error, Color.Red);
        }
        return true;
    }
    private string GetCommitId()
    {
        var token = Base64Encode(txtUserName.Text + lblDomain.Text + ":" + txtAccessToken.Text);
        using var clint = new HttpClient();
        clint.DefaultRequestHeaders.Add("Accept", "application/json");
        clint.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        var apiResult = clint.GetAsync("https://bitbucket.biscrum.com/rest/api/latest/projects/" + ddlProject.SelectedItem.ToString() + "/repos/" + ddlTargetRepo.Text + "/commits").Result;
        if (apiResult.IsSuccessStatusCode)
        {
            var commitItems = Newtonsoft.Json.JsonConvert.DeserializeObject<CommitModel>(apiResult.Content.ReadAsStringAsync().Result);
            if (commitItems is not null && commitItems.Values is not null && commitItems.Values.Count > 0)
                return commitItems.Values[0].id;
            else
                return string.Empty;
        }
        return string.Empty;
    }

    private string GetTemplateType()
    {
        if (rdbTrigger.Checked)
            return "trigger";
        else if (rdbService.Checked)
            return "service";
        else if (rdbOtherProject.Checked)
            return "docker\\dist\\";
        return "";
    }

    private void OpenFileSelecitonWindow()
    {
        selectRequiredFiles(this, (List<FolderNode>? selectedFiles) =>
        {
            if (selectedFiles is not null && selectedFiles.Count > 0)
            {
                CopyFiles(selectedFiles);
                MessageBox.Show("Templates are Copied Successfully");
                logger.Append("Template Copied from Source Repository to Target Repository", Log.Type.Info, Color.Green);

                btnNpmStart.Enabled = true;
            }
            else
            {
                logger.Append("No file selected from Source repo", Log.Type.Info, Color.Black);
            }
        });
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        txtUserName.Text = "arulkumar.ponnusamy.ext";
        txtUserName.BackColor = Color.White;
        txtAccessToken.BackColor = Color.White;
        txtAccessToken.Text = "Cutebrain@123456789";
        ddlProject.BackColor = Color.White;
        ddlTargetRepo.BackColor = Color.White;
        ddlTemplateRepo.BackColor = Color.White;
        richTextBox1.BackColor = Color.White;
        RepositoryGroupBox.Enabled = false;
        btnNpmStart.Enabled = false;
        BtnRevealExplorer.Enabled = false;
    }

    private void CopyFiles(List<FolderNode>? files)
    {
        foreach (var item in files)
        {
            var exePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ApiBuilderProjects\\";
            if (item.IsRoot)
            {
                var sourcePath = exePath + item.FullPath;
                var targetPath = exePath + ddlTargetRepo.Text;
                foreach (var file in item.Files)
                {
                    string sourceFile = Path.Combine(sourcePath, file.Name);
                    string destFile = Path.Combine(targetPath, file.Name);
                    System.IO.File.Copy(sourceFile, destFile, true);
                    logger.Append("Copying file " + file.Name + " from " + sourceFile + " to " + destFile, Log.Type.Info, Color.Black);
                }
            }
            else
            {
                var sourcePath = exePath + item.FullPath;
                var targetPath = exePath + ddlTargetRepo.Text + "\\docker\\dist\\";
                if (!Directory.Exists(targetPath))
                {
                    logger.Append("Creating folder " + targetPath, Log.Type.Info, Color.Black);
                    Directory.CreateDirectory(targetPath);
                }
                foreach (var file in item.Files)
                {
                    if (item.CreateSubFolder)
                    {
                        targetPath = exePath + ddlTargetRepo.Text + "\\docker\\dist\\" + item.Name;
                        if (!Directory.Exists(targetPath))
                        {
                            logger.Append("Creating sub folder " + targetPath, Log.Type.Info, Color.Black);
                            Directory.CreateDirectory(targetPath);
                        }
                    }
                    string sourceFile = Path.Combine(sourcePath, file.Name);
                    string destFile = Path.Combine(targetPath, file.Name);
                    System.IO.File.Copy(sourceFile, destFile, true);
                    logger.Append("Copying file " + file.Name + " from " + sourceFile + " to " + destFile, Log.Type.Info, Color.Black);
                }
            }
        }
    }

    private void selectRequiredFiles(Form frmParent, Action<List<FolderNode>?> callback)
    {
        try
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path += "\\ApiBuilderProjects\\" + ddlTemplateRepo.Text;
            if (!Directory.Exists(path + "\\" + GetTemplateType()))
            {
                MessageBox.Show("Selected Source Respository is not a Template Kind. Please Select the template type as 'Other Project' for this", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            logger.Append("Waiting for user to select the required file from " + path, Log.Type.Info, Color.Black);
            SelectFiles frmDialog = new(path, "\\" + GetTemplateType());
            frmDialog.FormClosed += (object closeSender, FormClosedEventArgs closeE) =>
            {
                frmDialog.Dispose();
                frmDialog = null;
            };
            frmDialog.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                if (frmDialog.DialogResult == DialogResult.OK)
                    callback(frmDialog.SelectedFiles);
                else
                    callback(null);
            };
            frmDialog.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error Occured while Applying the template - " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Checkout(string localRepoPath, string branchName)
    {
        logger.Append(branchName + " branch check out in-progress...", Log.Type.Info, Color.Black);
        using Process process = new();
        ProcessStartInfo startInfo = new()
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardError = false,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            FileName = "cmd.exe",
            Arguments = "/c cd " + localRepoPath + " & git checkout " + branchName + "",
            Verb = "runas"
        };
        process.StartInfo = startInfo;
        process.Start();
        Thread.Sleep(3000);
        logger.Append(branchName + " branch check out completed", Log.Type.Info, Color.Green);
    }

    private void richTextBox_TextChanged(object sender, EventArgs e)
    {
        richTextBox1.SelectionStart = richTextBox1.Text.Length;
        richTextBox1.ScrollToCaret();
    }

    private void OpenFolder(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = folderPath,
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
        else
        {
            MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath), "Not Found Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnLogin_Click(object sender, EventArgs e)
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
            logger.Append("Bitbucket Login Started...", Log.Type.Info, Color.Black);
            var token = Base64Encode(txtUserName.Text + lblDomain.Text + ":" + txtAccessToken.Text);
            using var clint = new HttpClient();
            clint.DefaultRequestHeaders.Add("Accept", "application/json");
            clint.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

            var apiResult = clint.GetAsync("https://bitbucket.biscrum.com/rest/api/latest/repos?projectkey=" + ddlProject.SelectedItem.ToString() + "&archived=ACTIVE&avatarSize=48&start=0&limit=1000").Result;
            if (apiResult.IsSuccessStatusCode)
            {
                logger.Append("Bitbucket Login Success..", Log.Type.Info, Color.Green);
                logger.Append("Fetching all the Projects..", Log.Type.Info, Color.Black);
                var projectList = Newtonsoft.Json.JsonConvert.DeserializeObject<GitResponseModel>(apiResult.Content.ReadAsStringAsync().Result);
                LoadProjectListIntoDropdown(projectList);
                logger.Append("Projects Loaded in Dropdown..", Log.Type.Info, Color.Black);
                RepositoryGroupBox.Enabled = true;
                BtnRevealExplorer.Enabled = true;
            }
            else
            {
                logger.Append(apiResult.StatusCode.ToString(), Log.Type.Error, Color.Red);
            }
        }
        Cursor.Current = Cursors.Default;
    }

    private void btnApplyTemplate_Click_1(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(GetTemplateType()))
            {
                MessageBox.Show("Select the Template Type", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                var exePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ApiBuilderProjects\\";
                //CreateIfMissing(exePath + ddlTemplateRepo.Text, ((GitCloneModel)ddlTemplateRepo.SelectedItem).CloneUrl);
                CreateIfMissing(exePath + ddlTargetRepo.Text, ((GitCloneModel)ddlTargetRepo.SelectedItem).CloneUrl);
                Cursor.Current = Cursors.Default;
                OpenFileSelecitonWindow();
            }
        }
        catch (Exception excpt)
        {
            MessageBox.Show(excpt.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Cursor.Current = Cursors.Default;
    }

    private void btnNpmStart_Click_1(object sender, EventArgs e)
    {
        var exePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ApiBuilderProjects\\";
        var targetPath = exePath + ddlTargetRepo.Text + "\\docker\\dist\\";
        using Process process = new();
        ProcessStartInfo startInfo = new()
        {
            WindowStyle = ProcessWindowStyle.Normal,
            RedirectStandardError = false,
            UseShellExecute = true,
            RedirectStandardOutput = false,

            FileName = "cmd.exe",
            Arguments = "/env /user:" + "Administrator /k cd " + targetPath + " & npm update & npm start",
            Verb = "runas"
        };
        process.StartInfo = startInfo;
        process.Start();
    }

    private void BtnRevealExplorer_Click(object sender, EventArgs e)
    {
        var exePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ApiBuilderProjects\\";
        var targetPath = exePath + ddlTargetRepo.Text;
        OpenFolder(targetPath);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        richTextBox1.Clear();
    }
}

