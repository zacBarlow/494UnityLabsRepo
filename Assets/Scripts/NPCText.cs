using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC {
    public class NPCText : MonoBehaviour
    {
        public string basicDialogue = "I certainly hope you aren't still asking about that deranged Sith Lord Darth Plagueis. The Jedi will tell you no such stories";
        public List<string> interactiveDialogue;
        public List<string> PlayerDialogue;

        public void Start()
        {
            PlayerDialogue = new List<string>();
            PlayerDialogue.Add("I haven't even heard of it.(*Book not in inventory*)");
            PlayerDialogue.Add("I have brought it, but no, I've still not read it(*Book in inventory*)");
            PlayerDialogue.Add("(*you hand over the book*) Please regale with the legend of \"Darth Plageuis\"");
            PlayerDialogue.Add("(You have handed over the book already, you have nothing left to gain from speaking to this NPC)");
            interactiveDialogue = new List<string>();
            interactiveDialogue.Add("Did you bring me the book on the Tragedy of Darth Plageuis the Wise?");
            interactiveDialogue.Add("I thought not. It is not a story the jedi would have read to you.  Go fetch it before coming back.");
            interactiveDialogue.Add("I can sense you've brought me the book.  Have you ever read the Tragedy of Darth Plageuis the Wise?");
            interactiveDialogue.Add("This book is a Sith Legend, you know. Hand it to me, will you?");
            interactiveDialogue.Add("Thank you. Now, Darth Plagueis was a Dark Lord of the Sith, " +
                "so powerful and so wise he could use the Force to influence the midichlorians to create life... " +
                "He had such a knowledge of the dark side that he could even keep the ones he cared about from dying...");
            interactiveDialogue.Add("I have nothing more to share with you");
        }
        public string ReturnPDialogue(int option)
        {
            if(interactiveDialogue.Count < 1) return "no dialogue available";
            return PlayerDialogue[option];
        }
        public string ReturnNPCDialogue(int option)
        {
            if(option == -1) return basicDialogue;
            if (interactiveDialogue.Count < 1) return "no dialogue available";
            else if (option >= interactiveDialogue.Count) return "No such Dialogue option Exists";
            return interactiveDialogue[option];
        }

    }
}