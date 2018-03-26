
using UnityEngine;
namespace Infrastructure
{

    public class WeaponAimer : MonoBehaviour
    {

        public Transform Grip;
        public Transform barrel;

        Animator animator;


   
 

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



        }



    }


}


