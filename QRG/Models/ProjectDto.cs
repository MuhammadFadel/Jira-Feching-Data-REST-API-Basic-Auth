using Newtonsoft.Json;

namespace QRG.Models
{
    public class ProjectDto
    {
        public string expand { get; set; }
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string description { get; set; }
        public Lead lead { get; set; }
        public List<Component> components { get; set; }
        public List<IssueType> issueTypes { get; set; }
        public string url { get; set; }
        public string email { get; set; }
        public string assigneeType { get; set; }
        public List<Version> versions { get; set; }
        public string name { get; set; }
        public Roles roles { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public ProjectCategory projectCategory { get; set; }
        public string projectTypeKey { get; set; }
        public bool simplified { get; set; }
        public string style { get; set; }
        public bool favourite { get; set; }
        public bool isPrivate { get; set; }
        public IssueTypeHierarchy issueTypeHierarchy { get; set; }
        public Permissions permissions { get; set; }
        public Properties properties { get; set; }
        public string uuid { get; set; }
        public Insight insight { get; set; }
        public bool deleted { get; set; }
        public string retentionTillDate { get; set; }
        public string deletedDate { get; set; }
        public DeletedBy deletedBy { get; set; }
        public bool archived { get; set; }
        public string archivedDate { get; set; }
        public ArchivedBy archivedBy { get; set; }
        public LandingPageInfo landingPageInfo { get; set; }

    }

    public class AvatarUrls
    {
        [JsonProperty("16x16")]
        public string _16x16 { get; set; }
        [JsonProperty("24x24")]
        public string _24x24 { get; set; }
        [JsonProperty("32x32")]
        public string _32x32 { get; set; }
        [JsonProperty("48x48")]
        public string _48x48 { get; set; }
    }

    public class Item
    {
    }

    public class PagingCallback
    {
    }

    public class Callback
    {
    }

    public class Groups
    {
        public int size { get; set; }
        public List<Item> items { get; set; }
        public PagingCallback pagingCallback { get; set; }
        public Callback callback { get; set; }

        [JsonProperty("max-results")]
        public int MaxResults { get; set; }
    }

    public class ApplicationRoles
    {
        public int size { get; set; }
        public List<Item> items { get; set; }
        public PagingCallback pagingCallback { get; set; }
        public Callback callback { get; set; }

        [JsonProperty("max-results")]
        public int MaxResults { get; set; }
    }

    public class Lead
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class RealAssignee
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class Component
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Lead lead { get; set; }
        public string leadUserName { get; set; }
        public string assigneeType { get; set; }
        public Assignee assignee { get; set; }
        public string realAssigneeType { get; set; }
        public RealAssignee realAssignee { get; set; }
        public bool isAssigneeTypeValid { get; set; }
        public string project { get; set; }
        public int projectId { get; set; }
    }

    public class Project
    {
    }

    public class Scope
    {
        public string type { get; set; }
        public Project project { get; set; }
    }

    public class IssueType
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
        public string entityId { get; set; }
        public int hierarchyLevel { get; set; }
        public Scope scope { get; set; }
    }

    public class Operation
    {
        public string id { get; set; }
        public string styleClass { get; set; }
        public string iconClass { get; set; }
        public string label { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        public int weight { get; set; }
    }

    public class IssuesStatusForFixVersion
    {
        public int unmapped { get; set; }
        public int toDo { get; set; }
        public int inProgress { get; set; }
        public int done { get; set; }
    }

    public class Version
    {
        public string expand { get; set; }
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public string startDate { get; set; }
        public string releaseDate { get; set; }
        public bool overdue { get; set; }
        public string userStartDate { get; set; }
        public string userReleaseDate { get; set; }
        public string project { get; set; }
        public int projectId { get; set; }
        public string moveUnfixedIssuesTo { get; set; }
        public List<Operation> operations { get; set; }
        public IssuesStatusForFixVersion issuesStatusForFixVersion { get; set; }
    }

    public class Roles
    {
    }

    public class ProjectCategory
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Level
    {
        public int id { get; set; }
        public string name { get; set; }
        public int aboveLevelId { get; set; }
        public int belowLevelId { get; set; }
        public int projectConfigurationId { get; set; }
        public int level { get; set; }
        public List<int> issueTypeIds { get; set; }
        public string externalUuid { get; set; }
        public string globalHierarchyLevel { get; set; }
    }

    public class IssueTypeHierarchy
    {
        public int baseLevelId { get; set; }
        public List<Level> levels { get; set; }
    }

    //public class Permissions
    //{
    //    public bool canEdit { get; set; }
    //}

    public class Properties
    {
    }

    public class Insight
    {
        public int totalIssueCount { get; set; }
        public string lastIssueUpdateTime { get; set; }
    }

    public class DeletedBy
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class ArchivedBy
    {
        public string self { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class LandingPageInfo
    {
        public string url { get; set; }
        public string projectKey { get; set; }
        public string projectType { get; set; }
        public int boardId { get; set; }
        public bool simplified { get; set; }
    }
}
