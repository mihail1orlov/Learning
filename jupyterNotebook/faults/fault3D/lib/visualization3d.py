import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np

class visualization3d:
    def __init__(self):
        self.fig = plt.figure(figsize=(16, 16))
        self.ax = self.fig.add_subplot(111, projection='3d')
        self.ax.set_xlabel('East(x)')
        self.ax.set_ylabel('North(y)')
        self.ax.set_zlabel('TVD(z)')

    def plot_points(self, points, color='red'):
        x = [point.x for point in points]
        y = [point.y for point in points]
        z = [point.z for point in points]
        self.ax.scatter3D(x, y, z, color=color, marker='o')

    def plot_line(self, point1, point2, color='blue'):
        x = [point1.x, point2.x]
        y = [point1.y, point2.y]
        z = [point1.z, point2.z]
        self.ax.plot3D(x, y, z, color=color)

    def plot_plane(self, plane, x_range, y_range, color='gray'):
        X, Y = np.meshgrid(x_range, y_range)
        Z = (plane.D - plane.A * X - plane.B * Y) / plane.C
        self.ax.plot_surface(X, Y, Z, alpha=0.5, color=color)

    def show(self, elev=None, azim=None):
        if elev is not None:
            self.ax.view_init(elev=elev)
        if azim is not None:
            self.ax.view_init(azim=azim)
        plt.show()
