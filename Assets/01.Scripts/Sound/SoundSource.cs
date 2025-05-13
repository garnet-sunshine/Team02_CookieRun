using UnityEngine;

// Unity에서 효과음(SFX)을 재생하기 위해 일시적으로 생성되는 오브젝트
public class SoundSource : MonoBehaviour
{
    private AudioSource _audioSource; // 재생을 담당하는 AudioSource 컴포넌트

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance) // 외부에서 호출되어 사운드를 재생
    {
        // 오디오 소스가 아직 없으면 컴포넌트에서 가져옴
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        // 혹시 이전에 예약된 Invoke()가 있다면 취소로 중복방지
        CancelInvoke();
        // 클립,볼륨,피치를 설정하고 재생 시작
        _audioSource.clip = clip;
        _audioSource.volume = soundEffectVolume;
        _audioSource.Play();
        _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance); // 피치는 랜덤값이라 매번 다른 사운드를 연출할 수 있음

        Invoke("Disable", clip.length + 2); // 사운드 재생이 끝난 뒤 일정 시간 후 Disable()함수 호출
    }

    // 소리를 멈추고 이 사운드 오브젝트를 씬에서 제거
    public void Disable()
    {
        _audioSource.Stop();
        Destroy(this.gameObject);
    }
}