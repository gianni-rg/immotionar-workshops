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
/// Object that jumps when looked by the user
/// </summary>
public class JumpableObject : InteractibleObject
{
    #region InteractibleObject methods

    /// <summary>
    /// Specifies which actions to perfrom when this object is looked by the user
    /// </summary>
    public override void Interact ()
    {
        //make the object jump
        GetComponent<Rigidbody>().AddForce(2 * new Vector3(Random.value - 0.5f, 0.6f, Random.value - 0.5f), ForceMode.Impulse);
    }

    #endregion
}
