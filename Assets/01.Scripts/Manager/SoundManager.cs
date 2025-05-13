using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // 어디서든 접근 가능하게 SoundManager instance로 만듬

    // Inspector에서 직접 조절 가능하게 만듬
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume; // 효과음
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance; // 무작위 흔들림 정도
    [SerializeField][Range(0f, 1f)] private float musicVolume; // 배경음악 크기

    private AudioSource musicAudioSource; // BGM재생을 위한 AudioSource
    public AudioClip musicClip; // 기본으로 재생할 배경음

    public AudioClip jellyClip; // 젤리
    public AudioClip itemClip; // 아이템
    public AudioClip jumpClip; // 점프
    public AudioClip slideClip; // 슬라이드
    public AudioClip dieClip; // 죽음

    public SoundSource soundSourcePrefab; // 효과음 재생을 위한 프리팹

    // 초기 설정
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
            return;
        }

        musicAudioSource = GetComponent<AudioSource>(); // 현재 오브젝트에 붙은 AudioSource를 가져옴
        musicAudioSource.volume = musicVolume; // 볼륨과 루프 설정
        musicAudioSource.loop = true;
    }

    // 배경음악 재생
    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    // 배경음악 교체
    public void ChangeBackGroundMusic(AudioClip clip)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    // 효과음 재생
    public static void PlayClip(AudioClip clip)
    {
        SoundSource obj = Instantiate(instance.soundSourcePrefab); // SoundSource프리팹을 생성
        SoundSource soundSource = obj.GetComponent<SoundSource>(); // 사운드 소스에 접근
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance); // 사운드 재생 완료 후 자동 제거
    }

    // 외부에서 Volume값을 넘기면 오디오 소스에 반영
    public void SetBGMVolume(float volume)
    {
        musicVolume = volume;
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = musicVolume;
        }
    }
}