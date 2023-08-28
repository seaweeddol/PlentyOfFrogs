using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FrogDay1ScriptNew : MonoBehaviour
{
        string playerName = "Player";
        public Dropdown OptionsContainer;
        List<string> Options = new List<string> {
            "Do you like insects?",
            "What is your dream date?",
            "If you could live anywhere, where would you live?",
            "Ok, bye!"
        };
        public GameObject DateDialogue;
        public GameObject PlayerDialogue;
        public GameObject Content;
        private Transform ContentTransform;
        public GameObject UserLeftChat;
        public GameObject ChattingWith;
        public GameObject MatchesContainer;
        public Button SendButton;

        public Sprite OfflineImage;
        public GameObject InitialChatButton;

        public Button ChatOneButton, ChatTwoButton, ChatThreeButton, ChatFourButton, ChatFiveButton, ChatSixButton;
        string currentMatchKey = "frog";

        Dictionary<string, Hashtable> matches = new Dictionary<string, Hashtable>(){
                {"frog", new Hashtable(){
                        {"screenname", "RadPadDadChad"},
                        {"intro", "Hey, I'm Chad. I saw your profile and thought you sounded cool. Sorry, Im not super good with icebreakers or flirting; this is all a ribble confusing haha. So uh... do you wanna ask me anything?"},
                        {"responses", new string[] {
                                "I love insects! They're delicious. Worms too!",
                                "Just chilling on a log in a forest. Maybe eating bugs.",
                                "Well, I've always wanted to go surfing in Hawai'i so maybe one of the islands. I'm pretty much open to anything that isn't the concrete jungle I guess.",
                                "Yeah alright, I should go too. Later gator."

                        }},
                        {"profileImage", "avatar1"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
                {"catfish", new Hashtable(){
                        {"screenname", "Frog_1987"},
                        {"intro", "Hi, I saw in your profile that you like music. That's so great. I like music too! We're basically twins lol. Just ask me anything and I'm sure we'll have loads in common!"},
                        {"responses", new string[] {
                                "Insects are soooooooooo good, omg ribbit",
                                "Take me to a swamp and let's eat bugs and enjoy the water RIBBIT",
                                "No cities please, just wet, wet mud. I want to live near my besties ribbit :D",
                                "Haha alright bye! Really nice talking to you RIBBIT"
                        }},
                        {"profileImage", "avatar2"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
                {"dog", new Hashtable(){
                        {"screenname", "GuppyatHeart99"},
                        {"intro", "Hello friend! Always great to see another frog on here! People usually complain that I do all the talking so why don't I let you ask the questions this time. I'm an open book, ask me anything!"},
                        {"responses", new string[] {
                                "WHOA you like insects too?! I LOVE INSECTS. Do you want to eat an insect with me? I can go get one really quick!",
                                "A hop in the park! I love hopping around the frog park and chasing the other frogs!",
                                "I'd live in the frog park! I love the frog park so much! I love all the other frogs and hopping around with them!",
                                "Okay! Hope to hear from you soon! Miss you already!"
                        }},
                        {"profileImage", "avatar3"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
                {"cat", new Hashtable(){
                        {"screenname", "PrincessToadstool69"},
                        {"intro", "Hello darling, you look soft and cozy. You're just my type and tall as a cattail reed! What do you wanna know cutie?"},
                        {"responses", new string[] {
                                "I kill and eat every single fly I see. You could say I'm rather obsessed with them.",
                                "A nice quiet pad to lay on far, far away from the water and enjoy the sun together",
                                "Somewhere warm, darling. Being a toad is hard work and getting wet and slimy isn't exactly my cup of sugar, sugar.",
                                "Bye bye, hun. Don't be a stranger :P"
                        }},
                        {"profileImage", "avatar4"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
                {"snake", new Hashtable(){
                        {"screenname", "jimmy_the_frog_boy"},
                        {"intro", "hi, do you like frogs? you look nice, why don't we get to know each other :)"},
                        {"responses", new string[] {
                                "my diet is mostly insects :) i've also been known to eat worms here and there yess",
                                "burrowing into the mud in my cozy and dark holes together and listening to beats away from the harshness of the world :)",
                                "i wanna get lost and not live anywhere :) jusst wander river to river and hop away",
                                "Ok bye :)"
                        }},
                        {"profileImage", "avatar5"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
                {"crow", new Hashtable(){
                        {"screenname", "Xx_Prince.Charming_xX"},
                        {"intro", "I saw your picture and immediately knew I had to send you a message. I've always wondered if I'd turn into a prince if a beautiful creature such as yourself kissed me, so let's see if it's a match."},
                        {"responses", new string[] {
                                "What kind of frog doesn't like insects? Is this a trick question?",
                                "Using our beautiful tongues to catch flies at the top of a tree looking out over a beautiful swamp.",
                                "In a beautiful castle high in the snowy mountains with fountains and rooms full of shiny trinkets and beautiful collections of gold and silver lily pads.",
                                "Goodbye for now. I'm sure we'll have a chance to get to know each other a ribble better."
                        }},
                        {"profileImage", "avatar6"},
                        {"questionsEnabled", new bool[] {
                                true, true, true, false
                        }},
                        {"chatComplete", false},
                        {"chatHistory", new List<string>()}
                }},
        };

        void Start()
        {
                ContentTransform = Content.transform;
                EventSystem.current.SetSelectedGameObject(InitialChatButton);

                ChatOneButton.onClick.AddListener(() => selectNewChat("frog"));
                ChatTwoButton.onClick.AddListener(() => selectNewChat("catfish"));
                ChatThreeButton.onClick.AddListener(() => selectNewChat("dog"));
                ChatFourButton.onClick.AddListener(() => selectNewChat("cat"));
                ChatFiveButton.onClick.AddListener(() => selectNewChat("snake"));
                ChatSixButton.onClick.AddListener(() => selectNewChat("crow"));

                initiateDialogue((string)matches[currentMatchKey]["intro"]);
        }

        public void SendQuestion()
        {
                if (OptionsContainer.transform.Find("Label").GetComponent<Text>().text != "Type here...")
                {
                        string SelectedOption = OptionsContainer.options[OptionsContainer.value].text;
                        if (SelectedOption == Options[0])
                        {
                                ShowResponse(SelectedOption, 0);
                        }
                        else if (SelectedOption == Options[1])
                        {
                                ShowResponse(SelectedOption, 1);
                        }
                        else if (SelectedOption == Options[2])
                        {
                                ShowResponse(SelectedOption, 2);
                        }
                        else
                        {
                                matches[currentMatchKey]["chatComplete"] = true;
                                ShowResponse(SelectedOption, 3);

                                // check if all chats are complete, if so show next screen
                        }
                        StartCoroutine(DisableSendButton());
                        OptionsContainer.value = 0;
                        OptionsContainer.captionText.text = "Type here...";
                }
        }

        IEnumerator DisableSendButton()
        {
                SendButton.interactable = false;
                if (!((bool) matches[currentMatchKey]["chatComplete"]))
                {
                        yield return new WaitForSeconds(3);
                        SendButton.interactable = true;
                }
        }

        private void ShowResponse(string question, int index)
        {
                StartCoroutine(ShowDialogueBlock(
                        question,
                        ((string[]) matches[currentMatchKey]["responses"])[index],
                        index
                ));
        }

        public void BackToDateSelection()
        {
                SceneManager.LoadScene("ChooseChat");
        }

        public void scrollToBottom()
        {
                GameObject.Find("Dialogue Container").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        }

        void selectNewChat(string newChatName)
        {
                currentMatchKey = newChatName;
                // clear current chat
                while (ContentTransform.childCount > 0)
                {
                        DestroyImmediate(ContentTransform.GetChild(0).gameObject);
                }
                // need to recreate chat with chatHistory
                // need to only show questions that are not asked already or disable if chatComplete = true
                // reset questions asked to current chat - do I need to save this? probably
                // should chats only be clickable if you're done with the current chat?
                // maybe put them as away?
                initiateDialogue((string)matches[currentMatchKey]["intro"]);
        }

        IEnumerator ShowDialogueBlock(string playerText, string dateText, int questionIndex)
        {
                // disable chat selections
                for (int i = 0; i < MatchesContainer.transform.childCount; i++) {
                        Button child = MatchesContainer.transform.GetChild(i).GetComponent<Button>();
                        child.interactable = false;
                }

                string matchName = (string)matches[currentMatchKey]["screenname"];
                ((bool[])matches[currentMatchKey]["questionsEnabled"])[questionIndex] = false;
                setOptionsState(playerText);
                showDialogue(playerName, playerText);
                yield return new WaitForSeconds(1);
                showDialogue(matchName, matchName + " is typing...");
                yield return new WaitForSeconds(2);
                
                // Destroy last child "user is typing..."
                Destroy(ContentTransform.GetChild(ContentTransform.childCount - 1).gameObject);
                yield return new WaitForSeconds(0.1f);
                showDialogue(matchName, dateText);

                // add text to chat history
                ((List<string>)matches[currentMatchKey]["chatHistory"]).Add(playerText);
                ((List<string>)matches[currentMatchKey]["chatHistory"]).Add(dateText);

                if ((bool) matches[currentMatchKey]["chatComplete"])
                {
                        yield return new WaitForSeconds(1);
                        UserLeftChat.transform.GetComponent<Text>().text = matches[currentMatchKey]["screenname"] + " has left chat.";
                        Instantiate(UserLeftChat, ContentTransform);
                        Invoke("scrollToBottom", 0.1f);
                        UpdateOnlineStatus();
                        matches[currentMatchKey]["chatComplete"] = true;
                }

                // enable chat selections
                for (int i = 0; i < MatchesContainer.transform.childCount; i++) {
                        Button child = MatchesContainer.transform.GetChild(i).GetComponent<Button>();
                        child.interactable = true;
                }
        }

        private void initiateDialogue(string initialDialogue)
        {
                ChattingWith.transform.GetComponent<Text>().text = "You're chatting with " + matches[currentMatchKey]["screenname"];

                // if chatHistory is empty, show initial dialogue
                if (((List<string>) matches[currentMatchKey]["chatHistory"]).Count == 0) {
                        showDialogue((string)matches[currentMatchKey]["screenname"], initialDialogue);
                        ((List<string>)matches[currentMatchKey]["chatHistory"]).Add(initialDialogue);
                } else {
                // initiate chat history
                        for (int i = 0; i < ((List<string>)matches[currentMatchKey]["chatHistory"]).Count; i++)    {
                                string currentChatItem = ((List<string>)matches[currentMatchKey]["chatHistory"])[i];
                                if (i % 2 == 0) {
                                        InitDialogue(DateDialogue, currentChatItem);
                                } else {
                                        InitDialogue(PlayerDialogue, currentChatItem);
                                }
                                Invoke("UpdateScrollViewSize", 0.1f);
                                Invoke("scrollToBottom", 0.1f);
                        }

                        // TODO: if chat is complete, also add "user has left chat" line
                }

                // enable dropdown if chat is not completed
                if(!((bool) matches[currentMatchKey]["chatComplete"])) {
                        // clear current chat options
                        while (OptionsContainer.options.Count > 0)
                        {
                                OptionsContainer.options.RemoveAt(0);
                        }

                        // enable dropdown and send button
                        OptionsContainer.interactable = true;
                        SendButton.interactable = true;

                        // add remaining options for current chat
                        for (int i = 0; i < Options.Count; i++)
                        {
                                // if true, add option for current index
                                if (((bool[])matches[currentMatchKey]["questionsEnabled"])[i])
                                {
                                        Dropdown.OptionData newOption = new Dropdown.OptionData();
                                        newOption.text = Options[i].ToString();
                                        OptionsContainer.options.Add(newOption);
                                }
                        }
                        OptionsContainer.captionText.text = "Type here...";
                } else {
                // disable dropdown and send button if chat is complete
                        OptionsContainer.interactable = false;
                        SendButton.interactable = false;
                }
        }

        private void InitializeSprite() {
                Texture2D texture2D = Resources.Load<Texture2D>((string) matches[currentMatchKey]["profileImage"]);
                Sprite sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
                DateDialogue.transform.Find("Avatar").GetComponent<Image>().sprite = sprite;
        }


        private void showDialogue(string username, string text)
        {
                if (username == (string)matches[currentMatchKey]["screenname"])
                {
                        InitDialogue(DateDialogue, text);
                }
                else
                {
                        InitDialogue(PlayerDialogue, text);
                }
                Invoke("UpdateScrollViewSize", 0.1f);
                Invoke("scrollToBottom", 0.1f);
        }

        private void InitDialogue(GameObject dialogue, string text)
        {
                dialogue.transform.Find("MaxWidthContainer/DialogueText").GetComponent<Text>().text = text;
                if (dialogue == DateDialogue) {
                        InitializeSprite();
                }
                Instantiate(dialogue, ContentTransform);
        }

        private void setOptionsState(string selectedOption)
        {
                // remove selected option from dropdown
                Dropdown.OptionData option = OptionsContainer.options.Find(option => string.Equals(option.text, selectedOption));
                OptionsContainer.options.Remove(option);

                bool[] questionsAsked = (bool[])matches[currentMatchKey]["questionsEnabled"];

                if (!questionsAsked[0] && !questionsAsked[1] && !questionsAsked[2])
                {
                        OptionsContainer.AddOptions(new List<string> { Options[3] });
                        ((bool[]) matches[currentMatchKey]["questionsEnabled"])[3] = true;
                }
                if ((bool) matches[currentMatchKey]["chatComplete"])
                {
                        OptionsContainer.ClearOptions();
                        OptionsContainer.interactable = false;
                }
        }

        private void UpdateOnlineStatus()
        {
                Transform match = GameObject.Find((string) matches[currentMatchKey]["screenname"]).transform;
                // get current match online text
                match.Find("OnlineText").GetComponent<Text>().color = new Color(0.8207547f, 0.1909932f, 0.2093354f);
                match.Find("OnlineText").GetComponent<Text>().text = "offline";
                // get current match online image
                match.Find("OnlineIndicator").GetComponent<Image>().sprite = OfflineImage;
        }

        private void UpdateScrollViewSize()
        {
                LayoutRebuilder.ForceRebuildLayoutImmediate(ContentTransform.GetComponent<RectTransform>());
        }
}