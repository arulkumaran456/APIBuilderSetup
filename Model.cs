namespace APIBuilderSetup;

public class Clone
{
    public string href { get; set; }
    public string name { get; set; }
}

public class CommitModel
{
    public List<Commit> Values { get; set; }
}
public class Commit
{
    public string id { get; set; }
    public string displayId { get; set; }
}


public class ReviewModel()
{
    public string FlowName { get; set; }
    public List<CodeActivity> Activities { get; set; }
}
public class CodeActivity
{
    public string ActivityName { get; set; }
    public string ActivityValue { get; set; }
}

public class FolderNode
{
    public string Name { get; set; }
    public bool IsRoot { get; set; }
    public bool CreateSubFolder { get; set; }
    public string FullPath { get; set; }
    public List<FolderNode> Files { get; set; }
}

public class Links
{
    public List<Self> self { get; set; }
    public List<Clone> clone { get; set; }
}

public class Project
{
    public string key { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public bool @public { get; set; }
    public string type { get; set; }
    public Links links { get; set; }
}

public class GitResponseModel
{
    public int size { get; set; }
    public int limit { get; set; }
    public bool isLastPage { get; set; }
    public List<Value> values { get; set; }
    public int start { get; set; }
    public int nextPageStart { get; set; }
}

public class GitCloneModel
{
    public string? ProjectName { get; set; }
    public string? CloneUrl { get; set; }
}

public class Self
{
    public string? href { get; set; }
}

public class Value
{
    public string slug { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string hierarchyId { get; set; }
    public string scmId { get; set; }
    public string state { get; set; }
    public string statusMessage { get; set; }
    public bool forkable { get; set; }
    public Project project { get; set; }
    public bool @public { get; set; }
    public bool archived { get; set; }
    public Links links { get; set; }
}

