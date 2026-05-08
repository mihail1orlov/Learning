import math

class point3d:
    def __init__(self, x, y, z, color='r'):
        self.x = x
        self.y = y
        self.z = z
        self.color = color

    def distance_to(self, other_point):
        """Calculate the Euclidean distance between this point and another 3D point."""
        dx = self.x - other_point.x
        dy = self.y - other_point.y
        dz = self.z - other_point.z
        return math.sqrt(dx**2 + dy**2 + dz**2)
