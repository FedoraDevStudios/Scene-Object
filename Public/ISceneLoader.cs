using System.Collections;

namespace MochaMoth.SceneObject
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(ISceneObject sceneObject);
    }
}