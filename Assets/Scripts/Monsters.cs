using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Monsters : MonoBehaviour
{
    //health
    public float maxHealth = 100, currentHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    float lerpSpeed;

    //attack
    public float damage = 5;
    public TextMeshProUGUI attackText;

    public GameObject TargetPlayer;

    private DoTweenManager doTweenManager;


    // Start is called before the first frame update
    void Start()
    {
        doTweenManager = GetComponent<DoTweenManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(15);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(15);

        }

        attackText.text = damage.ToString();
        healthText.text = currentHealth + "/" + maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));

        healthBar.color = healthColor;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }

    public void Heal(float healing)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healing;
        }
    }

    public void AttackCheck()
    {

        Vector2 shootPos = transform.position + Vector3.down * 3;
        RaycastHit2D hit = Physics2D.Raycast(shootPos, Vector2.down, 5);
        Debug.DrawRay(shootPos, Vector2.down, Color.blue, 5);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Card")
            {
                TargetPlayer = hit.collider.gameObject;
                PlayAttackAnimation();
            }

        }
    }

    public void PlayAttackAnimation()
    {
        doTweenManager.targetPos = TargetPlayer.transform.position;
        doTweenManager.PlayAnimatetion();
    }
}
