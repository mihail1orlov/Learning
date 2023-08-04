import numpy as np
import matplotlib.pyplot as plt
#from Point3d import Point3d
from mpl_toolkits.mplot3d import Axes3D

class Plotter3d:
    def __init__(self):
        self.fig = plt.figure(figsize=(16, 16))  # Increase figure size
        self.ax = self.fig.add_subplot(111, projection='3d')

    def plot_points(self, points):
        for point in points:
            self.ax.scatter([point.x], [point.y], [point.z], color=point.color)

    def plot_surface(self, surface, cmap='turbo'):
        x = np.linspace(surface.minEast, surface.maxEast, surface.numCols)
        y = np.linspace(surface.minNorth, surface.maxNorth, surface.numRows)
        X, Y = np.meshgrid(x, y)
        Z = surface.get_data_2d()

        self.ax.plot_surface(X, Y, Z, cmap=cmap)
    
    def plot_plane(self, plane, minEast, maxEast, minNorth, maxNorth, cmap='turbo'):
        x = np.linspace(minEast, maxEast, 100)
        y = np.linspace(minNorth, maxNorth, 100)
        X, Y = np.meshgrid(x, y)
        Z = plane.get_z(X, Y)

        self.ax.plot_surface(X, Y, Z, cmap=cmap, alpha=0.5)

    def show_plot(self):
        self.ax.set_xlabel('East (x)')
        self.ax.set_ylabel('North (y)')
        self.ax.set_zlabel('TVD (z)')
        plt.title('3D Visualization')
        plt.show()
