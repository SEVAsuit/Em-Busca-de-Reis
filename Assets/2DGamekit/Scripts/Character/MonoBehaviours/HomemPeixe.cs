using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class HomemPeixe : Ally
{
	// Update is called once per frame
	void FixedUpdate()
	{
		if (enemy != null) 
		{
			if (isDashing)
			{
				m_Rigidbody2D.velocity = new Vector2(transform.localScale.x * m_DashForce, 0);
			}
			else if (!isHitted)
			{
				distToPlayer = enemy.transform.position.x - transform.position.x;
				distToPlayerY = enemy.transform.position.y - transform.position.y;

				if (Mathf.Abs(distToPlayer) < 0.25f)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(0f, m_Rigidbody2D.velocity.y);
					anim.SetBool("IsWaiting", true);
				}
				else if (Mathf.Abs(distToPlayer) > 0.25f && Mathf.Abs(distToPlayer) < meleeDist && Mathf.Abs(distToPlayerY) < 2f)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(0f, m_Rigidbody2D.velocity.y);
					if ((distToPlayer > 0f && transform.localScale.x < 0f) || (distToPlayer < 0f && transform.localScale.x > 0f)) 
						Flip();
					if (canAttack)
					{
						MeleeAttack();
					}
				}
				else if (Mathf.Abs(distToPlayer) > meleeDist && Mathf.Abs(distToPlayer) < rangeDist)
				{
					anim.SetBool("IsWaiting", false);
					m_Rigidbody2D.velocity = new Vector2(distToPlayer / Mathf.Abs(distToPlayer) * speed, m_Rigidbody2D.velocity.y);
				}
				else
				{
					if (!endDecision)
					{
						if ((distToPlayer > 0f && transform.localScale.x < 0f) || (distToPlayer < 0f && transform.localScale.x > 0f)) 
							Flip();

						/*if (randomDecision < 0.4f)
							Run();
						else if (randomDecision >= 0.4f && randomDecision < 0.6f)
							Jump();
						else if (randomDecision >= 0.6f && randomDecision < 0.8f)
							StartCoroutine(Dash());
						else if (randomDecision >= 0.8f && randomDecision < 0.95f)
							RangeAttack();
						else
							Idle();*/
							
						if (randomDecision < 0.95f)
							Jump();
						else
							Idle();
					}
					else
					{
						endDecision = false;
					}
				}
			}
			else if (isHitted)
			{
				if ((distToPlayer > 0f && transform.localScale.x > 0f) || (distToPlayer < 0f && transform.localScale.x < 0f))
				{
					Flip();
					StartCoroutine(Dash());
				}
				else
					StartCoroutine(Dash());
			}
		}
		else 
		{
			enemy = GameObject.FindWithTag("Player");
		}

		if (transform.localScale.x * m_Rigidbody2D.velocity.x > 0 && !m_FacingRight && life > 0)
		{
			// ... flip the player.
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (transform.localScale.x * m_Rigidbody2D.velocity.x < 0 && m_FacingRight && life > 0)
		{
			// ... flip the player.
			Flip();
		}
	}

	public new void Jump()
	{
		            /*    m_MoveVector = new Vector2(0, 20);

		Vector3 targetVelocity = new Vector2(distToPlayer / Mathf.Abs(distToPlayer) * speed, m_Rigidbody2D.velocity.y);
		Vector3 velocity = Vector3.zero;
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, 0.05f);*/
		if (doOnceDecision)
		{
			anim.SetBool("IsWaiting", false);
			m_Rigidbody2D.AddForce(new Vector2(0f, 850f));
			StartCoroutine(NextDecision(1f));
		}
	}
}
