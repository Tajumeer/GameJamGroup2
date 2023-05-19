using UnityEngine;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "DisableAction", menuName = "Data/Actions/DisableAction")]
    public class DisableAction : AEventAction
    {
        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            _context.SetActive(false);
        }
    }
}