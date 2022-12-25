namespace MochaMoth.SceneObject
{
    public interface ISceneObject
    {
        string ScenePath { get; }
        T GetMetadata<T>() where T : class, ISceneMetadata;
    }
}