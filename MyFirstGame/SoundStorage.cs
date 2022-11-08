using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class SoundStorage
    {
        public List<SoundEffect> SoundEffectList { get; set; }
        public List<Song> SongList { get; set; }

        bool isPlaying = true;
        bool isHurry = true;
        public void LoadSounds(ContentManager content)
        {
            //Song
            SongList.Add(content.Load<Song>("Sound/bgm"));
            SongList.Add(content.Load<Song>("Sound/TimeWarning"));

            //Sound Effect
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_1-up"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_breakblock"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_coin"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_fireball"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_flagpole"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_jump-small"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_pause"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_pipe"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_powerup"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_powerup_appears"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_stomp"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_bump"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_jump-super"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_mariodie"));
            SoundEffectList.Add(content.Load<SoundEffect>("Sound/smb_stage_clear"));
        }

        private static SoundStorage instance;

        public static SoundStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundStorage();
                }
                return instance;
            }
        }
        public SoundStorage()
        {
            SoundEffectList = new List<SoundEffect>();
            SongList = new List<Song>();
        }
        public void PlayOneUp()
        {
            SoundEffectList[0].Play();
        }

        public void PlayBreakBlock()
        {
            SoundEffectList[1].Play();
        }

        public void PlayCoin()
        {
            SoundEffectList[2].Play();
        }

        public void PlayFireball()
        {
            SoundEffectList[3].Play();
        }

        public void PlayFlagpole()
        {
            SoundEffectList[4].Play();
        }

        public void PlayJumpSmall()
        {
            SoundEffectList[5].Play();
        }

        public void PlayPause()
        {
            SoundEffectList[6].Play();
        }

        public void PlayPipe()
        {
            SoundEffectList[7].Play();
        }

        public void PlayPowerUp()
        {
            SoundEffectList[8].Play();
        }

        public void PlayPowerUpAppear()
        {
            SoundEffectList[9].Play();
        }

        public void PlayStomp()
        {
            SoundEffectList[10].Play();
        }

        public void PlayBump()
        {
            SoundEffectList[11].Play();
        }
        public void PlayJumpSuper()
        {
            SoundEffectList[12].Play();
        }
        public void PlayDie()
        {
            SoundEffectList[13].Play();
        }
        public void PlayBGM()
        {
            MediaPlayer.Play(SongList[0]);
            MediaPlayer.IsRepeating = true;
        }
        public void PauseBGM()
        {
            if (isPlaying)
            {
                MediaPlayer.Pause();
                isPlaying = false;
            }
            else
            {
                MediaPlayer.Resume();
                isPlaying = true;
            }
        }
        public void StopBGM()
        {
            MediaPlayer.Stop();
        }
        public void PlayTimeWarning()
        {
            if (!isHurry)
            {
                MediaPlayer.Play(SongList[1]);
                MediaPlayer.IsRepeating = true;
                isHurry = true;
            }
        }
        public void PlayWin()
        {
            MediaPlayer.Stop();
            SoundEffectList[14].Play();
        }

    }
}
