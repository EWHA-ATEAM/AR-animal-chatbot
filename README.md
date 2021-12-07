# AR-animal-chatbot ; 안녕?나는,
**2021-2**/2022-1 컴퓨터공학전공 졸업프로젝트 기술검증<br/>
<img src="https://user-images.githubusercontent.com/60884877/145061490-1ac8909c-c582-40bc-9fee-80a6e6ba2887.png" width="300px">
<br/>

## 프로젝트 소개
> AR과 챗봇을 이용하여 멸종위기 동물과 소통할 수 있습니다. 
### 동기
무차별적인 포획으로 우리 땅에서 사라진 강치 이야기를 접한 후 안타까움을 느끼게 된 것이 계기가 되었습니다.
### 의의
* 동물권을 침해하지 않으면서 여러 동물을 만나볼 수 있습니다
* 나만의 동물 친구를 만들 수 있습니다.
* 환경 및 멸종위기동물 보호에 관심 가질 수 있습니다.
<br/>

## 기술검증
### AR-test
* Unity에서 AR 개발 환경 구성
  - AR Foundation & ARCore XR Plugin
  - Plane을 검출하고 터치했을 때 해당 위치에 오브젝트 생성
  - [빌드된 test용 apk파일](https://drive.google.com/file/d/1mNZ1_S0XkAgEkkrDd1oJyrT4SNHZ7TP_/view?usp=sharing)
* Json 파일을 스크립트를 이용해 Unity 애니메이션으로 구현하는 코드 작성<br/><img src="https://user-images.githubusercontent.com/60884877/145062966-92ad47c6-9b90-4f28-9f26-2c026fc1ec88.gif" width="400px">

### Pose Estimation
* Caffe2 & MPII dataset
  - 동영상 속 실제 동물의 움직임을 모션 인식 기술을 통해 분석<br/><img src="https://user-images.githubusercontent.com/60884877/145066352-8f2bc615-6d24-497e-bb1e-d66d039f0511.png" width="500px"> 
  - 사용자가 가상 동물과 직접 소통하는 듯한 느낌을 위해 사용자의 손을 인식하는 모션 인식 기술을 사용할 예정
### intelligent AI Chatbot in Python
* Keras 라이브러리에서 Sequential model import
  - Dense & Dropout layer을 add
  - 아주 작은 데이터셋만을 활용하여 간단한 챗봇 제작<br/><img src="https://user-images.githubusercontent.com/60884877/145062323-f3cff65d-e0b9-4049-a4b7-abe4c982533c.png" width="500px">

## 참여인원
| <img src="https://user-images.githubusercontent.com/60884877/145065869-3061a8b2-22f1-47ff-9bde-7ac45e598795.png" width="130px"> | <img src="https://user-images.githubusercontent.com/60884877/145065877-9815f00b-f28f-49f5-a26e-3a3c50f2804e.png" width="150px"> | <img src="https://user-images.githubusercontent.com/60884877/145065873-60f2f731-8006-4b00-be0c-749595f56c9d.png" width="150px"> | 
| ---------- | ---------- | ---------- | 
| [이희원](https://github.com/Tina-223) | [채지은](https://github.com/cje1903) | [최지민](https://github.com/zmin9) |
| Pose Estimation | intelligent AI Chatbot in Python | AR-test | 


