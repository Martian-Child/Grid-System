using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace MartianChild.Utility.Audio
{
    public class AudioStorage : MonoBehaviour
    {
        [Tooltip("Audio files to store.")]
        public List<AudioFile> audioFiles;

        /// <summary>
        /// <para> Gets audio clip from audio file in audio files. </para>
        /// <param name="name"> Name parameter the name given to an audio file in cref="MartianChild.Utility.AudioStorage.audioFiles", pass in same name as audio file in audio storage to get that audio file. </param>
        /// </summary>
        public AudioClip getAudioFile(string name)
        {
            return (
                from audioFile in audioFiles
                where audioFile.id == name
                select audioFile.clip
            ).FirstOrDefault();
        }
    }

    [Serializable]
    public class AudioFile
    {
        public string id;
        public AudioClip clip;
    }
}
