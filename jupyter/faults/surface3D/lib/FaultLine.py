import numpy as np


class FaultLine:
    def __init__(self, origin, dip_angle, strike):
        self.origin = np.array(origin)            # Anchor point on the fault (North, East, TVD)
        self.dip_angle = np.radians(dip_angle)    # Dip angle in radians
        self.strike = np.radians(strike)          # Strike (azimuth) in radians

    def get_direction_vector(self):
        # Direction vector of the fault line.
        # `strike` is measured relative to North; `dip_angle` is the
        # angle of inclination from horizontal.
        dx = np.sin(self.strike) * np.cos(self.dip_angle)
        dy = np.cos(self.strike) * np.cos(self.dip_angle)
        dz = np.sin(self.dip_angle)
        return np.array([dx, dy, dz])

    def plot_on(self, plotter, length=1000, color='red'):
        # Render the fault line on the supplied 3D plotter.
        direction = self.get_direction_vector()
        end_point = self.origin + direction * length
        plotter.ax.plot([self.origin[0], end_point[0]],
                        [self.origin[1], end_point[1]],
                        [self.origin[2], end_point[2]],
                        color=color)
