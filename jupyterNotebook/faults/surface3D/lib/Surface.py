import json
import numpy as np

class Surface:
    def __init__(self, minEast, minNorth, maxEast, maxNorth, numRows, numCols):
        self.minEast = minEast
        self.minNorth = minNorth
        self.maxEast = maxEast
        self.maxNorth = maxNorth
        self.numRows = numRows
        self.numCols = numCols

        self.data = np.zeros(self.numRows * self.numCols)

    def index(self, indexNorth, indexEast):
        return indexEast * self.numRows + (self.numRows - indexNorth - 1)

    def set_value(self, indexNorth, indexEast, value):
        grid_index = self.index(indexNorth, indexEast)
        self.data[grid_index] = value

    def get_value(self, indexNorth, indexEast):
        grid_index = self.index(indexNorth, indexEast)
        return self.data[grid_index]

    def get_data_2d(self):
        return self.data.reshape(self.numCols, self.numRows).T[::-1]