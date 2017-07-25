using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BitByBit
{
    public class Animation
    {
        private int _currentFrame, _delayRemaining;
        private readonly int FinalFrame;
        private Bitmap[] images;
        public bool hasFinished;
        private const int MAX_DELAY = 1;

        public Animation(params Bitmap[] images)
        {
            FinalFrame = images.Length - 1;
            this.images = images;
            _currentFrame = 0;
            _delayRemaining = MAX_DELAY;
        }

        public Image playAnimation()
        {
            Image image = images[_currentFrame];
            if (_delayRemaining != 0)
                _delayRemaining--;
            else
            {
                proceedFrame();
                _delayRemaining = MAX_DELAY;
            }
            return images[_currentFrame];
        }

        private void proceedFrame()
        {
            _currentFrame++;
            if (_currentFrame == FinalFrame && _delayRemaining == 0)
            {
                _currentFrame = 0;
                hasFinished = true;
            }
            else
            {
                _delayRemaining--;
                hasFinished = false;
            }
            
        }

    }
}
