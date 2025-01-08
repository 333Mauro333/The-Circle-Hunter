using System.Collections.Generic;

using UnityEngine;


namespace TheCircleHunter
{
    public class BallManager : MonoBehaviour
    {
		[Header("Values")]		
		[SerializeField] List<GameObject> ballList;
        [Space(10)]
        [SerializeField] int minBallsOnScreen;
		[SerializeField] int maxBallsOnScreen;
		[Space(10)]
		[SerializeField] float timeBetweenBallsAparitionNormal;
		[SerializeField] float timeBetweenBallsAparitionUnderMin;

		[Header("References")]
		[SerializeField] GameObject prefabBigBall;
		[SerializeField] GameObject prefabMediumBall;
		[Space(10)]
        [SerializeField] Transform wallUp;
		[SerializeField] Transform wallDown;
		[SerializeField] Transform wallLeft;
		[SerializeField] Transform wallRight;
        [SerializeField] GameObject ballsContainer;

		bool isAppearingTheBalls;

		float timerNormal;
        float timerUnderMin;
        


		void Awake()
		{
            timerNormal = timeBetweenBallsAparitionNormal;
            timerUnderMin = 0.0f;
		}

		void Start()
        {
            TimeSingleton.GetInstance().OnTimeFinished += StopAllBalls;
			TimeSingleton.GetInstance().OnTimeFinished += StopBallsCreation;
		}

		void Update()
		{
			if (isAppearingTheBalls)
            {
                if (ballList.Count < minBallsOnScreen)
                {
                    timerUnderMin -= Time.deltaTime;

                    if (timerUnderMin <= 0.0f)
                    {
						CreateBall();

                        timerUnderMin = timeBetweenBallsAparitionUnderMin;
					}
                }
                else if (ballList.Count < maxBallsOnScreen)
                {
					timerNormal -= Time.deltaTime;

					if (timerNormal <= 0.0f)
					{
						CreateBall();

						timerNormal = timeBetweenBallsAparitionNormal;
					}
				}
            }
		}

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= StopAllBalls;
			TimeSingleton.GetInstance().OnTimeFinished -= StopBallsCreation;
		}



        public void StartBallsCreation()
        {
            isAppearingTheBalls = true;
        }
		public void StopAllBalls()
        {
            for (int i = 0; i < ballList.Count; i++)
            {
                ballList[i].GetComponent<BallMovement>().StopMovement();
			}
        }
        public void StopBallsCreation()
        {
            isAppearingTheBalls = false;
        }
        public void RemoveBallFromList(GameObject ballObject)
        {
            BallMovement ballMovementScript = ballObject.GetComponent<BallMovement>();

            ballList.Remove(ballObject);
        }

        void CreateBall()
        {
            GameObject createdBall = null;
			int randomPercentage = Random.Range(1, 101);

            if (randomPercentage >= 1 && randomPercentage <= 50)
            {
				createdBall = Instantiate(prefabBigBall);
			}
			else if (randomPercentage >= 51 && randomPercentage <= 100)
			{
				createdBall = Instantiate(prefabMediumBall);
			}
			
            BallMovement ballMovementScript = createdBall.GetComponent<BallMovement>();
            BallOnClick ballOnClickScript = createdBall.GetComponent<BallOnClick>();

            float minX = wallLeft.position.x + wallLeft.localScale.x / 2.0f +
						 createdBall.transform.localScale.x / 2.0f;
			float maxX = wallRight.position.x - wallRight.localScale.x / 2.0f -
						 createdBall.transform.localScale.x / 2.0f;
			float minY = wallDown.position.y + wallDown.localScale.y / 2.0f +
						 createdBall.transform.localScale.y / 2.0f;
            float maxY = wallUp.position.y - wallUp.localScale.y / 2.0f -
						 createdBall.transform.localScale.y / 2.0f;

			createdBall.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
			createdBall.transform.parent = ballsContainer.transform;
            ballMovementScript.SetDirection(Random.Range(0.0f, 360.0f));
            ballMovementScript.SetSpeed(Random.Range(150.0f, 500.0f));
            ballOnClickScript.SetBallManager(this);

			ballList.Add(createdBall);
		}
    }
}
