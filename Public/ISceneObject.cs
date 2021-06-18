public interface ISceneObject
{
    void Load(ISceneLoader sceneLoader);
    string ScenePath { get; }
    T GetMetadata<T>() where T : class, ISceneMetadata;
}
