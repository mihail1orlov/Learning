import numpy as np

class Plane:
    def __init__(self, A, B, C, D):
        self.A = A
        self.B = B
        self.C = C
        self.D = D

    def get_z(self, x, y):
        if self.C != 0:
            return (-self.A * x - self.B * y - self.D) / self.C
        else:
            return -self.D
        
    def point_side(self, x, y, z):
        return self.A*x + self.B*y + self.C*z + self.D