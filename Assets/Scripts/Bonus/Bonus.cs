using UnityEngine;

namespace Labirint
{
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        [SerializeField] private Renderer _mapPoint;
        private bool _isInteractable;
        private Renderer _renderer;
        private Collider _collider;

        public bool IsInteractable
        {
            get { return _isInteractable; }
            set
            {
                _isInteractable = value;
                Renderer.enabled = value;
                _collider.enabled = value;
                _mapPoint.enabled = value;
            }

        }

        public Renderer Renderer { get => _renderer; set => _renderer = value; }

        public virtual void Awake()
        {
            Renderer = GetComponent<Renderer>();
            _collider = GetComponent<Collider>();
            IsInteractable = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsInteractable && other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable = false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
        
    }
}
