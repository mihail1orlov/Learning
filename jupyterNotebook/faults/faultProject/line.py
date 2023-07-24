import numpy as np
from points import Point2D

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
            C = px
        else:
            # Convert angle from degrees to radians
            angle_rad = np.deg2rad(angle)
            A = np.tan(angle_rad)
            B = -1
            C = py - A * px
            #C = -(-A * px + py)
        return Line(A, B, C)

    def intersection(self, other):
        # Calculate the determinant
        det = self.A * other.B - other.A * self.B
        if det != 0:
            # If the determinant is non-zero, the lines intersect
            x = (self.C * other.B - other.C * self.B) / det
            y = (self.A * other.C - other.A * self.C) / det
            return Point2D(x, y)
        else:
            # If the determinant is zero, the lines are parallel or coincide
            return None
    
    def get_angle(self):
        if self.B != 0:
            angle_rad = np.arctan(-self.A / self.B)  # in radians
            angle_deg = np.rad2deg(angle_rad)  # convert to degrees
            return angle_deg
        else:
            return None
    def is_positive_side(self, p):
        """Check if a point is on the positive side of the line."""
        return self.A * p.md + self.B * p.tvd >= self.C

    def are_lines_equal(line1, line2):
        if line1.A != 0 and line2.A != 0:
            return line1.B/line1.A == line2.B/line2.A and line1.C/line1.A == line2.C/line2.A
        elif line1.B != 0 and line2.B != 0:
            return line1.A/line1.B == line2.A/line2.B and line1.C/line1.B == line2.C/line2.B
        else:
            return line1.A == line2.A and line1.B == line2.B and line1.C == line2.C

    def print_details(self):
        print(f'Line {self.name} details: A = {self.A}, B = {self.B}, C = {self.C}')
        angle = self.get_angle()
        if angle is not None:
            print(f'Angle of inclination: {angle} degrees')
        else:
            print('The line is vertical, the angle of inclination is undefined.')