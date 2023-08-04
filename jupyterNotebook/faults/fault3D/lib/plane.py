class plane:
    def __init__(self, *args):
        if len(args) == 3:  # Plane defined using 3 points
            self.calculate_coefficients(*args)
        elif len(args) == 2:  # Plane defined using a line and a point
            self.calculate_coefficients_from_line(*args)
        else:
            raise ValueError("Invalid number of arguments.")

    def calculate_coefficients(self, point1, point2, point3):
        x1, y1, z1 = point1.x, point1.y, point1.z
        x2, y2, z2 = point2.x, point2.y, point2.z
        x3, y3, z3 = point3.x, point3.y, point3.z

        A = (y2 - y1) * (z3 - z1) - (z2 - z1) * (y3 - y1)
        B = (z2 - z1) * (x3 - x1) - (x2 - x1) * (z3 - z1)
        C = (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1)
        D = -A * x1 - B * y1 - C * z1

        self.A = A
        self.B = B
        self.C = C
        self.D = D

    def calculate_coefficients_from_line(self, line, point):
        A, B, C = line.A, line.B, line.C
        x, y, z = point.x, point.y, point.z

        D = -A * x - B * y - C * z

        self.A = A
        self.B = B
        self.C = C
        self.D = D