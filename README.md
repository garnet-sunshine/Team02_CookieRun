<div align="center">
  
# 🎮 Unity 2D 마쉬런 게임 프로젝트

Unity 2D 기능을 활용하여 제작한 러닝 게임입니다.  
플레이어는 장애물을 피하고, 젤리와 아이템을 먹으며 점수를 획득합니다.

---

| 팀원 | 역할 | 담당 |
|------|------|------|
| 곽범수 | 팀장 | 캐릭터(이동,점프,슬라이드,충돌처리) |
| 조성득 | 팀원 | 아이템(부스트,거대화,기본생성 아이템) 및 사운드 , README구현 |
| 이선정 | 팀원 | UI(시작,타이틀,클리어,게임종료 화면) |
| 선예지 | 팀원 | 하이어라키(인터페이스 구성, 빌드 밎 배포) |
| 김재훈 | 팀원 | 맵(스테이지 별 레벨디자인, 스테이지,장애물 생성)및 캐릭터 속도증가 |


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

## 🛠️ 사용 기술

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
| 속도 증가 | 이동 속도 증가 |
| 크기 증가 | 캐릭터 크기 확대 |
| 체력 회복 | 잃은 체력 일부 회복 |

---

## 🖼️ 와이어프레임 구조도

> ![구조도](https://github.com/사용자계정/저장소명/blob/main/이미지경로/구조도.png)  
> ※ 실제 이미지 경로로 교체해 주세요.

---

## ✅ 기타 기능
- `OnTriggerEnter2D`로 플레이어와 아이템/젤리 충돌 감지
- `GetComponent<PlayerController>()`로 플레이어 기능 접근
- `PlayerPrefs`로 최고 점수 저장
- `Coroutine`을 통한 시간 기반 이벤트 처리

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
