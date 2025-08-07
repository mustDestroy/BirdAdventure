using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

namespace Assets.Script
{
    class AudioController : MonoBehaviour
    {

        public static AudioController uiAudioInstance;


        //public UIAudioControllerScript UIAudioInstance
        //{
        //    get { return uiAudioInstance; }
        //    private set { uiAudioInstance = value; }
        //}


        // Sound effect clips for the game
        [SerializeField] private AudioClip clickSound;
        [SerializeField] private float clickSoundVolume;

        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private float hoverSoundVolume;

        [SerializeField] private AudioClip deathSound;
        [SerializeField] private float deathSoundVolume;

        [SerializeField] private AudioClip crossPipeSound;
        [SerializeField] private float crossPipeSoundVolume;

        [SerializeField] private AudioClip collectCoinSound;
        [SerializeField] private float collectCoinSoundVolume;

        [SerializeField] private AudioClip biteAppleSound;
        [SerializeField] private float biteAppleSoundVolume;

        [SerializeField] private AudioClip drinkPotionSound;
        [SerializeField] private float drinkPotionSoundVolume;


        // Music clips for beground
        [SerializeField] private AudioClip lobbyMusic;
        [SerializeField] private float lobbyMusicVolume;

        [SerializeField] private AudioClip inGameMusic;
        [SerializeField] private float inGameMusicVolume;

        [SerializeField] private AudioClip fightMusic;
        [SerializeField] private float fightMusicVolume;

        private AudioSource musicSource;
        private AudioSource sfxSource;




        private void Awake()
        {
            if (uiAudioInstance != null && uiAudioInstance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            uiAudioInstance = this;
            DontDestroyOnLoad(this.gameObject); // Persist between the scenes

            if (musicSource == null)
            {
                musicSource = gameObject.AddComponent<AudioSource>();
                musicSource.loop = true;
            }
            if (sfxSource == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
                sfxSource.loop = false;
            }
        }

        // Sound Effect Control
        public void PlayClickSFX()
        {
            PlaySoundEffect(clickSound, clickSoundVolume);
        }
        public void PlayHoverSFX()
        {

            PlaySoundEffect(hoverSound, hoverSoundVolume);
        }
        public void PlayCrossPipeSFX()
        {
            PlaySoundEffect(crossPipeSound, crossPipeSoundVolume);
        }
        public void PlayDeathSFX()
        {

            PlaySoundEffect(deathSound, deathSoundVolume);
        }
        public void PlayCoinCollectSFX()
        {

            PlaySoundEffect(collectCoinSound, collectCoinSoundVolume);
        }
        public void PlayAppleBiteSFX()
        {

            PlaySoundEffect(biteAppleSound, biteAppleSoundVolume);
        }
        public void PlayPotionDrinkSFX()
        {

            PlaySoundEffect(drinkPotionSound, drinkPotionSoundVolume);
        }
        public void PlaySoundEffect(AudioClip clip, float audioVolume)
        {
            try
            {
                if (clip != null && sfxSource != null && audioVolume >= 0)
                {
                    sfxSource.PlayOneShot(clip, audioVolume);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("PlaySoundEffect Exception: " + ex.Message + ex.StackTrace);
            }

        }


        // Background Music Control
        public void PlayLobbyMusic()
        {
            PlayMusic(lobbyMusic, lobbyMusicVolume);
        }
        public void PlayInGameMusic()
        {
            PlayMusic(inGameMusic, inGameMusicVolume);
        }
        public void PlayFightMusic()
        {
            PlayMusic(fightMusic,fightMusicVolume);
        }


        private void PlayMusic(AudioClip clip, float audioVolume)
        {
            try
            {
                if (clip != null && musicSource != null && audioVolume >= 0)
                {
                    musicSource.Stop();
                    musicSource.clip = clip;
                    musicSource.volume = audioVolume;
                    musicSource.Play();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("PlayMusic Esxception: " + ex.Message + ex.StackTrace);
            }
        }



    }

}
