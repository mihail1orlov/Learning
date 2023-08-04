from .Point import Point

class Point3d(Point):
    def __init__(self, x, y, z, color='r', name=''):
        super().__init__(x, y, z)
        self.color = color
        self.name = name