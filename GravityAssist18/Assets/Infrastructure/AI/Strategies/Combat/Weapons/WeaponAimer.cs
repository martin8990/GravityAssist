
using UnityEngine;
namespace Infrastructure
{

    public class WeaponAimer : MonoBehaviour
    {
        public Transform Target;
        public Transform Grip;

        public Vector3 offset;
        Animator animator;
        public Transform barrel;
        public HumanBodyBones bone;
    
        public Vector3 topRot;
        public Vector3 bottumRotSpine;
        public Vector3 bottumRotGrip;
        public float radialOffset;
        public Transform boneTransform;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            //transform.LookAt(new Vector3(Target.position.x,0,Target.position.z));
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, radialOffset, 0));
        }

        public void OnAnimatorIK()
        {

            animator.SetIKPosition(AvatarIKGoal.RightHand, Grip.transform.position);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotation(AvatarIKGoal.RightHand, Grip.transform.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, barrel.transform.position);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, barrel.transform.rotation);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

            //float dy = -transform.position.y - 1 + Target.transform.position.y;
            //float dDist = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(Target.transform.position.x, Target.transform.position.z));
            //float angle = Mathf.Atan2(dy, dDist);

            //float t = (angle + Mathf.PI / 2f) / (Mathf.PI);
            //var BoneAngle = Vector3.Lerp(bottumRotSpine, topRot, t);

            //Vector3 relativePos = boneTransform.position - Target.position;
 

            //animator.SetBoneLocalRotation(bone, Quaternion.LookRotation(bottumRotSpine));
            //Grip.transform.rotation = Quaternion.Euler(bottumRotGrip);
           // animator.SetLookAtPosition(Target.position);


        }

    }


}


