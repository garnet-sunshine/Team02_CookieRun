using UnityEngine;

// Unity���� ȿ����(SFX)�� ����ϱ� ���� �Ͻ������� �����Ǵ� ������Ʈ
public class SoundSource : MonoBehaviour
{
    private AudioSource _audioSource; // ����� ����ϴ� AudioSource ������Ʈ

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance) // �ܺο��� ȣ��Ǿ� ���带 ���
    {
        // ����� �ҽ��� ���� ������ ������Ʈ���� ������
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        // Ȥ�� ������ ����� Invoke()�� �ִٸ� ��ҷ� �ߺ�����
        CancelInvoke();
        // Ŭ��,����,��ġ�� �����ϰ� ��� ����
        _audioSource.clip = clip;
        _audioSource.volume = soundEffectVolume;
        _audioSource.Play();
        _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance); // ��ġ�� �������̶� �Ź� �ٸ� ���带 ������ �� ����

        Invoke("Disable", clip.length + 2); // ���� ����� ���� �� ���� �ð� �� Disable()�Լ� ȣ��
    }

    // �Ҹ��� ���߰� �� ���� ������Ʈ�� ������ ����
    public void Disable()
    {
        _audioSource.Stop();
        Destroy(this.gameObject);
    }
}