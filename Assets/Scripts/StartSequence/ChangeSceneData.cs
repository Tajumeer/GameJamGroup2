using UnityEngine;

namespace StartSequence
{
    [CreateAssetMenu(fileName = "New scene data", menuName = "Data/SceneData")]
    public class ChangeSceneData : ScriptableObject
    {
        public string SceneName => m_sceneName;
        [SerializeField]
        private string m_sceneName = "No scene";
    }
}
