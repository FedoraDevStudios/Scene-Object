using MochaMoth.SceneObject.SceneMetadatas;
using MochaMoth.SceneObject.SceneReferences;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MochaMoth.SceneObject.SceneObjects.Implementations
{
	public class DefaultSceneObject : ISceneObject, ISerializationCallbackReceiver
	{
		[SerializeField, HideInInspector] ISceneReference _sceneReference;
		[SerializeField, HideLabel, BoxGroup("Scene Asset")] Object _sceneAsset = null;
		[SerializeField, HideLabel, BoxGroup("Metadata")] ISceneMetadata _metadata;

		[ShowInInspector, ReadOnly, BoxGroup("Scene Path"), HideLabel]
		public string ScenePath
		{
			get => SceneReference.GetScenePath(_sceneAsset);
			set => SceneReference.SetScenePath(value);
		}
		
		public ISceneReference SceneReference
		{
			get
			{
				return _sceneReference;

			}
		}

		public DefaultSceneObject()
		{
			_metadata = SceneMetadataFactory.Produce();
		}

		public DefaultSceneObject(Object sceneAsset)
		{
			if (SceneReference.IsValidSceneAsset(sceneAsset))
				_sceneAsset = sceneAsset;
		}

		public T GetMetadata<T>() where T : class, ISceneMetadata
		{
			if (_metadata is T)
				return _metadata as T;
			return default;
		}
		public void OnBeforeSerialize()
		{
			SceneReference?.OnBeforeSerialize(_sceneAsset);
		}

		public void OnAfterDeserialize()
		{
			SceneReference?.OnAfterDeserialize(_sceneAsset);
		}

		public ISceneObject Produce()
		{
			DefaultSceneObject dso = new DefaultSceneObject();
			dso._sceneReference = SceneReferenceFactory.Produce();
			return dso;
		}
	}
}