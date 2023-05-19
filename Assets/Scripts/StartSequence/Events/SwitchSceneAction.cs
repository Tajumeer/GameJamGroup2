using StartSequence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "SwitchSceneAction", menuName = "Data/Actions/SwitchSceneAction")]
    public class SwitchSceneAction : AEventAction
    {
        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            ChangeSceneData sceneData = (ChangeSceneData)_data;
            SceneManager.LoadScene(sceneData.SceneName);
        }
    }
}