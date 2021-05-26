using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FedoraDev.SceneObject.Implementations
{
    [RequireComponent(typeof(Slider))]
    public class SliderProgressDisplay : MonoBehaviour, IDisplayProgress
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
