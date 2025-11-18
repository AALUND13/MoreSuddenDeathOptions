using MapEmbiggener;
using MapEmbiggener.Controllers;
using MapEmbiggener.Controllers.Default;
using UnboundLib;

namespace MoreSuddenDeathOptions.Utils {
    public static class SuddenDeathUtils {
        public static void ActivateSuddenDeath(DefaultBoundsController boundsController, bool toggle) {
            if((bool)boundsController.GetFieldValue("battleOnGoing")) {
                if(toggle) {
                    boundsController.SetPropertyValue("MaxXTarget", DefaultBoundsController.ClosingFrac * OutOfBoundsUtils.defaultX * ControllerManager.MapSize * ControllerManager.Zoom / (MapManager.instance?.currentMap?.Map?.size ?? 1f));
                    boundsController.SetPropertyValue("MinXTarget", -DefaultBoundsController.ClosingFrac * OutOfBoundsUtils.defaultX * ControllerManager.MapSize * ControllerManager.Zoom / (MapManager.instance?.currentMap?.Map?.size ?? 1f));
                    boundsController.SetPropertyValue("MaxYTarget", 0f);
                    boundsController.SetPropertyValue("MinYTarget", 0f);
                    boundsController.SetPropertyValue("ParticleGravityTarget", -0.1f);
                } else {
                    boundsController.SetPropertyValue("MaxXTarget", OutOfBoundsUtils.defaultX * ControllerManager.MapSize);
                    boundsController.SetPropertyValue("MinXTarget", -OutOfBoundsUtils.defaultX * ControllerManager.MapSize);
                    boundsController.SetPropertyValue("MaxYTarget", OutOfBoundsUtils.defaultY * ControllerManager.MapSize);
                    boundsController.SetPropertyValue("MinYTarget", -OutOfBoundsUtils.defaultY * ControllerManager.MapSize);
                    boundsController.SetPropertyValue("ParticleGravityTarget", 0f);
                }

                boundsController.SetPropertyValue("XSpeed", DefaultBoundsController.SuddenDeathXSpeed);
                boundsController.SetPropertyValue("YSpeed", DefaultBoundsController.SuddenDeathYSpeed);
            } else {
                boundsController.SetPropertyValue("MaxXTarget", OutOfBoundsUtils.defaultX * ControllerManager.MapSize);
                boundsController.SetPropertyValue("MinXTarget", -OutOfBoundsUtils.defaultX * ControllerManager.MapSize);
                boundsController.SetPropertyValue("MaxYTarget", OutOfBoundsUtils.defaultY * ControllerManager.MapSize);
                boundsController.SetPropertyValue("MinYTarget", -OutOfBoundsUtils.defaultY * ControllerManager.MapSize);
                boundsController.SetPropertyValue("ParticleGravityTarget", null);
                boundsController.SetPropertyValue("XSpeed", null);
                boundsController.SetPropertyValue("YSpeed", null);
            }

            boundsController.SetPropertyValue("ParticleGravitySpeed", null);
            boundsController.SetPropertyValue("AngleTarget", 0f);
            boundsController.SetPropertyValue("AngularSpeed", null);
        }

        public static void ActivateSuddenDeathCamera(DefaultCameraController cameraController, bool toggle) {
            if((bool)cameraController.GetFieldValue("battleOnGoing") && toggle) {
                cameraController.SetPropertyValue("ZoomTarget", 0f);
                cameraController.SetPropertyValue("ZoomSpeed", DefaultCameraController.SuddenDeathZoomSpeed);
                cameraController.SetPropertyValue("RotationTarget", null);
                cameraController.SetPropertyValue("RotationSpeed", null);
                cameraController.SetPropertyValue("PositionTarget", null);
                cameraController.SetPropertyValue("MovementSpeed", null);
            } else {
                cameraController.SetPropertyValue("ZoomTarget", null);
                cameraController.SetPropertyValue("ZoomSpeed", null);
                cameraController.SetPropertyValue("RotationTarget", null);
                cameraController.SetPropertyValue("RotationSpeed", null);
                cameraController.SetPropertyValue("PositionTarget", null);
                cameraController.SetPropertyValue("MovementSpeed", null);
            }
        }
    }
}
