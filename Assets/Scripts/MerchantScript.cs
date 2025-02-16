using UnityEngine;

public class MerchantScript : MonoBehaviour
{
    //the procentage of trust that the merchat has for the player
    float trust;

    Vector3 targetPosition;

    //prices that the games compares against
    float bucketPrice;

    // REMOVE THIS COMMENT LATER - RAJAT


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //CalculateBucketPrice();




    }

    // Update is called once per frame
    void Update()
    {




        //merchant walking in and away
        if (DayCycle.day)
        {
            //check position, if not good move
            if (this.transform.position.x != 3)
            {
                targetPosition = new Vector3(3, 0, 0);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 1);
            }

        }
        else
        {
            //check poisition, if not move
            if (this.transform.position.x != -8)
            {
                targetPosition = new Vector3(-8, 0, 0);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 1);
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

    public bool EvaluateOffer(float offeredPrice)
    {
        if (offeredPrice >= bucketPrice)
        {
            //offered price is good for the fisherman

            //the difference in price is multiplied by 2 and added as trust increase
            trust = trust + ((offeredPrice - bucketPrice) * 2);

            //fisherman agrees
            return true;
        }
        else
        {
            //offered price is not ideal for fisherman

            //what is the maximum price the fisherman can agree too - the bigger trust, the better
            float trustThreshold = bucketPrice + ((float)trust / 10);

            if (bucketPrice + trustThreshold <= offeredPrice)
            {
                //fisherman agrees but sadly
                trust = trust - (float)(offeredPrice - bucketPrice);
                return true;

            }
            else
            {
                //fisherman declines
                trust = trust - ((float)(offeredPrice - bucketPrice) * 2);
                return false;
            }
        }


    }

    public void CalculateBucketPrice()
    {
        //calculating the bucketPrice
    }
}
