from .Point3d import Point3d
from .Plane import Plane
from .Line import Line
import numpy as np

class PlaneCreator:
    def from_points(self, point1, point2, point3):
        assert isinstance(point1, Point3d) and isinstance(point2, Point3d) and isinstance(point3, Point3d), "Points must be instances of Point3d class"
        
        # Calculate the vectors
        v1 = np.array([point2.x - point1.x, point2.y - point1.y, point2.z - point1.z])
        v2 = np.array([point3.x - point1.x, point3.y - point1.y, point3.z - point1.z])
        
        # Calculate the normal vector to the plane
        normal = np.cross(v1, v2)
        
        # Plane equation Ax + By + Cz + D = 0, where [A, B, C] is the normal vector
        return Plane(A=normal[0], B=normal[1], C=normal[2], D=-(normal @ [point1.x, point1.y, point1.z]))

    def from_line_and_point(self, line, point):
        assert isinstance(line, Line) and isinstance(point, Point3d), "Line must be an instance of Line class and point must be an instance of Point3d class"

        # Get two points from the line
        point1 = line.point1
        point2 = line.point2

        return self.from_points(point1, point2, point)

