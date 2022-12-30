using UnityEngine;
using UnityEngine.UI;

namespace MochaMoth.SceneObject.ProgressDisplays.Implementations
{
	[RequireComponent(typeof(Slider))]
	public class SliderProgressDisplay : MonoBehaviour, IProgressDisplay
	{
		private Slider _slider;

		void Awake()
		{
			_slider = GetComponent<Slider>();
		}

		public void Progress(float progress)
		{
			_slider.value = progress;
		}
	}
}
