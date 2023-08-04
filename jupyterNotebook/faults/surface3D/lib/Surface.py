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

    def to_dict(self):
        return {
            'minEast': self.minEast,
            'minNorth': self.minNorth,
            'maxEast': self.maxEast,
            'maxNorth': self.maxNorth,
            'numRows': self.numRows,
            'numCols': self.numCols,
            'data': self.data.tolist()
        }

    @classmethod
    def from_dict(cls, d):
        surface = cls(d['minEast'], d['minNorth'], d['maxEast'], d['maxNorth'], d['numRows'], d['numCols'])
        surface.data = np.array(d['data'])
        return surface

    def save_to_file(self, file_path):
        with open(file_path, 'w') as f:
            json.dump(self.to_dict(), f)

    @classmethod
    def load_from_file(cls, file_path):
        with open(file_path, 'r') as f:
            return cls.from_dict(json.load(f))
