using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyMethods
{
    public class RotationMethods
    {
        public static void RotateToObjectInZaxis(GameObject rotatingGameObject, Vector3 target, float addModifier)
        {
            float angle = Mathf.Atan2(target.y - rotatingGameObject.transform.position.y,
                target.x - rotatingGameObject.transform.position.x) * Mathf.Rad2Deg;
            rotatingGameObject.transform.rotation = Quaternion.Euler(0, 0, angle + addModifier);
        }

        public static void Rotate2DObjectBasedOnItsVelocity(Rigidbody2D rotatingGameObjectRB, float addModifier)
        {
            var angle = Mathf.Atan2(rotatingGameObjectRB.velocity.y, rotatingGameObjectRB.velocity.x) * Mathf.Rad2Deg;
            rotatingGameObjectRB.MoveRotation(angle + addModifier);
        }

        public static void RotateToMousePos(GameObject rotatingGameObject, Camera camera, float addModifier)
        {
            var mousePos = InputMethods.GetMousePos(camera);
            RotateToObjectInZaxis(rotatingGameObject, mousePos, addModifier);
        }
    }

    //Nice 

    public class InputMethods
    {
        public static Vector3 GetMousePos(Camera camera)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = -camera.transform.position.z;
            return camera.ScreenToWorldPoint(mousePos);
        }
    }
}

