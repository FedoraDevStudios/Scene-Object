using System.Collections.Generic;
using UnityEngine;

namespace MochaMoth.SceneObject.Implementations
{
	[CreateAssetMenu(fileName = "", menuName = "Scene Object/Scene Layout")]
	public class SceneLayout : ScriptableObject
	{
		[SerializeField] string _wrapperText = "===== {0} =====";
		[SerializeField] List<string> _objects = new List<string>();


		public string WrapperText => _wrapperText;
		public List<string> Objects => _objects;
	}
}