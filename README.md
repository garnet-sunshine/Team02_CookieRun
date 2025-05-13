<div align="center">
  
# 🎮 Unity 2D 마쉬런 게임 프로젝트

> ![타이틀화면](https://github.com/garnet-sunshine/Team02_CookieRun/blob/main/%ED%83%80%EC%9D%B4%ED%8B%80%ED%99%94%EB%A9%B4.png)

Unity 2D 기능을 활용하여 제작한 러닝 게임입니다.  
플레이어는 장애물을 피하고, 젤리와 아이템을 먹으며 점수를 획득합니다.

---
## 👥 조원

| 팀원 | 역할 | 담당 |
|------|------|------|
| 곽범수 | 팀장 | 캐릭터(이동,점프,슬라이드,충돌처리) |
| 조성득 | 팀원 | 아이템(부스트,거대화,체력회복) 및 속도증가 , 사운드 , README구현 |
| 이선정 | 팀원 | UI(시작,타이틀,클리어,게임종료 화면) |
| 선예지 | 팀원 | 하이어라키(인터페이스 구성, 빌드 밎 배포) |
| 김재훈 | 팀원 | 맵(스테이지 별 레벨디자인, 스테이지,장애물 생성)및 튜토리얼 구현 |


---

## 🧩 게임 화면 구성

| 구분 | 설명 |
|------|------|
| **Title 화면** | 제목, 게임 시작, 캐릭터 선택, 설정 진입 |
| **게임 로딩** | 현재 스테이지, 캐릭터, 연출, 프리팹, 2초 대기 |
| **게임 시작 UI** | 점프/슬라이드 버튼, 점수 표시, 체력 표시 등 |
| **게임 오버** | 결과 출력, 최고 점수, 나가기 버튼 |
| **설정 화면** | BGM On/Off, 볼륨 조절, 종료 버튼 |
| **일시정지** | 게임 정지, 계속하기, 종료하기 |

---

## 🖼️ 와이어프레임 구조도

> ![구조도](https://github.com/garnet-sunshine/Team02_CookieRun/blob/main/%EC%99%80%EC%9D%B4%EC%96%B4%ED%94%84%EB%A0%88%EC%9E%84.png)

---

## 🛠️ 사용 기술

- Unity 2D를 활용한 캐릭터 이동 및 점프 구현
- Rigidbody2D, BoxCollider2D, Animator 사용
- Canvas, Button을 이용한 UI 구성
- SoundManager를 통해 배경음 및 효과음 제어
- C# Script:
- Coroutine, GetComponent, PlayerPrefs 활용
- 점수 저장 및 상태 관리 기능 구현
- 씬 전환 및 UI 버튼을 통한 게임 흐름 제어
- TextMeshPro를 활용한 점수 UI 출력
- AudioSource, AudioClip을 통해 배경 및 효과음 재생 제어

---

## ⚙️ 주요 기능 (Game Features)

- PlayerController가 BaseController를 상속하여 기능 확장
- OnTriggerEnter2D + GetComponent<PlayerController>() 조합으로 충돌 처리:
- Item: 이동속도 증가, 크기 증가, 체력 회복
- Jelly: 점수 증가
- 배경 오브젝트가 Looper와 충돌 시 가장 뒤쪽 배경으로 이동 → 무한 배경 생성 구현
- 설정 UI에서 사운드 On/Off 버튼 및 볼륨 슬라이더 구현
- Input, GetKeyDown 메서드를 통한 키보드 입력 처리
- Rigidbody2D.velocity를 사용해 캐릭터가 오른쪽으로 지속 이동
- Animator 파라미터(bool)를 통해 상태 전환 및 애니메이션 제어

---

### 🎮 Unity 엔진 기능
- `Rigidbody2D`, `BoxCollider2D`, `Animator`
- UI 시스템: `Canvas`, `Button`, `Slider`

### 💻 프로그래밍
- C# 스크립트
- `Coroutine`, `GetComponent`, `PlayerPrefs`

### 🔧 게임 시스템
- 캐릭터 이동 및 점프
- 아이템 충돌 및 효과
- 젤리 점수 획득
- 게임 루프 처리
- 사운드 관리 시스템

### 🧱 에디터 활용
- 오브젝트 프리팹 관리
- 씬 구성
- 애니메이션 타임라인
- 태그와 레이어 설정

### 🌐 플랫폼 & 외부 연동
- 빌드: PC, Android, WebGL
- Git을 활용한 버전 관리
- Unity Asset Store 사용 (상업적 사용 및 배포 가능)

---

## 🧠 시스템 구성도

### 🎮 GameManager
- 전체 게임 흐름 제어

### 🗺️ MapManager
- 맵 스크롤, 배경 루핑 등

### 📈 ScoreManager
- 현재 점수 / 최고 점수 갱신

### 🔊 SoundManager
- BGM, 점프/슬라이드/아이템/젤리 사운드 관리

### 🧍 Player 시스템
- `BaseController` → `PlayerController` 상속 구조
- 이동, 점프, 충돌 판정, 체력 등 제어

### 🍬 Jelly 시스템
- `OnTriggerEnter2D`로 충돌 시 점수 획득 처리

### 💎 Item 시스템
- `ItemManager`: 아이템 관리
- `Item`: 충돌 시 속도 증가, 크기 증가, 체력 회복 등 효과 부여

### 🖥️ UIManager
- 버튼 이벤트, 슬라이더 조작, 설정 UI 관리

---

## 🎁 아이템 효과

| 아이템 | 효과 |
|--------|------|
| 부스트 | 이동 속도 증가 |
| 거대화 | 캐릭터 크기 확대 |
| 체력 회복 | 잃은 체력 일부 회복 |

---

<code>
## 📂 프로젝트 구조 예시
Assets/
├── Scripts/
│ ├── Managers/
│ │ ├── GameManager.cs
│ │ ├── ScoreManager.cs
│ │ └── SoundManager.cs
│ ├── Player/
│ │ ├── BaseController.cs
│ │ ├── Player.cs
│ │ └── PlayerController.cs
│ ├── Item/
│ │ ├── Item.cs
│ │ └── ItemManager.cs
│ └── Jelly/
│ └── Jelly.cs
├── Prefabs/
├── Scenes/
├── UI/
└── Sounds/
</code>
yaml
복사
편집

---

## 📌 빌드 지원
- ✅ PC
- ✅ Android
- ✅ WebGL

---

## 🔗 외부 연동
- GitHub 저장소 연동
- Unity Asset Store 에셋 사용 (라이선스 확인 완료)

---
</div>
