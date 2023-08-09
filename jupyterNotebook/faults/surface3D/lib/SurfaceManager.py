import numpy as np
from .Point3d import Point3d
from .Surface import Surface

class SurfaceManager:
    @staticmethod
    def create_surface_with_random_values(minEast, minNorth, maxEast, maxNorth, numRows, numCols):
        surface = Surface(minEast, minNorth, maxEast, maxNorth, numRows, numCols)
        for row in range(surface.numRows):
            for col in range(surface.numCols):
                surface.set_value(row, col, np.random.rand())
        return surface

    @staticmethod
    def process_surface(surface, plane):
        points = []
        for row in range(surface.numRows):
            for col in range(surface.numCols):
                x = surface.minEast + (surface.maxEast - surface.minEast) * (col / surface.numCols)
                y = surface.minNorth + (surface.maxNorth - surface.minNorth) * (row / surface.numRows)

                z = surface.get_value(row, col)

                side = plane.point_side(x, y, z)
                
                if side > 0:
                    points.append(Point3d(x, y, z, 'r'))
                elif side < 0:
                    points.append(Point3d(x, y, z, 'b'))
                else:
                    points.append(Point3d(x, y, z, 'y'))

        return points

    @staticmethod
    def process_surface_ne(surface, plane):
        points = []
        east_inc = (surface.maxEast - surface.minEast) / (surface.numCols - 1)
        north_inc = (surface.maxNorth - surface.minNorth) / (surface.numRows - 1)

        for row in range(surface.numRows):
            for col in range(surface.numCols):
                x = surface.minEast + col * east_inc
                y = surface.minNorth + row * north_inc

                z = surface.get_value(row, col)
                side = plane.point_side(x, y, z)
                
                if side > 0:
                    points.append(Point3d(x, y, z, 'r'))
                elif side < 0:
                    points.append(Point3d(x, y, z, 'b'))
                else:
                    points.append(Point3d(x, y, z, 'y'))

        return points