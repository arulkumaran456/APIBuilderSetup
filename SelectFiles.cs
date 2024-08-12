using System.Data;

namespace APIBuilderSetup;

public partial class SelectFiles : Form
{
    public List<FolderNode> SelectedFiles = [];
    FolderNode? folder = null;
    private readonly string _path = "";
    private readonly string _templateType = "";
    private readonly List<string> extensions = [".js", ".json", ".yaml", ".tgz", ".crt", ".env"];
    public SelectFiles(string path, string templateType)
    {
        _path = path;
        _templateType = templateType;
        InitializeComponent();
    }

    private static string GetDirectoryNameOnly(string path)
    {
        var paths = path.Split("\\");
        return paths[^1];
    }
    private void ListDirectories(string folder, TreeNode nod)
    {
        try
        {
            var files = Directory.GetFiles(folder);
            foreach (var file in files.Where(t => extensions.Contains(Path.GetExtension(t))))
            {
                TreeNode fileNode = new()
                {
                    Name = Path.GetFileName(file),
                    Text = Path.GetFileName(file),
                    Tag = Path.GetFileName(file)
                };
                nod.Nodes.Add(fileNode);
            }

            foreach (string directory in Directory.GetDirectories(folder))
            {
                if (!directory.EndsWith("node_modules") && !directory.EndsWith(".git") && !directory.EndsWith("test"))
                {
                    TreeNode subDirNode = new()
                    {
                        Name = GetDirectoryNameOnly(directory),
                        Text = GetDirectoryNameOnly(directory),
                        Tag = GetDirectoryNameOnly(directory)
                    };
                    ListDirectories(directory, subDirNode);
                    nod.Nodes.Add(subDirNode);
                }
            }
        }
        catch (Exception excpt)
        {
            MessageBox.Show(excpt.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var confirmResult = MessageBox.Show("Are you sure to apply this template??",
                                "Confirm!!",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmResult == DialogResult.Yes)
        {
            TreeNode oMainNode = treeView1.Nodes[0];
            PrintNodesRecursive(oMainNode);
            if (folder is not null)
            {
                SelectedFiles.Add(folder);
            }
            this.DialogResult = DialogResult.OK;
        }
    }

    private void SelectFiles_Load(object sender, EventArgs e)
    {
        TreeNode rootNode = new()
        {
            Name = GetDirectoryNameOnly(_path),
            Text = GetDirectoryNameOnly(_path),
            Tag = GetDirectoryNameOnly(_path)
        };
        var files = Directory.GetFiles(_path);
        foreach (var file in files.Where(t => extensions.Contains(Path.GetExtension(t)) || Path.GetFileName(t) == "Jenkinsfile"))
        {
            TreeNode fileNode = new()
            {
                Name = Path.GetFileName(file),
                Text = Path.GetFileName(file),
                Tag = Path.GetFileName(file)
            };
            rootNode.Nodes.Add(fileNode);
        }
        TreeNode subDirectoy = new()
        {
            Name = GetDirectoryNameOnly(_path + _templateType),
            Text = GetDirectoryNameOnly(_path + _templateType),
            Tag = GetDirectoryNameOnly(_path + _templateType)
        };
        ListDirectories(_path + _templateType, subDirectoy);
        rootNode.Nodes.Add(subDirectoy);
        treeView1.Nodes.Add(rootNode);
        treeView1.ExpandAll();
    }

    private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked)
        {
            CheckAllNodes(treeView1.Nodes);
        }
        else
        {
            UncheckAllNodes(treeView1.Nodes);
        }
    }
    private static void CheckAllNodes(TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            node.Checked = true;
            CheckChildren(node, true);
        }
    }

    private static void UncheckAllNodes(TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            node.Checked = false;
            CheckChildren(node, false);
        }
    }

    private static void CheckChildren(TreeNode rootNode, bool isChecked)
    {
        foreach (TreeNode node in rootNode.Nodes)
        {
            CheckChildren(node, isChecked);
            node.Checked = isChecked;
        }
    }

    public void PrintNodesRecursive(TreeNode oParentNode)
    {
        bool isRoot = false;
        if (oParentNode.Nodes.Count > 0 && !string.IsNullOrEmpty(oParentNode.Name) && oParentNode.Checked)
        {
            if (folder != null)
                SelectedFiles.Add(folder);
            else
                isRoot = true;

            folder = new()
            {
                IsRoot = isRoot,
                Name = oParentNode.Name,
                FullPath = oParentNode.FullPath,
                CreateSubFolder = (oParentNode.Name != "trigger" && oParentNode.Name != "service" && oParentNode.Name != "Jenkinsfile" && !oParentNode.Name.Contains('.'))
            };
        }
        else if (!string.IsNullOrEmpty(oParentNode.Name) && oParentNode.Checked)
        {
            folder.Files ??= [];
            folder.Files.Add(new()
            {
                Name = oParentNode.Name,
                FullPath = oParentNode.FullPath
            });
        }
        foreach (TreeNode oSubNode in oParentNode.Nodes)
        {
            PrintNodesRecursive(oSubNode);
        }
    }
}
