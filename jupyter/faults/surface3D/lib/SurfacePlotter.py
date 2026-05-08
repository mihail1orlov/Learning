import numpy as np
import matplotlib.pyplot as plt
from .Surface import Surface

class SurfacePlotter:
    def __init__(self, figsize=(12, 6)):
        self.figsize = figsize

    def plot_surface(self, surface, title="Surface"):
        plt.figure(figsize=self.figsize)
        plt.title(title)
        plt.imshow(surface.get_data_2d(), cmap='viridis', origin='lower', extent=[surface.minEast, surface.maxEast, surface.minNorth, surface.maxNorth])
        plt.colorbar(label='TVD')
        plt.xlabel('East')
        plt.ylabel('North')
        plt.show()

    def plot_surfaces(self, s1, s2, title1="Surface 1", title2="Surface 2"):
        plt.figure(figsize=self.figsize)

        plt.subplot(1, 2, 1)
        plt.title(title1)
        plt.imshow(s1.get_data_2d(), cmap='viridis', origin='lower', extent=[s1.minEast, s1.maxEast, s1.minNorth, s1.maxNorth])
        plt.colorbar(label='TVD')
        plt.xlabel('East')
        plt.ylabel('North')

        plt.subplot(1, 2, 2)
        plt.title(title2)
        plt.imshow(s2.get_data_2d(), cmap='viridis', origin='lower', extent=[s2.minEast, s2.maxEast, s2.minNorth, s2.maxNorth])
        plt.colorbar(label='TVD')
        plt.xlabel('East')
        plt.ylabel('North')

        plt.tight_layout()
        plt.show()