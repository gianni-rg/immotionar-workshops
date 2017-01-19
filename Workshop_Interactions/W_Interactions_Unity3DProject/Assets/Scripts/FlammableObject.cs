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
/// Candle object that lights a fire when looked by the user
/// </summary>
public class FlammableObject : InteractibleObject
{
    #region Public Unity Properties

    /// <summary>
    /// Flame gameobject to generate to light the fire
    /// </summary>
    [Tooltip("Fire prefab used to light the candle")]
    public GameObject Flame;

    #endregion

    #region Private fields

    /// <summary>
    /// True if this candle is already lit, false otherwise
    /// </summary>
    private bool m_lit;

    #endregion

    #region Behaviour methods

    private void Start()
    {
        //candle is initially unlit
        m_lit = false;
    }

    #endregion

    #region InteractibleObject methods

    /// <summary>
    /// Specifies which actions to perfrom when this object is looked by the user
    /// </summary>
    public override void Interact()
    {
        //if we are unlit
        if(!m_lit)
        {
            //generate the flame and put it as correct position and orientation
            //Notice that this values are hardcoded since this is an example project.
            //More generic flammable objects should have orientation and position of flame passed as Unity parameters
            GameObject flame = Instantiate<GameObject>(Flame);
            flame.transform.SetParent(transform);
            flame.transform.rotation = Quaternion.Euler(-90, 0, 0);
            flame.transform.localPosition = new Vector3(0, 1.0f, 0);

            //candle is now lit
            m_lit = true;
        }
            
    }

    #endregion
}
