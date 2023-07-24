import matplotlib.pyplot as plt
import numpy as np
from geometry import Line, Point2D

# Plot each line
def visualize(points, lines, extend_factor=0.1, show_legend=False):
    # Find limits of the points
    md_values = [p.md for p in points]
    tvd_values = [p.tvd for p in points]

    md_min, md_max = np.min(md_values), np.max(md_values)
    tvd_min, tvd_max = np.min(tvd_values), np.max(tvd_values)

    # Extend the limits 
    md_range = md_max - md_min
    tvd_range = tvd_max - tvd_min
    x_min, x_max = md_min - extend_factor * md_range, md_max + extend_factor * md_range
    y_min, y_max = tvd_min - extend_factor * tvd_range, tvd_max + extend_factor * tvd_range

    # Compute line values
    x = np.linspace(x_min, x_max, 400)
    
    colors = {
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
            print(f'{colors[line.color]}Line: {line.name}, point:{point.name} - isPositive: {line.is_positive_side(point)}{colors["reset"]}')


    # Plot the points and label them
    for i, point in enumerate(points):
        plt.plot(point.md, point.tvd, f'{point.color}o', label=f'{point.name}_{i}')
        plt.text(point.md, point.tvd, f' _{point.name}_{i}')

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