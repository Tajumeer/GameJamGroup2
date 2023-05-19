using Sounds;
using StartSequence.UI;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Events.Actions
{
    [CreateAssetMenu(fileName = "PlayClipTextAction", menuName = "Data/Actions/PlayClipTextAction")]
    public class PlayClipTextAction : AEventAction
    {
        [SerializeField]
        private float m_waitTimeNoAudio = 0.5f;
        private bool m_hasFinishedAudio = false;
        private EventResponder m_responder;

        public override void Reset()
        {
            m_hasFinishedAudio = false;
        }
        public override void StartAction(EventResponder _responder, GameObject _context, ScriptableObject _data)
        {
            m_responder = _responder;
            AudioClipAsset asset = (AudioClipAsset)_data;

            if (asset.Clip.AudioClip != null)
            {
                m_responder.AudioPlayer.clip = asset.Clip.AudioClip;
                m_responder.AudioPlayer.Play();
            }

            IInteractionTextDisplay display = GameObject.FindObjectsOfType<MonoBehaviour>()
                                                            .OfType<IInteractionTextDisplay>()
                                                            .FirstOrDefault();

            display.UpdateInteractionText(asset.Clip.Text);

            if (asset.Clip.AudioClip != null)
            {
                m_responder.StartCoroutine(WaitForSoundEnd(asset.Clip.AudioClip.length));
            }
            else
            {
                m_responder.StartCoroutine(WaitForSoundEnd(m_waitTimeNoAudio));
            }
        }

        private IEnumerator WaitForSoundEnd(float _duration)
        {
            yield return new WaitForSeconds(_duration);

            m_hasFinishedAudio = true;
        }

        public override bool UpdateAction()
        {
            return m_hasFinishedAudio;
        }

        public override void EndAction()
        {
            m_responder.AudioPlayer.Stop();
            m_responder.AudioPlayer.clip = null;

            m_hasFinishedAudio = false;
            m_responder = null;
        }
    }
}