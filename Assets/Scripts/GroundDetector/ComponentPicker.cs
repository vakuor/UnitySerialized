using UnityEngine;

namespace GroundDetector
{
    [DefaultExecutionOrder(-1000)]
    public abstract class ComponentPicker<T> : MonoBehaviour
    {
        public T Value { get; private set; }
    
        private void Awake()
        {
            Value = GetComponent<T>();
        }
    }
}