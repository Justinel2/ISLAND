using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


namespace TMPro.Examples
{

    public class HungerUI : MonoBehaviour
    {

        //public objectType ObjectType;
        public bool isStatic;

        private TMP_Text m_text;

        private const string k_label = "Hunger: <#ff0000>{0}%</color>";
        private bool eating = false;

        public static float hungerLevel = 100.0f;
        public static float timer;
        public static bool timeStarted = false;
        public int minutes;
        private int seconds;
        private string time;
        private float toFill;

        void Start()
        {
            // Get a reference to the TMP text component.
            m_text = GetComponent<TextMeshProUGUI>();

            // Set the size of the font.
            m_text.fontSize = 14;

            //Set the text
            m_text.text = "A <#0080ff>simple</color> line of text.";

            // Get the preferred width and height based on the supplied width and height as opposed to the actual size of the current text container.
            Vector2 size = m_text.GetPreferredValues(Mathf.Infinity, Mathf.Infinity);

            //// Set the size of the RectTransform based on the new calculated values.
            //m_text.rectTransform.sizeDelta = new Vector2(size.x, size.y);

        }


        void Update()
        {
            GetTime();
            eating = GameObject.Find("Player01").GetComponent<Sleep>().inHouse;

            if (eating)
            {
                HandleEating();
            }
            else
                HandleDecay();

            if (!isStatic)
            {
                // Set text
                m_text.SetText(k_label, (int)hungerLevel);
            }
        }

        void GetTime()
        {
            timer += Time.deltaTime;
            print(timer);
            minutes = Mathf.FloorToInt(timer / 60F);
            seconds = Mathf.FloorToInt(timer - minutes * 60);
            //time = k_label + string.Format("{0:0}:{1:00}", minutes, seconds);
        }

        void HandleEating()
        {
            toFill = 100.0f - hungerLevel;
            if (toFill > 0)
            {
                for (int i = 0; i <= toFill; i++)
                {
                    hungerLevel++;
                }
            }
            else
                return;
        }

        void HandleDecay()
        {
            if (seconds % 3 == 0 && seconds > 3)
                hungerLevel -= 0.03f;
            return;
        }
    }
}