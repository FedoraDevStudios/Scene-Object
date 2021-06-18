using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace FedoraDev.SceneObject.Implementations
{
	public class DefaultSceneObject : ISceneObject, ISerializationCallbackReceiver
	{
		[SerializeField, HideInInspector] SceneReference _sceneReference;
		[SerializeField, HideLabel, BoxGroup("Scene Asset")] Object _sceneAsset = null;
		[SerializeField, HideLabel, BoxGroup("Metadata")] ISceneMetadata _metadata;

		[ShowInInspector, ReadOnly, BoxGroup("Scene Path"), HideLabel]
		public string ScenePath
		{
			get => SceneReference.GetScenePath(_sceneAsset);
			set => SceneReference.SetScenePath(value);
		}

		public SceneReference SceneReference
		{
			get
			{
				if (_sceneReference == null)
					_sceneReference = new SceneReference();
				return _sceneReference;
			}
		}

		public DefaultSceneObject() { }
		public DefaultSceneObject(Object sceneAsset)
		{
			if (SceneReference.IsValidSceneAsset(sceneAsset))
				_sceneAsset = sceneAsset;
		}

		public void Load(ISceneLoader sceneLoader) => sceneLoader.Load(this);

		public T GetMetadata<T>() where T : class, ISceneMetadata
		{
			if (_metadata is T)
				return _metadata as T;
			return default;
		}

		public void OnBeforeSerialize()
		{
			SceneReference.OnBeforeSerialize(_sceneAsset);
		}

		public void OnAfterDeserialize()
		{
			SceneReference.OnAfterDeserialize(_sceneAsset);
		}
	}
}