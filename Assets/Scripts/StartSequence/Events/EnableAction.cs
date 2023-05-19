using UnityEngine;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "EnableAction", menuName = "Data/Actions/EnableAction")]
    public class EnableAction : AEventAction
    {
        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            _context.SetActive(true);
        }
    }
}
