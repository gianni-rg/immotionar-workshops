/************************************************************************************************************
 * 
 * Copyright (C) 2017 ImmotionAR, a division of Beps Engineering.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including 
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the 
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial 
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 ************************************************************************************************************/

using UnityEngine;

/// <summary>
/// Manages gaze-based interactions inside the program
/// </summary>
public class InteractionsManager : MonoBehaviour
{
    #region Public Unity Properties

    /// <summary>
    /// Crosshair of the game
    /// </summary>
    [Tooltip("Scene gameobject that has to be used as crosshair")]
    public GameObject CrossHair;

    #endregion

    #region Behaviour methods

    // Update is called once per frame
    void Update()
    {
        //perform raycasting to interact with objects with gaze (actually is more a look than a gaze, since there is no interval)

        RaycastHit hitInfo;

        //draw camera ray for debugging purposes
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000);

        //if camera ray hits an object
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo))
        {         
            //activate crosshair, and put it on collision point. Make it face the camera, always. Then set is color as black
            CrossHair.SetActive(true);
            CrossHair.transform.position = hitInfo.point;
            CrossHair.transform.LookAt(Camera.main.transform.position);
            CrossHair.GetComponentInChildren<Renderer>().sharedMaterial.color = new Color(0, 0, 0, 1.0f);

            //check if the collided object is an interactible object
            InteractibleObject iObj = hitInfo.collider.gameObject.GetComponent<InteractibleObject>();

            //if it is, call its interaction method
            if (iObj != null)
            {                
                iObj.Interact();
            }
            //if it is not, make the crosshair a bit transparent
            else
            {
                CrossHair.GetComponentInChildren<Renderer>().sharedMaterial.color = new Color(0, 0, 0, 0.5f);
            }
        }
        //if camera ray does not hit any objects, hide crosshair
        else
            CrossHair.SetActive(false);
    }

    #endregion
}
