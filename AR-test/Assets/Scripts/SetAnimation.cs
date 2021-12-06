using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SetAnimation : MonoBehaviour
{
    [System.Serializable]
    public class JsonData
    {
        public Image[] images;
        public Category[] categories;
        public Annotation[] annotations;   
    }

    [System.Serializable]
    public class Image
    {
        public int video_no;
        public int img_no;
        public string img_path;
        public int width;
        public int height;
        public int action_category;
    }

    [System.Serializable]
    public class Category
    {
        public string supercategory;
        public int id;
        public string person;
        public string[][] keypoints;
    }

    [System.Serializable]
    public class Annotation
    {
        public int img_no;
        public int person_no;
        public float[] bbox;
        public float[] keypoints;
        public int num_keypoint;
    }

    public const int NUM_JOINT = 16;
    public JsonData jsonAnim;
    public Animator animator;
    public Transform[] humanJoint = new Transform[NUM_JOINT];
    public int frame = 0;

    void Start()
    {
        if (animator)
        {
            // 아바타의 bone transforms을 가져옴
            humanJoint[0] = animator.GetBoneTransform(HumanBodyBones.RightFoot);
            humanJoint[1] = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
            humanJoint[2] = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
            humanJoint[3] = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
            humanJoint[4] = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
            humanJoint[5] = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
            humanJoint[6] = animator.GetBoneTransform(HumanBodyBones.Hips);
            humanJoint[7] = animator.GetBoneTransform(HumanBodyBones.Chest);
            humanJoint[8] = animator.GetBoneTransform(HumanBodyBones.Neck);
            humanJoint[9] = animator.GetBoneTransform(HumanBodyBones.Head);
            humanJoint[10] = animator.GetBoneTransform(HumanBodyBones.RightHand);
            humanJoint[11] = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
            humanJoint[12] = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
            humanJoint[13] = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
            humanJoint[14] = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
            humanJoint[15] = animator.GetBoneTransform(HumanBodyBones.LeftHand);
        }

        jsonAnim = LoadJsonFile<JsonData>(Application.dataPath, "InfoJsonAnim");
    }


    private float t = 0.0f;
    // 모든 Update함수가 호출된 뒤 호출
    void LateUpdate()
    {
        if (Time.time > t)
        {
            t = Time.time + 1.0f/10;
            setBoneTransform();
        }
    }

    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jData = Encoding.UTF8.GetString(data);

        Debug.Log(jData);

        return JsonUtility.FromJson<T>(jData);
    }

    private void setBoneTransform()
    {
        if (frame == jsonAnim.annotations.Length) frame = 0;

        for (int i = 0; i<NUM_JOINT;i++)
        {
            float x = jsonAnim.annotations[frame].keypoints[i * 6];
            float y = jsonAnim.annotations[frame].keypoints[i * 6 + 1];
            float z = jsonAnim.annotations[frame].keypoints[i * 6 + 2];
            float rot_x = jsonAnim.annotations[frame].keypoints[i * 6 + 3];
            float rot_y = jsonAnim.annotations[frame].keypoints[i * 6 + 4];
            float rot_z = jsonAnim.annotations[frame].keypoints[i * 6 + 5];
            
            Vector3 pos = new Vector3(x, y, z);
            humanJoint[i].position = pos*0.02f;

            Quaternion rot = Quaternion.Euler(rot_x, rot_y, rot_z);
            humanJoint[i].rotation = rot;
        }
        frame++;
    }
}
