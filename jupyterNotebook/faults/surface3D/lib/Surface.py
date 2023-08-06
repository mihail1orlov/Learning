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

    def index(self, row, col):
        return row * self.numCols + col

    def set_value(self, row, col, value):
        self.data[self.index(row, col)] = value

    def get_value(self, row, col):
        return self.data[self.index(row, col)]

    def get_data_2d(self):
        return self.data.reshape(self.numRows, self.numCols)