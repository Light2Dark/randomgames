using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    AudioSource audioSource;
    int currentTrack = 0;

    public AudioClip[] soundtrackList;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTrack = PlayerPrefs.GetInt("trackNum", currentTrack);
        PlaySong();
    }

    private void PlaySong() {
        audioSource.clip = soundtrackList[currentTrack];
        audioSource.Play();

        currentTrack++;
        if (currentTrack > soundtrackList.Length - 1) {
            currentTrack = 0;
        } 
        
        PlayerPrefs.SetInt("trackNum", currentTrack);
    }

    public string GetSoundtrackName() {
        return soundtrackList[currentTrack].ToString();
    }
}
