# TimeRewinder

</br>

# 제작자: 박기혁 

> Unity 3D 공포 탈출 게임입니다.   
> 정신을 잃고 납치된 주인공은 어디인지 모르는 장소에서 탈출해야 합니다.   
> 플레이어가 가진 핸드폰에는 시간을 되감을 수 있는 기능이 있습니다.   
> 개발 기간은 약 3일이며, 구현된 내용은 다음과 같습니다.   

</br>

# 필수 구현 사항
* 인트로 씬 구성
  - UI 구성
  - 시작버튼 추가
# 추가 구현사항
* raycast, BoxCollider를 이용한 문 잠금해제 기믹
* 시간 되감기 기능
  - 메멘토 패턴을 활용해서 구현해 보았습니다.
  - 플레이어의 위치정보를 리스트로 기록하고, 되감기 버튼을 누르면 플레이어의 행동을 반대로 재생합니다.
* 효과음별 소리조절 기능(Master, BGM, SFX)

# 사용한 에셋, 파일
* 맵 에셋:   https://assetstore.unity.com/packages/3d/environments/urban/abandoned-asylum-49137
* 열쇠 에셋:   https://assetstore.unity.com/packages/3d/props/rust-key-167590
* 핸드폰 에셋:   https://assetstore.unity.com/packages/3d/props/electronics/free-smartphone-90324
* 사운드 및 음악파일
  - 문 효과음:   https://www.youtube.com/watch?v=Ai_YOlpNWz4&t=26s
  - 배경음악:   https://pixabay.com/ko/music/search/genre/%EA%B3%B5%ED%8F%AC%20%EC%9E%A5%EB%A9%B4/
