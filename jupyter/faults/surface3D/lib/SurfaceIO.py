import json
import numpy as np
from .Surface import Surface

class SurfaceIO:
    @staticmethod
    def to_dict(surface):
        return {
            'minEast': surface.minEast,
            'minNorth': surface.minNorth,
            'maxEast': surface.maxEast,
            'maxNorth': surface.maxNorth,
            'numRows': surface.numRows,
            'numCols': surface.numCols,
            'data': surface.data.tolist()
        }

    @staticmethod
    def from_dict(d):
        surface = Surface(d['minEast'], d['minNorth'], d['maxEast'], d['maxNorth'], d['numRows'], d['numCols'])
        surface.data = np.array(d['data'])
        return surface

    @staticmethod
    def save_to_file(surface, file_path):
        with open(file_path, 'w') as f:
            json.dump(SurfaceIO.to_dict(surface), f)

    @staticmethod
    def load_from_file(file_path):
        with open(file_path, 'r') as f:
            return SurfaceIO.from_dict(json.load(f))
