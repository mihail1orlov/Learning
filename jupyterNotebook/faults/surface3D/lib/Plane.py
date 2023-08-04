import numpy as np

class Plane:
    def __init__(self, A, B, C, D):
        self.A = A
        self.B = B
        self.C = C
        self.D = D

    def get_z(self, X, Y):
        if self.C != 0:
            return (-self.A * X - self.B * Y - self.D) / self.C
        else:
            return np.full(X.shape, -self.D)