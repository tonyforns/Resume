using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Skills
{
    public class SkillAttackComponent : MonoBehaviour
    {
        private float velocity = 5;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * velocity;
        }

        public void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("asdsa");
            Destroy(gameObject);
        }

    }
}