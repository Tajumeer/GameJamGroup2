namespace StartSequence.UI
{
    public interface IHoverTextDisplay
    {
        public void RequestUpdateHoverText(string _text);
        public void CancelUpdateHoverTextRequest(string _text);
    }
}
