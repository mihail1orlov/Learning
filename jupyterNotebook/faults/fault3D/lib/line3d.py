import math

class line3d:
    def __init__(self, point1, point2):
        self.point1 = point1
        self.point2 = point2

    def direction_vector(self):
        """Calculate the direction vector of the line."""
        dx = self.point2.x - self.point1.x
        dy = self.point2.y - self.point1.y
        dz = self.point2.z - self.point1.z
        return (dx, dy, dz)

    def length(self):
        """Calculate the length of the line."""
        dv = self.direction_vector()
        return math.sqrt(dv[0]**2 + dv[1]**2 + dv[2]**2)
