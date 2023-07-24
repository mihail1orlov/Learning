import matplotlib.pyplot as plt
import numpy as np
from geometry import Line, Point2D

# Define colors globally
COLORS = {
    'r': '\033[91m',  # Red
    'g': '\033[92m',  # Green
    'y': '\033[93m',  # Yellow
    'b': '\033[94m',  # Blue
    'm': '\033[95m',  # Magenta
    'c': '\033[96m',  # Cyan
    'w': '\033[97m',  # White
    'k': '\033[30m',  # Black
    'reset': '\033[0m' # Reset to default color
}

def calculate_limits(points, extend_factor=0.1):
    md_values = [p.md for p in points]
    tvd_values = [p.tvd for p in points]

    md_min, md_max = np.min(md_values), np.max(md_values)
    tvd_min, tvd_max = np.min(tvd_values), np.max(tvd_values)

    md_range = md_max - md_min
    tvd_range = tvd_max - tvd_min
    x_min, x_max = md_min - extend_factor * md_range, md_max + extend_factor * md_range
    y_min, y_max = tvd_min - extend_factor * tvd_range, tvd_max + extend_factor * tvd_range

    return x_min, x_max, y_min, y_max

def plot_lines(lines, x_min, x_max):
    x = np.linspace(x_min, x_max, 400)

    for line in lines:
        A, B, C = line.A, line.B, line.C

        if B != 0:
            y = (C - A * x) / B           
            plt.plot(x, y, f'-{line.color}', label=line.name)
        else:
            plt.axvline(x=-C / A, color=line.color, label=line.name)

def plot_points(points):
    for i, point in enumerate(points):
        plt.plot(point.md, point.tvd, f'{point.color}o', label=f'{point.name}_{i}')
        plt.text(point.md, point.tvd, f' _{point.name}_{i}')

def print_points_positions(points, lines):
    for line in lines:
        print(f'{COLORS[line.color]}')
        line.print_details()
        for point in points:
            print(f'{COLORS[line.color]}Line: {line.name}, point:{point.name} - isPositive: {line.is_positive_side(point)}')
        print(f'{COLORS["reset"]}')

def check_lines_equality(lines):
    print("Checking for equal lines:")
    for i in range(len(lines)):
        for j in range(i + 1, len(lines)):
            if lines[i].are_lines_equal(lines[j]):
                print(f'Lines {lines[i].name} and {lines[j].name} are equal.')

def visualize(points, lines, extend_factor=0.1, show_legend=False):
    x_min, x_max, y_min, y_max = calculate_limits(points, extend_factor)

    plot_lines(lines, x_min, x_max)
    plot_points(points)

    plt.title('Lines with points')
    plt.xlabel('md')
    plt.ylabel('tvd')
    plt.xlim(x_min, x_max)
    plt.ylim(y_min, y_max)
    
    # Display the legend only if show_legend is True
    if show_legend:
        plt.legend(loc='best')

    plt.grid()
    plt.show()

    print_points_positions(points, lines)
    check_lines_equality(lines)