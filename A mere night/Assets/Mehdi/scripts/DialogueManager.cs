using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;



    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();

    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("parle avec" + dialogue.name);
        dialogueBox.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
        //dialogueText.text = sentence;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("end");
        dialogueBox.SetActive(false);
    }
}
