using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // ��𼭵� ���� �����ϰ� SoundManager instance�� ����

    // Inspector���� ���� ���� �����ϰ� ����
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume; // ȿ����
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance; // ������ ��鸲 ����
    [SerializeField][Range(0f, 1f)] private float musicVolume; // ������� ũ��

    private AudioSource musicAudioSource; // BGM����� ���� AudioSource
    public AudioClip musicClip; // �⺻���� ����� �����

    public AudioClip jellyClip; // ����
    public AudioClip itemClip; // ������
    public AudioClip jumpClip; // ����
    public AudioClip slideClip; // �����̵�
    public AudioClip dieClip; // ����

    public SoundSource soundSourcePrefab; // ȿ���� ����� ���� ������

    // �ʱ� ����
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� ������Ʈ ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ���� ����
            return;
        }

        musicAudioSource = GetComponent<AudioSource>(); // ���� ������Ʈ�� ���� AudioSource�� ������
        musicAudioSource.volume = musicVolume; // ������ ���� ����
        musicAudioSource.loop = true;
    }

    // ������� ���
    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    // ������� ��ü
    public void ChangeBackGroundMusic(AudioClip clip)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    // ȿ���� ���
    public static void PlayClip(AudioClip clip)
    {
        SoundSource obj = Instantiate(instance.soundSourcePrefab); // SoundSource�������� ����
        SoundSource soundSource = obj.GetComponent<SoundSource>(); // ���� �ҽ��� ����
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance); // ���� ��� �Ϸ� �� �ڵ� ����
    }

    // �ܺο��� Volume���� �ѱ�� ����� �ҽ��� �ݿ�
    public void SetBGMVolume(float volume)
    {
        musicVolume = volume;
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = musicVolume;
        }
    }
}