using UnityEngine;

namespace MartianChild.Utility.Audio
{
    public class AudioHandler : MonoBehaviour
    {
        [Tooltip("Audio source to play from.")]
        public AudioSource source;
        [Tooltip("Audio storage to play clips from.")]
        public AudioStorage audioStorage;

        /// <summary>
        /// <para> Triggers attached audio source to play audio file once. </para>
        /// <param name="audioFileName"> audioFileName parameter is tied to the audio storage, pass in same name as audio file in audio storage.</param>
        /// </summary>
        public void PlayAudioOneShot(string audioFileName)
        {
            AudioClip clip = audioStorage.getAudioFile(audioFileName);
            source.PlayOneShot(clip);
        }

        /// <summary>
        /// <para> Triggers attached audio source to play audio file. </para>
        /// <param name="audioFileName"> audioFileName parameter is tied to the audio storage, pass in same name as audio file in audio storage.</param>
        /// </summary>
        public void PlayAudio(string audioFileName)
        {
            AudioClip clip = audioStorage.getAudioFile(audioFileName);
            source.clip = clip;
            source.Play();
        }

        /// <summary>
        /// <para> Stops all audio from attached audio source. </para>
        /// </summary>
        public void StopAudio()
        {
            source.Stop();
        }

        /// <summary>
        /// <para> Randomizes attached audio source pitch. </para>
        /// <param name="minPitch"> minPitch parameter is the minimum pitch that can be played.</param>
        /// <param name="maxPitch"> minPitch parameter is the maximum pitch that can be played.</param>
        /// </summary>
        public void RandomizePitch(float minPitch, float maxPitch)
        {
            source.pitch = Random.Range(minPitch, maxPitch);
        }

        /// <summary>
        /// <para> Randomizes attached audio source volume. </para>
        /// <param name="minVolume"> minPitch parameter is the minimum volume that can be played. </param>
        /// <param name="maxVolume"> minPitch parameter is the maximum volume that can be played. </param>
        /// </summary>
        public void RandomizeVolume(float minVolume, float maxVolume)
        {
            source.volume = Random.Range(minVolume, maxVolume);
        }
    }
}
