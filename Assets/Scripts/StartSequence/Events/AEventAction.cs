using UnityEngine;

namespace Events.Actions
{
    public abstract class AEventAction : ScriptableObject
    {
        public virtual void Reset() { }
        public virtual void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data) { }
        public virtual bool UpdateAction() { return true; }
        public virtual void EndAction() { }
    }
}