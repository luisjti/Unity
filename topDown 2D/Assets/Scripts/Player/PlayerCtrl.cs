using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class PlayerCtrl : MonoBehaviour
    {
        [SerializeField]
        private PlayerClass playerClass;

        public float speed;

        private Animator animator;

        private Rigidbody2D rb;

        private int constanteMultiplicacao = 100;

        private void Start()
        {
            speed = playerClass.velocidadeMovimento;
            animator = GetComponent<Animator>();
            rb =  GetComponent<Rigidbody2D>();
            GetComponent<SpriteRenderer>().color = playerClass.corLuz;
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                speed *= 2.5f;
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                speed /= 2.5f;
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

           rb.velocity = speed * dir * constanteMultiplicacao * Time.deltaTime;
        
        }
    }
}
