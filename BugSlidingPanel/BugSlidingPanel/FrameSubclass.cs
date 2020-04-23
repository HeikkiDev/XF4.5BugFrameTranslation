using Xamarin.Forms;

namespace BugSlidingPanel
{
    public class FrameSubclass : Frame
    {
        private double _originalTranslationY;
        private readonly PanGestureRecognizer _panGesture;

        public FrameSubclass()
        {
            _panGesture = new PanGestureRecognizer();
            _panGesture.PanUpdated += PanGesture_PanUpdated;
            GestureRecognizers.Add(_panGesture);
        }

        ~FrameSubclass()
        {
            _panGesture.PanUpdated -= PanGesture_PanUpdated;
        }

        private void PanGesture_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    _originalTranslationY = TranslationY;
                    break;
                case GestureStatus.Running:
                    TranslationY = _originalTranslationY + e.TotalY;
                    break;
                case GestureStatus.Canceled:
                    _originalTranslationY = 0;
                    break;
            }
        }
    }
}
