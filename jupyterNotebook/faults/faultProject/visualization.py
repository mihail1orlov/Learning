import matplotlib.pyplot as plt
import numpy as np
from geometry import Line, Point2D

# Plot each line
def visualize(points, lines, x_min, x_max):
    x = np.linspace(x_min, x_max, 2)

    for line in lines:
        A, B, C = line.A, line.B, line.C
        line.print_details()

        # If B is not zero, compute y normally. Otherwise, draw a vertical line.
        if B != 0:
            y = (C - A * x) / B           
            plt.plot(x, y, f'-{line.color}', label=line.name)
        else:
            plt.axvline(x=-C / A, color=line.color, label=line.name)
            
        # Print whether each point is on the positive side of the line
        for point in points:
            print(f'line: {line.name}, point:{point.name} - isPositive: {line.is_positive_side(point)}')

    # Plot the points and label them
    for i, point in enumerate(points):
        plt.plot(point.md, point.tvd, f'{point.color}o', label=f'{point.name}_{i}')
        plt.text(point.md, point.tvd, f'_ {point.name}_{i}')

    plt.title('Lines with points')
    plt.xlabel('md')
    plt.ylabel('tvd')
    plt.legend(loc='best')
    plt.grid()

    plt.show()