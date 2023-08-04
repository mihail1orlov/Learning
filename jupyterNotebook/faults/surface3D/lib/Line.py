from .Point3d import Point3d

class Line:
    def __init__(self, point1, point2):
        assert isinstance(point1, Point3d) and isinstance(point2, Point3d), "Points must be instances of Point3d class"
        self.point1 = point1
        self.point2 = point2
