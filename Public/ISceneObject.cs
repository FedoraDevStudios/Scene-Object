public interface ISceneObject
{
    void Load();
    string ScenePath { get; }
    T GetMetadata<T>() where T : class, ISceneMetadata;
}
