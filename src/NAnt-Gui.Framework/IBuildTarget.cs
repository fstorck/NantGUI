namespace NAntGui.Framework
{
    public interface IBuildTarget
    {
        string[] Depends { get; }
        string Name { get; }
        string Description { get; }
        bool Default { get; }
    }
}