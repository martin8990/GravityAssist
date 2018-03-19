
using UnityEngine;
namespace Infrastructure
{

    public class WeaponAimer : MonoBehaviour
    {
        public Transform Target;
        public Transform Grip;

        //public Vector3 offset;
        Animator animator;
        public Transform barrel;
        public HumanBodyBones bone;

        public Transform boneTf;
        public Transform FPSCam;
        //public Vector3 topRot;
        //public Vector3 bottumRotSpine;
        //public Vector3 bottumRotGrip;
        public float radialOffset;
        public Vector3 dir;
        public float mag;

        //public Transform boneTransform;
        public bool Aim;
        private void Start()
        {
            animator = GetComponent<Animator>();
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
 

            //animator.SetBoneLocalRotation(bone, Quaternion.LookRotation());
            //Grip.transform.rotation = Quaternion.Euler(bottumRotGrip);
           // animator.SetLookAtPosition(Target.position);


        }

        public void LateUpdate()
        {
     

            if (Aim)
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, radialOffset, 0));
                FPSCam.LookAt(Target);
                FPSCam.localRotation = Quaternion.Euler(new Vector3(FPSCam.localRotation.eulerAngles.x, 0, 0));
                //var prevRot = boneTf.localRotation.eulerAngles; 
                //boneTf.LookAt(Target);
                //var newRot = boneTf.localRotation.eulerAngles;
                //boneTf.rotation = Quaternion.Euler(dir * mag);
                          }
        }

    }


}


