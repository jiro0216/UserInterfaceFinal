using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Image image;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private Color originalColor;

    public Vector3 targetPosition, targetPosition2, targetPosition3, targetPosition4;

    private bool isZoomOut = false;
    private bool isFadeOut = false;
    private bool isFlyOut = false;
    private bool browseSequenceOut = false;
    private bool isFlippedOut = false;



    private void Reset()
    {

        image.transform.DOLocalMove(originalPosition, 0.1f);
        image.DOFade(originalColor.a, 0.25f);
        image.transform.DOScale(originalScale, 0.25f);

    }
    private void Awake()
    {
        // Store the original position, rotation, scale, and color for later reversal
        originalPosition = image.transform.localPosition;
        originalRotation = image.transform.localRotation; 
        originalScale = image.transform.localScale;
        originalColor = image.color;
    }


    public void Zoom() 
    {
        Reset();
        
        float zoomVal = 0;
        float targetScale = isZoomOut ? 2.5f : zoomVal;
        image.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        Reset();

        if (isFadeOut)
        {
            //image.DOFade(originalColor.a, 0.25f);
            image.color = originalColor;
        }
        else
        {
            image.DOFade(0.0f, 0.25f);
            
        }

        isFadeOut = !isFadeOut;
        
    }

    public void Fly()
    {
        Reset();

        Vector3 endPosition = isFlyOut ? originalPosition : originalPosition + new Vector3(600f, 0, 0);
        image.transform.DOLocalMove(endPosition, 0.1f);
        isFlyOut = !isFlyOut;
    }


    public void BrowseSequenceRight()
    {
        Reset();

        if ( browseSequenceOut)
        {
            //ImageToBrowse.transform.position = originalpos2;
            //ImageToBrowse.color = originalcolor;
            //ImageToBrowse.transform.localScale = originalScale;
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(image.DOFade(originalColor.a, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(originalPosition, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(originalPosition, 0.25f));

        }
        else
        {
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(image.transform.DOLocalMove(targetPosition, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(targetPosition2, 0.1f));
            sequence.AppendInterval(0);
            sequence.Append(image.DOFade(0, 0.25f));
        }
        browseSequenceOut = !browseSequenceOut;

    }

    public void BrowseSequenceLeft()
    {
        Reset();

        if (browseSequenceOut)
        {
            //ImageToBrowse.transform.position = originalpos2;
            //ImageToBrowse.color = originalcolor;
            //ImageToBrowse.transform.localScale = originalScale;
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(image.DOFade(originalColor.a, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(originalPosition, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(originalPosition, 0.25f));

        }
        else
        {
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(image.transform.DOLocalMove(targetPosition3, 0.25f));
            sequence.AppendInterval(0);
            sequence.Append(image.transform.DOLocalMove(targetPosition4, 0.1f));
            sequence.AppendInterval(0);
            sequence.Append(image.DOFade(0, 0.25f));
        }
        browseSequenceOut = !browseSequenceOut;



    }

    public void Flip()
    {
        Reset();

        if (isFlippedOut)
        {
            float targetRotation = isFlippedOut ? 2.5f : 0f; 
            image.transform.DORotate(new Vector3(0f, targetRotation, 0f), 0.25f); 
        }
        else 
        {
            image.transform.DORotate(new Vector3(0.0f, 180.0f, 0.0f), 0.25f);
        }

        isFlippedOut = !isFlippedOut;
    }
}
