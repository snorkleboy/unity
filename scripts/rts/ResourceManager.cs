namespace rts
{
    public static class ResourceManager
    {
        public static int ScrollWidth { get { return 30; } }

        public static float RotateAmount { get { return 10; } }
        public static float RotateSpeed { get { return 100; } }
        //Galaxy properties
        public static int numberOfStars = 300;
        public static int maxRad = 200;
        public static int minRad = 10;
        public static int minStarDis = 100;
        //galaxy view camera settings
        public static float ScrollSpeedGV { get { return 5; } }
        public static float ScrollSpeedVerticalGV { get { return 60f; } }
        public static float MinPanSpeedGV { get { return .5f; } }
        public static float MinZoomSpeedGV { get { return 6f; } }

        public static float MinCameraHeightGV { get { return 10; } }
        public static float MaxCameraHeightGV { get { return 80; } }
        public static float MaxCameraRadGV { get { return 250; } }

        public static float MinFieldofViewGV { get { return 60; } }
        public static float MaxFieldofViewGV { get { return 80; } }

        public static float ZoomedOutAngleGV { get { return 85; } }
        public static float ZoomedInAngleGV { get { return 45; } }
        public static float ZoomDampnerpanGV { get { return 5; } }

        //solar system camera settings
        public static float ScrollSpeedSS { get { return 3; } }
        public static float ScrollSpeedVerticalSS { get { return 100; } }
        public static float MinPanSpeedSS { get { return .1f; } }
        public static float MinZoomSpeedSS { get { return 10f; } }

        public static float MinCameraHeightSS { get { return 2f; } }
        public static float MaxCameraHeightSS { get { return 1000; } }
        public static float MaxCameraRadSS { get { return 5000; } }

        public static float MaxFieldofViewSS { get { return 80; } }
        public static float MinFieldofViewSS { get { return 2; } }

        public static float ZoomedOutAngleSS { get { return 55; } }
        public static float ZoomedInAngleSS { get { return 2; } }
        public static float ZoomDampnerpanSS { get { return 5; } }
    }
}


