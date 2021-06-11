using System.Collections;

public interface ISceneLoader
{
    void Load(ISceneObject sceneObject);
    IEnumerator LoadAsync(ISceneObject sceneObject);
}
