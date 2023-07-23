import numpy as np

class Line:
    def __init__(self, A, B, C):
        self.A = A
        self.B = B
        self.C = C

    @staticmethod
    def from_two_points(p1, p2):
        """Create a line from two points."""
        x1, y1 = p1.md, p1.tvd
        x2, y2 = p2.md, p2.tvd
        if x1 == x2:  # Avoid division by zero
            return Line(1, 0, x1)
        A = -(y2 - y1)
        B = x2 - x1
        C = A * x1 + B * y1
        return Line(A, B, C)

    @staticmethod
    def from_angle_point(angle, p):
        """Create a line from an angle and a point."""
        px, py = p.md, p.tvd
        if abs(angle - 90) < 0.01 or abs(angle + 90) < 0.01:
            A = 1
            B = 0
            C = -px
        else:
            # Convert angle from degrees to radians
            angle_rad = np.deg2rad(angle)
            A = np.tan(angle_rad)
            B = -1
            C = py - A * px
        return Line(A, B, C)

    def get_angle(self):
        if self.B != 0:
            angle_rad = np.arctan(-self.A / self.B)  # in radians
            angle_deg = np.rad2deg(angle_rad)  # convert to degrees
            return angle_deg
        else:
            return None
    def is_positive_side(self, p):
        """Check if a point is on the positive side of the line."""
        return (self.A * p.md + self.B * p.tvd - self.C) >= 0

    def print_details(self):
        print(f'Line details: A = {self.A}, B = {self.B}, C = {self.C}')
        print(f'isPositive: {line.is_positive_side(point)}')
        angle = self.get_angle()
        if angle is not None:
            print(f'Angle of inclination: {angle} degrees')
        else:
            print('The line is vertical, the angle of inclination is undefined.')