using UnityEngine;

public class MerchantScript : MonoBehaviour
{
    float trust = 50;
    Vector3 targetPosition;
    public GameObject bucketSpawner;
    float bucketPrice;
    bool isBucketSpawned = false;
    bool bellPressed = false;

    void Update()
    {
        // Changing the time of day - DEBUG
        if (Input.GetKeyDown(KeyCode.Space) && (this.transform.position.x == -2 || this.transform.position.x == 12))
        {
            DayCycle.day = !DayCycle.day;
        }

        // Merchant walking in and away
        if (DayCycle.day)
        {
            // Check position, if not good move
            if (!(this.transform.position.x <= -2))
            {
                targetPosition = new Vector3(-2, 0, 2);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 3);
            }
            else if (!isBucketSpawned)
            {
                bucketSpawner.GetComponent<BucketSpawner>().SpawnBucket();
                isBucketSpawned = true;
            }
        }
        else if (bellPressed) // So now the merhcant is walking away, only if the bell is pressed
        {
            // Check position, if not move
            if (!(this.transform.position.x >= 12))
            {
                targetPosition = new Vector3(12, 0, 2);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 3);
            }
            else
            {
                isBucketSpawned = false;
                bellPressed = false;
            }
        }

        if (trust <= 0)
        {
            DayCycle.noTrust = true;
        }

        if (trust > 100)
        {
            trust = 100;
        }
    }

    public void OnBellPressed()
    {
        bellPressed = true;
    }

    public bool EvaluateOffer(float offeredPrice)
    {

        //THIS ADDED HERE
        if (bucketSpawner.GetComponent<BucketSpawner>().spawnedBucket != null)
        {    
             bucketPrice = bucketSpawner.GetComponent<BucketSpawner>().totalValue;
        }
        //THIS ADDED HERE

        if (offeredPrice >= bucketPrice)
        {
            //update trust
            trust = trust + ((offeredPrice - bucketPrice) * 2);

            //money gain and loss
            DayCycle.money = DayCycle.money - (int)offeredPrice + (int)bucketPrice;

            //cost of livin
            DayCycle.money -= 10;
            return true;
        }
        else
        {
            float trustThreshold = bucketPrice + ((float)trust / 10);

            if (bucketPrice + trustThreshold <= offeredPrice)
            {
                //update trust
                trust = trust - (float)(offeredPrice - bucketPrice);

                //money gain and loss
                DayCycle.money = DayCycle.money - (int)offeredPrice + (int)bucketPrice;

                //cost of livin
                DayCycle.money -= 10;
                return true;
            }
            else
            {
                //update trust
                trust = trust - ((float)(offeredPrice - bucketPrice) * 2);
                
                //cost of livin
                DayCycle.money -= 10;
                return false;
            }
        }
    }

    public float GetTrust()
    {
        return trust;
    }
}