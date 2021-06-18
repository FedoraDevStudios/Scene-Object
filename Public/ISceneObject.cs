using System.Collections;

public interface ISceneObject
{
    IEnumerator LoadAsync(ISceneLoader sceneLoader);
    string ScenePath { get; }
    T GetMetadata<T>() where T : class, ISceneMetadata;
}
