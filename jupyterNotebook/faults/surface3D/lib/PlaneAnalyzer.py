import numpy as np

class PlaneAnalyzer:
    @staticmethod
    def print_info(plane):
        print(f'Plane equation: {plane.A}x + {plane.B}y + {plane.C}z + {plane.D} = 0')
        print(f'Slope angle: {PlaneAnalyzer.get_slope_angle(plane)} degrees')

    @staticmethod
    def get_slope_angle(plane):
        # Calculate the angle between the normal vector and the vertical direction (0, 0, 1)
        normal_vector = np.array([plane.A, plane.B, plane.C])
        vertical_vector = np.array([0, 0, 1])
        cos_angle = np.dot(normal_vector, vertical_vector) / (np.linalg.norm(normal_vector) * np.linalg.norm(vertical_vector))
        angle = np.arccos(cos_angle)
        return np.degrees(angle)  # Convert from radians to degrees
