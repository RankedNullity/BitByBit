using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Media;

namespace BitByBit
{
    public class Sound
    {
        //a bunch of media players
        private SoundPlayer menuMusic = new SoundPlayer(Properties.Resources.Menu_Music);
        private SoundPlayer themeMusic = new SoundPlayer(Properties.Resources.Cave_Music);
        private SoundPlayer itemPick = new SoundPlayer(Properties.Resources.Item);
        private SoundPlayer levelup = new SoundPlayer(Properties.Resources.Levelup);
        private SoundPlayer stab = new SoundPlayer(Properties.Resources.Stab);
        private SoundPlayer swipe = new SoundPlayer(Properties.Resources.Swipe);
        private SoundPlayer throwSound = new SoundPlayer(Properties.Resources.Throw);

        public Sound()
        {
        }

        public void playLevelUp()
        {
           
        }
        public void PlaySwipe()
        {
        
        }
        public void playStab()
        {
            
        }
        public void playItemPick()
        {
            
        }
        public void playMenu()
        {
            menuMusic.LoadAsync();
            menuMusic.PlayLooping();
        }
        public void stopMenu()
        {
            menuMusic.Stop();
        }
        public void stopTheme()
        {
            menuMusic.Stop();
        }

        public void playTheme()
        {
            themeMusic.LoadAsync();
            themeMusic.PlayLooping();
        }

        public void mute()
        {
            themeMusic.Stop();
            menuMusic.Stop();
            throwSound.Stop();
            swipe.Stop();
            stab.Stop();
            levelup.Stop();
            itemPick.Stop();
        }
    }
}

